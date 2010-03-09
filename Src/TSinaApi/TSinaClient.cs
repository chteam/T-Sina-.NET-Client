using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Rest;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace TSinaApi
{
    public class TSinaClient
    {
        public string ApiUrl { get; private set; }
        public long ApiKey { get; set; }
        //public string ApiSecret { get; set; }
        public RestApi RestApi { get; set; }
        public ApiFormat Format { get; set; }
        public TSinaClient(long apiKey,string username,string password)
        {
            ApiKey = apiKey;
            //ApiSecret = apiSecret;
            Users = new UsersRest(this);
            Statuses = new StatusesRest(this);
            ApiUrl = "http://api.t.sina.com.cn/";
            RestApi = new RestApi(ApiUrl)
            {
                Username = username,
                Password = password
            };
            Format = ApiFormat.json;
        }
        public UsersRest Users { get; private set; }
        public StatusesRest Statuses { get; set; }
        public T GetObject<T>(string text)
        {
            if (Format == ApiFormat.json)
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(text)))
                {
                    return (T)js.ReadObject(stream);
                }
            }
            else if (Format == ApiFormat.xml)
            {
                var ms = new XmlSerializer(typeof(T));
                var xr = XmlReader.Create(new StringReader(text));
                return (T)(ms.Deserialize(xr));
            }

            return default(T);
        }
    }
}
