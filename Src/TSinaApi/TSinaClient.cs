using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSinaApi
{
    public class TSinaClient
    {
        public string ApiUrl { get; private set; }
        public long ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public TSinaClient(long apiKey, string apiSecret)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            Users = new UsersRest(this);
            ApiUrl = "http://api.t.sina.com.cn/";
        }
        public UsersRest Users { get; private set; }
    }
}
