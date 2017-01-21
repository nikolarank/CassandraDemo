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
            RowSet postData = session.Execute("insert into \"Post\" (email, post_id, firstname, lastname, likes, text, profilepic, time, images) " +
                  "  values ('" + post.email + "', " + TimeUuid.NewId().ToString() + ", '" +  post.firstname + "','" + post.lastname + "'," + post.likes + ",'" + post.text + "','" + post.profilepic + "','" + (TimeStampConverter.ConvertToTimeStamp(DateTime.Now)).ToString() + "'," + json + ");");
        }

        public static void Delete(string id, string email)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            System.Guid guid = System.Guid.Parse(id);
            TimeUuid cuid = guid; 
            RowSet Data = session.Execute("delete from \"Post\" where \"post_id\"=" + cuid + " and email ='" + email + "';");
        }

        public static void Like(string id, string email)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            System.Guid guid = System.Guid.Parse(id);
            TimeUuid cuid = guid; 
            Row likes = session.Execute("select * from \"Post\" where post_id = " + cuid + " allow filtering").FirstOrDefault();
            int count = int.Parse(likes["likes"].ToString());
            count++;
            RowSet artistData = session.Execute("update \"Post\" set likes = " + count + " where \"post_id\"=" + cuid + " and email ='" + email + "';");

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
                    post.likes = postRow["likes"] != null ? int.Parse(postRow["likes"].ToString()) : 0;
                    post.firstname = postRow["firstname"] != null ? postRow["firstname"].ToString() : string.Empty;
                    post.lastname = postRow["lastname"] != null ? postRow["lastname"].ToString() : string.Empty;
                    post.profilepic = postRow["profilepic"] != null ? postRow["profilepic"].ToString() : string.Empty;
                    post.text = postRow["text"] != null ? postRow["text"].ToString() : string.Empty;
                    post.time = DateTime.Parse(postRow["time"].ToString());
                    post.images = postRow["images"] != null ? ((IEnumerable<string>)postRow["images"]).ToList() : null;
                    post.post_id = postRow["post_id"].ToString();
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
