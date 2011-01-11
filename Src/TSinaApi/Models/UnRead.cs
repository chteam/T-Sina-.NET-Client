namespace TSinaApi.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "count")]
    public class UnRead
    {
        [DataMember(Name = "comments")]
        public long Comments { get; set; }
        [DataMember(Name = "followers")]
        public long Followers { get; set; }
        /// <summary>
        /// �ἰ�ҵ���״̬
        /// </summary>
        [DataMember(Name = "new_status")]
        public long NewStatus { get; set; }
        /// <summary>
        /// ��˽��
        /// </summary>
        [DataMember(Name = "dm")]
        public long Message { get; set; }
        /// <summary>
        /// �·�˿
        /// </summary>
        [DataMember(Name = "mentions")]
        public long Mentions { get; set; }
    }
}