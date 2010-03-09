using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TSinaApi
{
    public class UsersRest
    {
        private TSinaClient Client { get; set; }

        public UsersRest(TSinaClient tSinaClient)
        {
            Client = tSinaClient;
        }
        public User Show(long id) {
            var text = Client.RestApi.Get(
                string.Format("users/show/{0}.{1}", id, Client.Format), new Dictionary<string,string>{ {"source",Client.ApiKey.ToString()}}, false);
            Console.WriteLine(text);
            return new User();
        }
        public User Show(string name)
        {
            var text = Client.RestApi.Get(
                string.Format("users/show.{1}", Client.Format), new Dictionary<string, string> { 
                { "source", Client.ApiKey.ToString() },
                {"screen_name",name}
                }, false);
            Console.WriteLine(text);
            return new User();
        }
    }
}
