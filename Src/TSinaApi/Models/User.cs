using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSinaApi
{
    public class User
    {

        //screen_name: 微博昵称 
        //name: 友好显示名称，如Tim Yang(此特性暂不支持) 
        //province:省份编码（参考省份编码表） 
        //city: 城市编码（参考城市编码表） 
        //location：地址 
        //description: 个人描叙 
        //url: 用户博客地址 
        //profile_image_url: 自定义图像 
        //domain: 用户个性化域名 
        //gender: 性别,m--男，f--女,n--未知 
        //email: 用户邮箱 
        //qq: qq号 
        //msn: msn帐号 
        //followers_count: 粉丝数 
        //friends_count: 关注数 
        //statuses_count: 微博数 
        //favourites_count: 收藏数 
        //created_at: 创建时间 
        //following: 是否已关注(此特性暂不支持) 
        //verified: 加V标示 
        //    /// 用户UID 
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string Name { get; set; }
        public int Province { get; set; }
        public int City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ProfileImageUrl { get; set; }
        public int Domain { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string MSN { get; set; }
        public int FollowersCount { get; set; }
        public int FriendsCount { get; set; }
        public int StatusesCount { get; set; }
        public int FavouritesCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Following { get; set; }
        public bool Verified { get; set; }
        public bool GeoEnabled { get; set; }
        public Status[] Status { get; set; }

    }
}
