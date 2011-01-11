using System.Text;
using CHSNS.Rest;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;

namespace TSinaApi
{
    using System;

    public class TSinaClient
    {
        public Uri ApiUrl { get; private set; }
        public long ApiKey { get; set; }
        //public string ApiSecret { get; set; }
        public RestApi RestApi { get; set; }
        private ApiFormat FormatType { get; set; }

        public string Format
         {
             get { return FormatType.ToString().ToLower(); }
         }
        public TSinaClient(long apiKey,string username,string password)
        {
            ApiKey = apiKey;
            //ApiSecret = apiSecret;
            Users = new UsersRest {Client = this};
            Statuses = new StatusesRest { Client = this };
            FriendShips = new FriendShipsRest {Client = this};
            ApiUrl = new Uri("http://api.t.sina.com.cn/");
            RestApi = new RestApi(new {source = apiKey})
                          {
                              Username = username,
                              Password = password,
                              GenerateUrlFunc = GenerateUrl
                          };
            FormatType = ApiFormat.Json;
        }

        private Uri GenerateUrl(string method)
        {
            return new Uri(ApiUrl, string.Format("{0}.{1}", method, Format));
        }

        public UsersRest Users { get; private set; }
        public StatusesRest Statuses { get; set; }
        public FriendShipsRest FriendShips { get; set; }
        public T GetObject<T>(string text)
        {
            if (FormatType == ApiFormat.Json)
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(text)))
                {
                    var obj = js.ReadObject(stream);
                    return (T)obj;
                }
            }
            if (FormatType == ApiFormat.Xml)
            {
                text = text.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
                var ms = new DataContractSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
                {
                    var obj = ms.ReadObject(stream);
                    return (T)obj;
                }
            }

            return default(T);
        }
    }

   
}
