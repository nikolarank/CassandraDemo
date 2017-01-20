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
        public static void Add(Post post)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            string json = JsonConvert.SerializeObject(post.images);
            json = json.Replace("\"", "'");
            RowSet postData = session.Execute("insert into \"Post\" (email, post_id, firstname, lastname, text, profilepic, time, images) " +
                  "  values ('" + post.email + "', " + TimeUuid.NewId().ToString() + ", '" +  post.firstname + "','" + post.lastname + "','" + post.text + "','" + post.profilepic + "','" + (TimeStampConverter.ConvertToTimeStamp(DateTime.Now)).ToString() + "'," + json + ");");
        }

        public static List<Post> Get(string email)
        {
            ISession session = SessionManager.GetSession();;
            List<Post> posts = new List<Post>();
            if (session == null)
                return null;

            RowSet postData = session.Execute("select * from \"Post\" where email =" + "'" + email + "'");

            foreach (Row postRow in postData)
            {
                if (postRow != null)
                {
                    Post post = new Post();
                    post.email = postRow["email"] != null ? postRow["email"].ToString() : string.Empty;
                    post.firstname = postRow["firstname"] != null ? postRow["firstname"].ToString() : string.Empty;
                    post.lastname = postRow["lastname"] != null ? postRow["lastname"].ToString() : string.Empty;
                    post.profilepic = postRow["profilepic"] != null ? postRow["profilepic"].ToString() : string.Empty;
                    post.text = postRow["text"] != null ? postRow["text"].ToString() : string.Empty;
                    post.time = DateTime.Parse(postRow["time"].ToString());
                    post.images = postRow["images"] != null ? ((IEnumerable<string>)postRow["images"]).ToList() : null;
                    posts.Add(post);
                }
                
            }

            return posts;

        }

        public static List<Post> GetToHome(List<string> following)
        {
            ISession session = SessionManager.GetSession();
            List<Post> posts = new List<Post>();
            if (session == null)
                return null;

            if (following != null)
            {
                foreach (string fol in following)
                {
                    posts.AddRange(Get(fol));
                }
            }

            return posts.OrderByDescending(post => post.time).ToList();
        }
    }
}
