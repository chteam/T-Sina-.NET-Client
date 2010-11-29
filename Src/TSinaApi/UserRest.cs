namespace TSinaApi
{
    public class UsersRest :RestBase
    {

        public User Show(long id)
        {
            var text = Client.RestApi.Get(
                string.Format("users/show/{0}.{1}", id, Client.Format),null, true);
            return Client.GetObject<User>(text);
        }
        public User Show(string name)
        {
            var text = Client.RestApi.Get(
                string.Format("users/show.{0}", Client.Format), new {screen_name = name}
                , true);
            return Client.GetObject<User>(text);
        }

    }
}
