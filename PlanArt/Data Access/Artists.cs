using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;
using Newtonsoft.Json;
using System.Web;

namespace PlanArt.Data_Access
{
    public static class Artists
    {
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
                artist.name = artistData["name"] != null ? artistData["name"].ToString() : string.Empty;
                artist.lastname = artistData["lastname"] != null ? artistData["lastname"].ToString() : string.Empty;
                artist.nickname = artistData["nickname"] != null ? artistData["nickname"].ToString() : string.Empty;
                artist.city = artistData["city"] != null ? artistData["city"].ToString() : string.Empty;
                artist.festivals = (SortedDictionary<string, string>)artistData["festivals"];
                //artist.calendar = (SortedDictionary<DateTime, List<Performance>>)artistData["calendar"];
                artist.artists = (SortedDictionary<string, string>)artistData["artists"];
            }

            return artist;
        }

        public static void AddArtist(Artist artist)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            string fests = JsonConvert.SerializeObject(artist.festivals);
            string cal = JsonConvert.SerializeObject(artist.calendar);
            string artsts = JsonConvert.SerializeObject(artist.artists);

            RowSet hotelData = session.Execute(
                "insert into \"Artist\" (email, name, lastname, nickname, city, festivals, calendar, artists)" +
                "values ('" + artist.email + "','" + artist.name + "','" + artist.lastname + "','" + artist.nickname 
                + "','" + artist.city + "'," + fests + ", " + cal + ", " + artsts); 
        }
    }

}
