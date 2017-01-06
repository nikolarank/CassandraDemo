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
        //public static Festival GetFestival(string email)
        //{
        //    ISession session = SessionManager.GetSession();
        //    Festival Festival = new Festival();

        //    if (session == null)
        //        return null;

        //    Row FestivalData = session.Execute("select * from \"Festival\" where \"email\"=" + "'" + email + "'").FirstOrDefault();

        //    if (FestivalData != null)
        //    {
        //        Festival.email = FestivalData["email"] != null ? FestivalData["email"].ToString() : string.Empty;
        //        Festival.name = FestivalData["name"] != null ? FestivalData["name"].ToString() : string.Empty;
        //        Festival.city = FestivalData["city"] != null ? FestivalData["city"].ToString() : string.Empty;
        //        Festival.festivals = (SortedDictionary<string, string>)FestivalData["festivals"];
        //        Festival.calendar = (SortedDictionary<DateTime, List<Performance>>)FestivalData["calendar"];
        //        Festival.artists = (SortedDictionary<string, string>)FestivalData["artists"];
        //    }

        //    return Festival;
        //}

        public static void AddFestivalRegistration(Festival festival)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            string email = festival.email;
            string query = "INSERT INTO \"Festival\" JSON '{\"email\":";
            query += "\"" + email + "\"";
            query += "}';";

            RowSet festivalData = session.Execute(query);
        }

        public static void AddFestival(Festival festival)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            string email = festival.email;
            string artists = JsonConvert.SerializeObject(festival.artists);
            string calendar = JsonConvert.SerializeObject(festival.calendar);
            string city = festival.city;
            string festivals = JsonConvert.SerializeObject(festival.festivals);
            string name = festival.name;

            //RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, calendar, city, festivals, name) " +
            //  "  values ('" + festival.email + "', '" + festival.artists + "','" + festival.calendar + "','" + festival.city + "','" + festival.festivals + "','" + festival.name + ");");


            //RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, calendar, city, festivals, name) " +
            //  "  values ('" + festival.email + "','" + festival.artists + "','" + festival.calendar + "','" + festival.city + "','" + festival.festivals + "','" + festival.name + "');");


            //RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, calendar, city, festivals, name) " +
            //  "  values ('" + festival.email + "'," + festival.artists + "," + festival.calendar + ",'" + festival.city + "'," + festival.festivals + ",'" + festival.name + "');");


            //INSERT INTO "Festival" JSON '{"email": "user123456", "calendar": {"2014-10-2 12:10": "0x56"}}';
            string query = "INSERT INTO \"Festival\" JSON '{\"email\":";
            query += "\"" + email + "\", \"artists\":";
            query += artists + ", \"calendar\":";
            query += calendar + ", \"city\":";
            query += "\"" + city + "\", \"festivals\":";
            query += festivals + ", \"name\":";
            query += "\"" + name + "\"";
            query += "}';";

            RowSet festivalData = session.Execute(query);


        }
    }

}
