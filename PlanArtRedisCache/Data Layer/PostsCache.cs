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
    public static class PostsCache
    {
        readonly static RedisClient redis = new RedisClient(Config.SingleHost);
        static int counter = 0;

        //upisuje u Redis sve postove onih koje pratim
        public static void LoadToRedis(string email, List<string> following)
        {
            if (redis.GetListCount("show_posts_" + email) > 0)
                redis.RemoveAllFromList("show_posts_" + email);
            List<Post> posts = Posts.GetToHome(following);
            var postovi = redis.Lists["show_posts_" + email];


            foreach (Post post in posts)
            {
                postovi.Append(JsonSerializer.SerializeToString(post, typeof(Post)));
            }
            
            //redis.Add<List<Post>>("post", posts);
        }

        public static List<Post> GetAllFromRedis(string email)
        {
            List<Post> posts = new List<Post>();

            foreach (string jsonVisitorString in redis.GetAllItemsFromList("show_posts_" + email))
            {
                Post p = (Post)JsonSerializer.DeserializeFromString(jsonVisitorString, typeof(Post));
                posts.Add(p);
            }

            return posts;
        }

        //cita iz redisa elemente liste iz datog opsega
        public static List<Post> GetFromRedis(string email, int startingFrom, int endingAt)
        {
            //redis.Get<List<Post>>("post");
            //redis.GetAllItemsFromList("show_posts_" + email);

            List<Post> posts = new List<Post>();

            foreach (string jsonVisitorString in redis.GetRangeFromList("show_posts_" + email, startingFrom, endingAt))
            {
                Post p = (Post)JsonSerializer.DeserializeFromString(jsonVisitorString, typeof(Post));
                posts.Add(p);
            }

            return posts;
        }

        public static List<string> GetFromRedisJSON(string email, int startingFrom, int endingAt)
        {
            return redis.GetRangeFromList("show_posts_" + email, startingFrom, endingAt);
        }

        public static void AddPost(Post post)
        {
            var novi = redis.Lists["new_posts"];
            novi.Add(JsonSerializer.SerializeToString(post, typeof(Post)));
            counter++;
            if(counter > 10)
            {
                SaveNewPostsToCassandra();
                counter = 0;
                redis.RemoveAllFromList("new_posts");
            }
        }

        public static void SaveNewPostsToCassandra()
        {
            foreach (string jsonVisitorString in redis.GetAllItemsFromList("new_posts"))
            {
                Post p = (Post)JsonSerializer.DeserializeFromString(jsonVisitorString, typeof(Post));
                Posts.Add(p);
            }

            redis.RemoveAllFromList("new_posts");
        }

    }
}
