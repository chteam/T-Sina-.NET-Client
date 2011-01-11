namespace TSinaApi
{
    using Models;

    public class FriendShipsRest : RestBase
    {

        public User Create(long? userId = null, string screenName = null)
        {
            var text = RestApi.Post(
                "friendships/create", new { user_id = userId, screen_name = screenName});
            return Client.GetObject<User>(text);
        }


        public User Destroy(long? userId = null, string screenName = null)
        {
            var text = RestApi.Post(
                "friendships/destroy", new {user_id = userId, screen_name = screenName});
            return Client.GetObject<User>(text);
        }

        public bool Exists(long userA,long userB)
        {
            var text = RestApi.Get("friendships/exists", new { user_a = userA, user_b = userB });
            return text.Contains("true");
        }
 
    }
}