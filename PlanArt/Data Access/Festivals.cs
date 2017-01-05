using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;

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

        public static void AddFestival(Festival festival)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;


            //RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, calendar, city, festivals, name) " +
            //  "  values ('" + festival.email + "', '" + festival.artists + "','" + festival.calendar + "','" + festival.city + "','" + festival.festivals + "','" + festival.name + ");");


            //RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, calendar, city, festivals, name) " +
            //  "  values ('" + festival.email + "','" + festival.artists + "','" + festival.calendar + "','" + festival.city + "','" + festival.festivals + "','" + festival.name + "');");


            //RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, calendar, city, festivals, name) " +
            //  "  values ('" + festival.email + "'," + festival.artists + "," + festival.calendar + ",'" + festival.city + "'," + festival.festivals + ",'" + festival.name + "');");



            RowSet festivalData = session.Execute("insert into \"Festival\" (\"email\", artists, city, festivals, name) " +
              "  values ('majmundjoka@gmail.com', {'pera':'govnonja', 'krepao':'kotao'}, 'Nis', {'12':'LoveFest', '13':'Exit'}, 'majmun');");


        }
    }

}
