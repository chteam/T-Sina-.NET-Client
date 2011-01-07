namespace TSinaApi
{
    using Models;

    public class UsersRest :RestBase
    {

        public User Show(long id)
        {
            var text = Client.RestApi.Get(
                string.Format("users/show/{0}", id));
            return Client.GetObject<User>(text);
        }
        public User Show(string name)
        {
            var text = Client.RestApi.Get("users/show", new {screen_name = name});
            return Client.GetObject<User>(text);
        }

    }
}
