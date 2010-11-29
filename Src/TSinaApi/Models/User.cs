using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TSinaApi
{
    [DataContract(Name="user")]
    public class User
    {
        /// <summary>
        /// 用户UID 
        /// </summary>
        [DataMember(Name="id")]
        public long Id { get; set; }
        /// <summary>
        ///  screen_name: 微博昵称 
        /// </summary>
        [DataMember(Name="screen_name")]
        public string ScreenName { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name="province")]
        public int Province { get; set; }
        [DataMember(Name="city")]
        public int City { get; set; }
        [DataMember(Name="location")]
        public string Location { get; set; }
        [DataMember(Name="description")]
        public string Description { get; set; }
        [DataMember(Name="url")]
        public string Url { get; set; }
        [DataMember(Name="profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [DataMember(Name="domain")]
        public string Domain { get; set; }
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
        [DataMember(Name="gender")]
        public string Gender { get; set; }
        [DataMember(Name="email")]
        public string Email { get; set; }
        [DataMember(Name="qq")]
        public string QQ { get; set; }
        [DataMember(Name="msn")]
        public string MSN { get; set; }
        [DataMember(Name="followers_count")]
        public int FollowersCount { get; set; }
        [DataMember(Name="friends_count")]
        public int FriendsCount { get; set; }
        [DataMember(Name="statuses_count")]
        public int StatusesCount { get; set; }
        [DataMember(Name="favourites_count")]
        public int FavouritesCount { get; set; }
        [DataMember(Name="created_at")]
        public string CreatedAt { get; set; }
        [DataMember(Name="following")]
        public bool Following { get; set; }
        [DataMember(Name="verified")]
        public bool Verified { get; set; }
        [DataMember(Name="geo_enabled")]
        public bool GeoEnabled { get; set; }
        [DataMember(Name = "status")]
        public Status Status { get; set; }

    }
}
