namespace TSinaApi
{
    using Models;

    public class StatusesRest : RestBase
    {
        public Status Update(string status, string replyTo)
        {
            if (!replyTo.StartsWith("@"))
                replyTo = replyTo.Insert(0, "@");
            var text = Client.RestApi.Post("statuses/update",
                new { status, in_reply_to_status_id = replyTo });
            return Client.GetObject<Status>(text);
        }
        public Status Update(string status)
        {

            var text = Client.RestApi.Post("statuses/update",
                new { status });
            return Client.GetObject<Status>(text);
        }

        public Statuses FriendsTimeline(long sinceId)
        {
            var text = Client.RestApi.Get(
             "statuses/friends_timeline", new { since_id = sinceId });
            return Client.GetObject<Statuses>(text);
        }
    }
}
