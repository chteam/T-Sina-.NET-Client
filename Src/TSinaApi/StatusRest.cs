namespace TSinaApi
{
    using System.Diagnostics.Contracts;
    using Models;

    public class StatusesRest : RestBase
    {
        public Status Update(string status, string replyTo)
        {
            if (!replyTo.StartsWith("@")) replyTo = replyTo.Insert(0, "@");
            var text = RestApi.Post("statuses/update",
                new { status, in_reply_to_status_id = replyTo });
            return Client.GetObject<Status>(text);
        }

        public Status Update(string status)
        {
            var text = RestApi.Post("statuses/update",new { status });
            return Client.GetObject<Status>(text);
        }

        /// <summary>
        /// 0全部，1原创，2图片，3视频，4音乐
        /// </summary>
        public Statuses FriendsTimeline(long? sinceId = null, long? maxId = null, int page = 1, int count = 20, int feature = 0)
        {
            Contract.Requires(count >= 20 && count <= 200);
            Contract.Requires(feature >= 0 && feature <= 4);
            var text = RestApi.Get(
                "statuses/friends_timeline", new {since_id = sinceId,max_id=maxId, feature, count, page});
            return Client.GetObject<Statuses>(text);
        }

        public Statuses PublicTimeline(int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/public_timeline", new { count });
            return Client.GetObject<Statuses>(text);
        }

        /// <summary>
        /// 0全部，1原创，2图片，3视频，4音乐
        /// </summary>
        public Statuses UserTimeline(long? userId = null, 
            string screenName = null, long? sinceId = null,long? maxId=null, int page = 1, int count = 20, int feature = 0)
        {
            Contract.Requires(count >= 20 && count <= 200);
            Contract.Requires(feature >= 0 && feature <= 4);
            var text = RestApi.Get(
                "statuses/user_timeline", new {since_id = sinceId,max_id=maxId, feature, count, page, user_id = userId, screen_name = screenName});
            return Client.GetObject<Statuses>(text);
        }

        /// <summary>
        /// 获取@当前用户的微博列表
        /// </summary>
        public Statuses Mentions(long? sinceId = null, long? maxId = null, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/mentions", new {since_id = sinceId, max_id = maxId, count, page});
            return Client.GetObject<Statuses>(text);
        }

        /*
         statuses/mentions 获取@当前用户的微博列表 
statuses/comments_timeline 获取当前用户发送及收到的评论列表 
statuses/comments_by_me 获取当前用户发出的评论 
statuses/comments_to_me 获取当前用户收到的评论 
statuses/comments 根据微博消息ID返回某条微博消息的评论列表 
statuses/counts 批量获取一组微博的评论数及转发数 
statuses/repost_timeline 返回一条原创微博的最新n条转发微博信息 New! 
statuses/repost_by_me 返回用户转发的最新n条微博信息 New! 
statuses/unread 获取当前用户未读消息数 
statuses/reset_count 未读消息数清零接口 
emotions 表情接口，获取表情列表 

         */
    }
}
