using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;


namespace PlanArt.Data_Access
{
    public class Events
    {
        public static void Add(Event e)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet calendarData = session.Execute("insert into \"Event\" (email, time, festival, fest_pic) " +
              "  values ('" + e.email + "', '" + TimeStampConverter.ConvertToTimeStamp(e.datetime) + "','" + e.FestName + "','" + e.FestPic + "');");
        }

        public static List<Event> Get(string email)
        {
            ISession session = SessionManager.GetSession();
            
            List<Event> Events = new List<Event>();
            if (session == null)
                return null;

            RowSet EventData = session.Execute("select * from \"Event\" where email =" + "'" + email + "'");

            foreach (Row EventRow in EventData)
            {

                if (EventRow != null)
                {
                    Event e = new Event();
                    e.email = EventRow["email"] != null ? EventRow["email"].ToString() : string.Empty;
                    e.FestName = EventRow["festival"] != null ? EventRow["festival"].ToString() : string.Empty;
                    e.FestPic = EventRow["fest_pic"] != null ? EventRow["fest_pic"].ToString() : string.Empty;
                    e.datetime = DateTime.Parse(EventRow["time"].ToString());
                    Events.Add(e);
                }
                
            }

            return Events;

        }
    }
}
