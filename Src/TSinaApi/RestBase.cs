namespace TSinaApi
{
    using CHSNS.Rest;

    public class RestBase
    {
        public TSinaClient Client { protected get; set; }
        public RestApi RestApi { get { return Client.RestApi; } }
    }
}