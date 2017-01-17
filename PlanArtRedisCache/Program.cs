using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisDataLayer;
using PlanArtRedisCache.Data_Layer;
using PlanArt.Data_Access;
using PlanArt.QueryEntities;

namespace PlanArtRedisCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Artist a = Artists.GetArtist("justin.biber@gmail.com");
            PostsCache.LoadToRedis(a.email, a.following);

            PostsCache.GetFromRedis(a.email, 0, 15);
        }
    }
}
