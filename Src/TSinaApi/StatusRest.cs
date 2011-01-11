namespace TSinaApi
{
    using System.Diagnostics.Contracts;
    using Models;

    public class StatusesRest : RestBase
    {
       
        public Status Update(string status, string replyTo = null, float? lat = null, float? @long = null, string annotations=null)
        {
            Contract.Requires(lat >= -90 && lat <= 90);
            Contract.Requires(@long >= -180 && @long <= 180);
            Contract.Requires(annotations == null || annotations.Length < 512);
            if (replyTo != null && !replyTo.StartsWith("@")) replyTo = replyTo.Insert(0, "@");
            var text = RestApi.Post("statuses/update", new {status, in_reply_to_status_id = replyTo, lat, @long, annotations});
            return Client.GetObject<Status>(text);
        }
        //todo upload pic
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
 
        public Users Friends(long? userId = null, string screenName = null, int cursor = -1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/friends", new { user_id = userId, screen_name = screenName, count, cursor });
            return Client.GetObject<Users>(text);
        }

        public Users Followers(long? userId = null, string screenName = null, int cursor = -1, int count = 20)
        {
            Contract.Requires(count >= 20 && count <= 200);
            var text = RestApi.Get(
                "statuses/followers", new {user_id = userId, screen_name = screenName, count, cursor});
            return Client.GetObject<Users>(text);
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
            var text = RestApi.Get("emotions");
            return Client.GetObject<Emotions>(text);
        }

        /// <summary>
        /// 根据ID获取单条微博消息，以及该微博消息的作者信息。 
        /// </summary>
        public Status Show(long id)
        {
            var text = RestApi.Post("statuses/show/" + id);
            return Client.GetObject<Status>(text);
        }

        public string GetStatusWebUrl(string userId,long id)
        {
            return string.Format("http://api.t.sina.com.cn/{0}/statuses/{1}.json", userId, id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public Status Destroy(long id)
        {
            var text = RestApi.Post("statuses/destroy/" + id);
            return Client.GetObject<Status>(text);
        }

        public Status Repost(long id,string status=null,bool isComment=false)
        {
            var text = RestApi.Post("statuses/repost", new {id, is_comment = isComment ? 1 : 0, status});
            return Client.GetObject<Status>(text);
        }

        public Comment Comment(long id, string comment = null, long? commentId = null)
        {
            var text = RestApi.Post("statuses/comment", new {id, cid = commentId, comment});
            return Client.GetObject<Comment>(text);
        }
        /// <summary>
        /// 回复评论
        /// </summary>
        public Comment Reply(long id, string comment = null, long? commentId = null)
        {
            var text = RestApi.Post("statuses/reply", new {id, cid = commentId, comment});
            return Client.GetObject<Comment>(text);
        }


        public Comment CommentDestroy(long id)
        {
            var text = RestApi.Post("statuses/comment_destroy/" + id);
            return Client.GetObject<Comment>(text);
        }
        public Comments CommentDestroyBatch(params long[] id)
        {
            var text = RestApi.Post("statuses/comment/destroy_batch", new {ids = string.Join(",", id)});
            return Client.GetObject<Comments>(text);
        }
    }
}
