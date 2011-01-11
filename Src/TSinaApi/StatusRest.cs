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
        /// <summary>
        /// 获取当前用户发送及收到的评论列表 
        /// </summary>
        public Comments CommentsTimeline(long? sinceId = null, long? maxId = null, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/comments_timeline", new { since_id = sinceId, max_id = maxId, count, page });
            return Client.GetObject<Comments>(text);
        }
        /// <summary>
        /// 获取当前用户发出的评论 
        /// </summary>
        public Comments CommentsByMe(long? sinceId = null, long? maxId = null, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/comments_by_me", new { since_id = sinceId, max_id = maxId, count, page });
            return Client.GetObject<Comments>(text);
        }
        /// <summary>
        /// 获取当前用户收到的评论 
        /// </summary>
        public Comments CommentsToMe(long? sinceId = null, long? maxId = null, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/comments_to_me", new { since_id = sinceId, max_id = maxId, count, page });
            return Client.GetObject<Comments>(text);
        }

        /// <summary>
        /// 根据微博消息ID返回某条微博消息的评论列表 
        /// </summary>
        public Comments Comments(long id, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/comments", new { id, count, page });
            return Client.GetObject<Comments>(text);
        }
        /// <summary>
        /// 批量获取一组微博的评论数及转发数
        /// </summary>
        public Counts Counts(params long[] id)
        {
            Contract.Requires(id.Length > 0);
            var text = RestApi.Get(
                "statuses/counts", new { id = string.Join(",", id) });
            return Client.GetObject<Counts>(text);
        }

        /// <summary>
        /// 返回一条原创微博的最新n条转发微博信息 New! 
        /// </summary>
        public Statuses RepostTimeline(long id,long? sinceId = null, long? maxId = null, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/repost_timeline", new { id, since_id = sinceId, max_id = maxId, count, page });
            return Client.GetObject<Statuses>(text);
        }
        /// <summary>
        /// 返回用户转发的最新n条微博信息 New! 
        /// </summary>
        public Statuses RepostByMe(long id, long? sinceId = null, long? maxId = null, int page = 1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/repost_by_me", new { id, since_id = sinceId, max_id = maxId, count, page });
            return Client.GetObject<Statuses>(text);
        }
        /// <summary>
        /// 获取当前用户未读消息数
        /// </summary>
        public UnRead UnRead(long? sinceId = null, bool withNewStatus = false)
        {
            var text = RestApi.Get(
                "statuses/unread", new {since_id = sinceId, with_new_status = withNewStatus ? 0 : 1});
            return Client.GetObject<UnRead>(text);
        }

        /// <summary>
        /// 未读消息数清零接口
        /// 1. 评论数，2. @me数，3. 私信数，4. 关注数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ResetCount(int type)
        {
            var text = RestApi.Post("statuses/reset_count", new {type});
            return Client.GetObject<ResetCount>(text).Result;
        }

        public Emotions Emotions()
        {
            var text = RestApi.Get("statuses/emotions");
            return Client.GetObject<Emotions>(text);
        }
    }
}
