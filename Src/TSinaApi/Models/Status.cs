namespace TSinaApi.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "status")]
    public class Status
    {
        /// <summary>
        /// created_at: 创建时间 
        /// </summary>
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// id: 微博ID 
        /// </summary>
        [DataMember(Name = "id")]
        public long Id { get; set; }
        //text：微博信息内容 
        [DataMember(Name = "text")]
        public string Text { get; set; }
        //source: 微博来源 
        [DataMember(Name="source")]
        public string Source { get; set; }
        //favorited: 是否已收藏 
        [DataMember(Name = "favorited")]
        public bool Favorited { get; set; }
        //truncated: 是否被截断 

        [DataMember(Name = "truncated")]
        public bool Truncated { get; set; }
        //in_reply_to_status_id: 回复ID 
        [DataMember(Name = "in_reply_to_status_id")]
        public string InReplyToStatusId { get; set; }
        //in_reply_to_user_id: 回复人UID 
        [DataMember(Name = "in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }
        //in_reply_to_screen_name: 回复人昵称 
        [DataMember(Name = "in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }
        //thumbnail_pic: 缩略图 
        [DataMember(Name = "thumbnail_pic")]
        public string ThumbnailPic { get; set; }
        //bmiddle_pic: 中型图片 
        [DataMember(Name = "bmiddle_pic")]
        public string BMiddlePic { get; set; }
        //original_pic：原始图片 
        [DataMember(Name = "original_pic")]
        public string OriginalPic { get; set; }
        //user: 作者信息 

        [DataMember(Name = "user")]
        public User User { get; set; }
        //retweeted_status: 转发的博文，内容为status，如果不是转发，则没有此字段 
        [DataMember(Name = "retweeted_status")]
        public Status RetweetedStatus { get; set; }
    }
}
