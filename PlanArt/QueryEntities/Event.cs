using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanArt.QueryEntities
{
    public class Event
    {
        public string email { get; set; } 
        public DateTime datetime { get; set; }
        public string FestName { get; set; }
        public string FestPic { get; set; }

        public Event()
        {

        }

        public Event(string email, DateTime datetime, string FestName, string FestPic)
        {
            this.email = email;
            this.datetime = datetime;
            this.FestName = FestName;
            this.FestPic = FestPic;
        }
    }
}
