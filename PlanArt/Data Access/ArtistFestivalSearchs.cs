using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;

namespace PlanArt.Data_Access
{
    public class ArtistFestivalSearchs
    {
        public static ArtistFestivalSearch Get(string email)
        {
            ISession session = SessionManager.GetSession();
            ArtistFestivalSearch entity = new ArtistFestivalSearch();

            if (session == null)
                return null;

            Row data = session.Execute("select * from \"ArtistFestivalSearch\" where \"email\"=" + "'" + email + "'").FirstOrDefault();

            if (data != null)
            {
                entity.email = data["email"] != null ? data["email"].ToString() : string.Empty;
                entity.picture = data["picture"] != null ? data["picture"].ToString() : string.Empty;
                entity.firstname = data["firstname"] != null ? data["firstname"].ToString() : string.Empty;
                entity.lastname = data["lastname"] != null ? data["lastname"].ToString() : string.Empty;
            }

            return entity;
        }

        public static void Add(Artist artist)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet searchData = session.Execute("insert into \"ArtistFestivalSearch\" (\"email\", firstname, lastname, picture) " +
                " values ('" + artist.email + "', '" + artist.firstname + "', '" + artist.lastname + "', '" + artist.picture + "');");
        }

        public static void Add(Festival festival)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet searchData = session.Execute("insert into \"ArtistFestivalSearch\" (\"email\", lastname, picture) " +
                " values ('" + festival.email + "', '" + festival.firstname + "', '" + festival.picture + "');");
        }
    }
}
