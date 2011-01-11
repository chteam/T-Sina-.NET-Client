namespace TSinaApi.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    [DataContract(Name = "count")]
    public class Count
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "comments")]
        public long CommentCount { get; set; }
        [DataMember(Name = "rt")]
        public long RtCount { get; set; }
    }

    public class Counts : List<Count> { }
}