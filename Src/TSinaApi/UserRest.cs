namespace TSinaApi
{
    using Models;

    public class UsersRest :RestBase
    {

        public User Show(string id, long? userId = null, string screenName = null)
        {
            var text = RestApi.Get("users/show/" + id, new {user_id = userId, screen_name = screenName});
            return Client.GetObject<User>(text);
        }

    }
}
