using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Globalization;
using System.IO;
using System.Web;

namespace CHSNS.Rest
{
    using System.Web.Routing;

    public class RestApi
    {
        private Uri ApiUrl { get; set; }
        public RouteValueDictionary DefaultDictionary { get; set; }
        public RestApi(string apiUrl,object defaultDict)
        {
            DefaultDictionary = new RouteValueDictionary(defaultDict);
            ApiUrl = new Uri(apiUrl);
        }
        #region private field

        private const int CDefaultTimeout = 10 * 1000;
        public string Username { get; set; }
        public string Password { get; set; }

        #endregion

        public string Get(string method, object vars, bool authenticate)
        {
            var dict = new RouteValueDictionary(vars);
            dict.AddOther(DefaultDictionary);
            return Get(new Uri(ApiUrl, method), dict, authenticate);
        }
        public string Get(Uri uri, IDictionary<string, object> vars, bool authenticate)
        {
            string httpuri = uri.ToString();
            if ((vars != null) && (vars.Count > 0))
            {
                string paramlist = GetParamString(vars);
                httpuri += "?" + paramlist;
            }
 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpuri);
            if (authenticate)
            {
                string usernamePassword = Username + ":" + Password;
                CredentialCache mycache = new CredentialCache {{new Uri(httpuri), "Basic", new NetworkCredential(Username, Password)}};
                request.Credentials = mycache;
                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword))); 
            }
            request.Accept = "*/*"; //接受任意文件
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.1.4322)"; // 模拟使用IE在浏览
            request.Headers["Accept-Language"] = "zh-cn,zh;q=0.5";

            request.UserAgent = "TSina 0.1" ;
            request.ReadWriteTimeout = CDefaultTimeout;
            request.Method = "Get";
            string responseText;
            try
            {
                responseText = GetResponseText(request);
            }
            catch (WebException ex)
            {
                throw new ApplicationException(
                    String.Format(CultureInfo.InvariantCulture, "An error occured accesing page {0}", uri)
                    , ex);
            }
            return responseText;
        }
        public string Post(string method, object vars, bool authenticate)
        {
            var dict = new RouteValueDictionary(vars);
            dict.AddOther(DefaultDictionary);
            return Post(new Uri(ApiUrl, method), dict, authenticate);
        }
        public string Post(Uri uri, IDictionary<string, object> vars, bool authenticate)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            if (authenticate)
            {
                string usernamePassword = Username + ":" + Password;
                CredentialCache mycache = new CredentialCache {{uri, "Basic", new NetworkCredential(Username, Password)}};
                request.Credentials = mycache;
                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
            }
             
            request.ReadWriteTimeout = CDefaultTimeout;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (request.ServicePoint != null)
            {
                request.ServicePoint.Expect100Continue = false;
            }

            // Append params to post-request
            string paramlist = GetParamString(vars);
            request.ContentLength = paramlist.Length;

            using (Stream postStream = request.GetRequestStream())
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(paramlist);
                postStream.Write(bytes, 0, bytes.Length);
            }

            // Perform request
            string responseText;
            try
            {
                responseText = GetResponseText(request);
            }
            catch (WebException ex)
            {
                throw new ApplicationException(
                    String.Format(CultureInfo.InvariantCulture, "An error occured accesing page {0}", uri)
                    , ex);
            }
            return responseText;
        }
        #region tools

        private static string GetParamString(IDictionary<string, object> vars)
        {
            int i = 0;
            string paramlist = String.Empty;
            foreach (var kv in vars)
            {
                if (kv.Value != null)
                {
                    paramlist += kv.Key + "=" + HttpUtility.UrlEncode(kv.Value.ToString(), Encoding.UTF8);
                    if (i < vars.Count - 1)
                    {
                        paramlist += "&";
                    }
                }
                i++;
            }
            return paramlist;
        }
        private static string GetResponseText(HttpWebRequest request)
        {
            string responseText;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream respStream = response.GetResponseStream())
            {
                Uri respuri = response.ResponseUri;
                responseText = GetStreamText(respStream);
                HttpStatusCode statusCode = response.StatusCode;
                response.Close();

                // Check if call was successfull
                switch (statusCode)
                {
                    case HttpStatusCode.OK:
                        break;

                    case HttpStatusCode.Forbidden:
                        throw new ApplicationException(responseText + " " + respuri);

                    case HttpStatusCode.NotFound:
                        throw new ApplicationException(responseText + " " + respuri);

                    default:
                        int numericStatus = (int)statusCode;
                        if ((numericStatus >= 500) && (numericStatus <= 600))
                        {
                            throw new ApplicationException(responseText + " " + respuri);
                        }
                        else
                        {
                            bool rateLimitExceeded = responseText.Contains("Rate limit exceeded");
                            if (rateLimitExceeded)
                            {
                                throw new ApplicationException(responseText);
                            }
                            throw new ApplicationException(responseText + " " + respuri);
                        }
                }
            }
            return responseText;
        }
        private static string GetStreamText(Stream respStream)
        {
            string responseText = null;
            using (StreamReader sr = new StreamReader(respStream))
            {
                responseText = sr.ReadToEnd();
            }
            return responseText;
        }

        #endregion
    }
}
