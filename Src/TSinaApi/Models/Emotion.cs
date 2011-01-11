namespace TSinaApi.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "emotion")]
    public class Emotion
    {
        [DataMember(Name = "phrase")]
        public string Phrase { get; set; }
        /// <summary>
        /// imageΪ��ͨͼƬ���飬magicΪħ������  
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "is_hot")]
        public bool IsHot { get; set; }
        [DataMember(Name = "order_number")]
        public int Order { get; set; }
        /// <summary>
        /// �磺����
        /// </summary>
        [DataMember(Name = "category")]
        public string Category { get; set; }
    }
    public class Emotions : List<Emotion> { }
}