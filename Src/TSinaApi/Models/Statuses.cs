namespace TSinaApi
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

   // [DataContract(Name = "statuses")]
    public class Statuses : List<Status>
    {
         //[DataMember(Name = "status")]
        //public List<Status> Status { get; set; }
    }
}