using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanArt.Data_Access;
using ServiceStack.Redis;
using ServiceStack.Text;
using RedisDataLayer;

namespace PlanArtRedisCache.Data_Layer
{
    public class PostsCache
    {
        List<Post> posts;
        readonly RedisClient redis = new RedisClient(Config.SingleHost);

        public void SaveToRedis(string email)
        {
            posts = Posts.Get(email);
            var redisPosts = redis.As<Posts>();
            redisPosts.Save();
        }
    }
}
