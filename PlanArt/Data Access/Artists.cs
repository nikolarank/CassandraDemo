using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;

namespace PlanArt.Data_Access
{
    public static class Artists
    {
        //registracija, dodajemo: email, password, city, firstname, lastname, nickname
        public static void Add(Artist artist)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            //string email = artist.email;
            //string query = "INSERT INTO \"Artist\" JSON '{\"email\":";
            //query += "\"" + email + "\"";
            //query += "}';";

            RowSet artistData = session.Execute("insert into \"Artist\" (\"email\", password, city, firstname, lastname, nickname, picture) " +
              "  values ('" + artist.email + "', '" + artist.password + "','" + artist.city + "','" + artist.firstname + "','" + artist.lastname + "','" + artist.nickname + "','" + artist.picture + "');");
        }

        public static Artist GetArtist(string email)
        {
            ISession session = SessionManager.GetSession();
            Artist artist = new Artist();

            if (session == null)
                return null;

            Row artistData = session.Execute("select * from \"Artist\" where \"email\"=" + "'" + email + "'").FirstOrDefault(); 

            if (artistData != null)
            {
                artist.email = artistData["email"] != null ? artistData["email"].ToString() : string.Empty;
                artist.password = artistData["password"] != null ? artistData["password"].ToString() : string.Empty;
                artist.picture = artistData["picture"] != null ? artistData["picture"].ToString() : string.Empty;
                artist.firstname = artistData["firstname"] != null ? artistData["firstname"].ToString() : string.Empty;
                artist.lastname = artistData["lastname"] != null ? artistData["lastname"].ToString() : string.Empty;
                artist.nickname = artistData["nickname"] != null ? artistData["nickname"].ToString() : string.Empty;
                artist.city = artistData["city"] != null ? artistData["city"].ToString() : string.Empty;
                artist.calendar = (SortedDictionary<DateTime, List<Performance>>)artistData["calendar"];
                artist.following = artistData["following"] != null ? ((IEnumerable<string>)artistData["following"]).ToList() : null;
            }

            return artist;
        }

        public static void ChangeProfilePicture(string picture, string email)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            RowSet artistData = session.Execute("update \"Artist\" set picture =" + "'" + picture + "' where \"email\"=" + "'" + email + "'");
        }

        public static void Follow(string emailSend, string emailRec)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            RowSet artistData = session.Execute("update \"Artist\" set following = following + ['" + emailRec + "'] where \"email\"='" + emailSend + "';");
        }

        public static void Unfollow(string emailSend, string emailRec)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            RowSet artistData = session.Execute("update \"Artist\" set following = following - ['" + emailRec + "'] where \"email\"='" + emailSend + "';");
        }

    }

}
