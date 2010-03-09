using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSinaApi
{
    public class Status
    {
        /// <summary>
        /// created_at: 创建时间 
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// id: 微博ID 
        /// </summary>
        public int Id { get; set; }
        //text：微博信息内容 
        public string Text { get; set; }
        //source: 微博来源 
        public string Source { get; set; }
        //favorited: 是否已收藏 
        public bool Favorited { get; set; }
        //truncated: 是否被截断 
        public bool Truncated { get; set; }
        //in_reply_to_status_id: 回复ID 
        public int InReplyToStatusId { get; set; }
        //in_reply_to_user_id: 回复人UID 
        public int InReplyToUserId { get; set; }
        //in_reply_to_screen_name: 回复人昵称 
        public string InReplyToScreenName { get; set; }
        //thumbnail_pic: 缩略图 
        public string ThumbnailPic { get; set; }
        //bmiddle_pic: 中型图片 
        public string BMiddlePic { get; set; }
        //original_pic：原始图片 
        public string OriginalPic { get; set; }
        //user: 作者信息 
        public User User { get; set; }
        //retweeted_status: 转发的博文，内容为status，如果不是转发，则没有此字段 
        public Status RetweetedStatus { get; set; }
    }
}
