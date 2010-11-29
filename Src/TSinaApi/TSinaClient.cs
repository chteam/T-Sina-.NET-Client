﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Rest;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

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
            Users = new UsersRest {Client = this};
            Statuses = new StatusesRest { Client = this };
            ApiUrl = "http://api.t.sina.com.cn/";
            RestApi = new RestApi(ApiUrl, new {source = apiKey})
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
                    var obj = js.ReadObject(stream);
                    return (T)obj;
                }
            }
            else if (Format == ApiFormat.xml)
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
