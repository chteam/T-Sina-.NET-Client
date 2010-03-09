using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSinaApi
{
    public class StatusesRest
    {
        private TSinaClient Client { get; set; }

        public StatusesRest(TSinaClient tSinaClient)
        {
            Client = tSinaClient;
        }

        public Status Update(string status, string replyTo)
        {
            if (!replyTo.StartsWith("@"))
                replyTo = replyTo.Insert(0, "@");
            var text = Client.RestApi.Get(
                   string.Format("statuses/update.{0}", Client.Format),
                   new Dictionary<string, string> { 
                   { "source", Client.ApiKey.ToString() },
                   {"status",status},
                   {"in_reply_to_status_id",replyTo}
                   }, true);
            return Client.GetObject<Status>(text);
        }
        public Status Update(string status)
        {
            var text = Client.RestApi.Get(
                   string.Format("statuses/update.{0}", Client.Format),
                   new Dictionary<string, string> { 
                   { "source", Client.ApiKey.ToString() },
                   {"status",status}
                   }, true);
            return Client.GetObject<Status>(text);
        }
    }
}
