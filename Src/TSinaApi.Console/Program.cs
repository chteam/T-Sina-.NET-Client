﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSinaApi.Client;

namespace TSinaApi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TSinaClient client = new TSinaClient(ClientKey.AppKey,"chsword@126.com","xxx");
            var user = client.Users.Show(1660678232);
            //client.Users.Show("重典");
           var status= client.Statuses.Update("Live Id 的问题还没解决。。。一天了。。。");
            System.Console.Read();
        }
    }
}
