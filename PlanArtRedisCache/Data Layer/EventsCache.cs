using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanArt.Data_Access;
using ServiceStack.Redis;
using ServiceStack.Text;
using RedisDataLayer;
using PlanArt.QueryEntities;

namespace PlanArtRedisCache.Data_Layer
{
    public static class EventsCache
    {
        readonly static RedisClient redis = new RedisClient(Config.SingleHost);
        static int counter = 0;

        public static void LoadToRedis(string email)
        {
            List<Event> events = Events.Get(email);
            var Eventi = redis.Lists["show_events_" + email];

            foreach (Event e in events)
            {
                Eventi.Append(JsonSerializer.SerializeToString(e, typeof(Event)));
            }
        }

        public static List<Event> GetFromRedis(string email, int startingFrom, int endingAt)
        {

            List<Event> Events = new List<Event>();

            foreach (string jsonVisitorString in redis.GetRangeFromList("show_events_" + email, startingFrom, endingAt))
            {
                Event e = (Event)JsonSerializer.DeserializeFromString(jsonVisitorString, typeof(Event));
                Events.Add(e);
            }

            return Events;
        }

        public static Event GetUpcomingFromRedis(string email)
        {
            Event e = (Event)JsonSerializer.DeserializeFromString(redis.GetItemFromList("show_events_" + email, 0), typeof(Event));
            return e;
        }

        public static List<string> GetFromRedisJSON(string email, int startingFrom, int endingAt)
        {
            return redis.GetRangeFromList("show_events_" + email, startingFrom, endingAt);
        }

        public static void AddEvent(Event e)
        {
            var novi = redis.Lists["new_events"];
            novi.Add(JsonSerializer.SerializeToString(e, typeof(Event)));
            counter++;
            if (counter > 10)
            {
                SaveNewEventsToCassandra();
                counter = 0;
                redis.RemoveAllFromList("new_events");
            }
        }

        public static void SaveNewEventsToCassandra()
        {
            foreach (string jsonVisitorString in redis.GetAllItemsFromList("new_events"))
            {
                Event e = (Event)JsonSerializer.DeserializeFromString(jsonVisitorString, typeof(Event));
                Events.Add(e);
            }
        }
    }
}
