namespace TSinaApi
{
    using System.Runtime.Serialization;

    [DataContract(Name = "comment")]
    public class Comment
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
        [DataMember(Name = "favorited")]
        public bool Favorited { get; set; }
        [DataMember(Name = "truncated")]
        public bool Truncated { get; set; }
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
        [DataMember(Name = "status")]
        public Status Status { get; set; }
        [DataMember(Name = "reply_comment")]
        public Comment ReplyComment { get; set; }
 
    }
}