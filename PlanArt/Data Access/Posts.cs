using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;
using Newtonsoft.Json;

namespace PlanArt.Data_Access
{
    public class Posts
    {
        
        public static long UnixTimeNow(DateTime time)
        {
            var timeSpan = (time - new DateTime(1970, 1, 1, 0, 0, 0));
            return 1000*(long)timeSpan.TotalSeconds;

        }

        public static void Add(Post post)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            string json = JsonConvert.SerializeObject(post.images);
            json = json.Replace("\"", "'");
        RowSet postData = session.Execute("insert into \"Post\" (email, firstname, lastname, text, profilepic, time, images) " +
              "  values ('" + post.email + "', '" + post.firstname + "','" + post.lastname + "','" + post.text + "','" +  post.profilepic + "','" + (UnixTimeNow(DateTime.Now)).ToString() + "'," + json + ");");
        }

        public static List<Post> Get(string email)
        {
            ISession session = SessionManager.GetSession();
            Post post = new Post();
            List <Post> posts = new List<Post>();
            if (session == null)
                return null;
           
            RowSet postData = session.Execute("select * from \"Post\" where email =" + "'" + email + "'");

            foreach (Row postRow in postData)
            {
                if (postData != null)
                {
                    post.email = postRow["email"] != null ? postRow["email"].ToString() : string.Empty;
                    post.firstname = postRow["firstname"] != null ? postRow["firstname"].ToString() : string.Empty;
                    post.lastname = postRow["lastname"] != null ? postRow["lastname"].ToString() : string.Empty;
                    post.profilepic = postRow["profilepic"] != null ? postRow["profilepic"].ToString() : string.Empty;
                    post.text = postRow["text"] != null ? postRow["text"].ToString() : string.Empty;
                    post.time = DateTime.Parse(postRow["time"].ToString());
                    post.images = (List<string>)JsonConvert.DeserializeObject(postRow["images"].ToString());
                }
                posts.Add(post);
            }

            return posts;

        }
    }
}
