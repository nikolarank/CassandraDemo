using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Json;

namespace PlanArt.Data_Access
{
    public static class Festivals
    {
        //registracija, dodajemo: email, password, city, firstname
        public static void Add(Festival festival)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            ////INSERT INTO "Festival" JSON '{"email": "user123456", "calendar": {"2014-10-2 12:10": "0x56"}}';
            //string query = "INSERT INTO \"Festival\" JSON '{\"email\":";
            //query += "\"" + email + "\", \"artists\":";
            //query += artists + ", \"calendar\":";
            //query += calendar + ", \"city\":";
            //query += "\"" + city + "\", \"festivals\":";
            //query += festivals + ", \"name\":";
            //query += "\"" + name + "\"";
            //query += "}';";

            //RowSet festivalData = session.Execute(query);

            RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", password, city, firstname, picture) " +
              "  values ('" + festival.email + "', '" + festival.password + "','" + festival.city + "','" + festival.firstname + "','" + festival.picture + "');");
        }

        public static Festival GetFestival(string email)
        {
            ISession session = SessionManager.GetSession();
            Festival festival = new Festival();

            if (session == null)
                return null;

            Row festivalData = session.Execute("select * from \"Festival\" where \"email\"=" + "'" + email + "'").FirstOrDefault();

            if (festivalData != null)
            {
                festival.email = festivalData["email"] != null ? festivalData["email"].ToString() : string.Empty;
                festival.password = festivalData["password"] != null ? festivalData["password"].ToString() : string.Empty;
                festival.picture = festivalData["picture"] != null ? festivalData["picture"].ToString() : string.Empty;
                festival.firstname = festivalData["firstname"] != null ? festivalData["firstname"].ToString() : string.Empty;
                festival.city = festivalData["city"] != null ? festivalData["city"].ToString() : string.Empty;
                festival.calendar = (SortedDictionary<DateTime, List<Performance>>)festivalData["calendar"];
                festival.following = festivalData["following"] != null ? ((IEnumerable<string>)festivalData["following"]).ToList() : null;
            }

            return festival;
        }

        public static void ChangeProfilePicture(string picture, string email)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            RowSet festivalData = session.Execute("update \"Festival\" set picture =" + "'" + picture + "' where \"email\"=" + "'" + email + "'");
        }

        public static void Follow(string emailSend, string emailRec)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            RowSet festivalData = session.Execute("update \"Festival\" set following = following + ['" + emailRec + "'] where \"email\"='" + emailSend + "';");
        }

        public static void Unfollow(string emailSend, string emailRec)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            RowSet festivalData = session.Execute("update \"Festival\" set following = following - ['" + emailRec + "'] where \"email\"='" + emailSend + "';");
        }

    }

}
