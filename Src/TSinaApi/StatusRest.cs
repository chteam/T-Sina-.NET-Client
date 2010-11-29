namespace TSinaApi
{
    public class StatusesRest : RestBase
    {
        public Status Update(string status, string replyTo)
        {
            if (!replyTo.StartsWith("@"))
                replyTo = replyTo.Insert(0, "@");
            var text = Client.RestApi.Post(
                string.Format("statuses/update.{0}", Client.Format),
                new { status, in_reply_to_status_id = replyTo }
                , true);
            return Client.GetObject<Status>(text);
        }
        public Status Update(string status)
        {

            var text = Client.RestApi.Post(
                string.Format("statuses/update.{0}", Client.Format),
                new { status }, true);
            return Client.GetObject<Status>(text);
        }
    }
}
