namespace TSinaApi.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "count")]
    public class ResetCount
    {
        [DataMember(Name = "result")]
        public bool Result { get; set; }
    }
}