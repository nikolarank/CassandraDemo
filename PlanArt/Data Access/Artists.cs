using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

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

            Row artistData = session.Execute("select * from \"artist\" where \"artistID\"=" + email).FirstOrDefault();

            if (artistData != null)
            {
                artist.email = artistData["email"] != null ? artistData["email"].ToString() : string.Empty;
                artist.name = artistData["name"] != null ? artistData["name"].ToString() : string.Empty;
                artist.lastname = artistData["lastname"] != null ? artistData["lastname"].ToString() : string.Empty;
                artist.address = artistData["address"] != null ? artistData["address"].ToString() : string.Empty;
                artist.city = artistData["city"] != null ? artistData["city"].ToString() : string.Empty;
                artist.phone = artistData["phone"] != null ? artistData["phone"].ToString() : string.Empty;
                artist.state = artistData["state"] != null ? artistData["state"].ToString() : string.Empty;
                artist.zip = artistData["zip"] != null ? artistData["zip"].ToString() : string.Empty;
            }

            return artist;
        }
    }
}
