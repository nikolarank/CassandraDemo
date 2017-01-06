using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanArt.QueryEntities
{
    public class Festival
    {
        public SortedDictionary<string, string> artists { get; set; } //
        public SortedDictionary<DateTime, List<Performance>> calendar { get; set; } //
        public string city { get; set; } //
        public string email { get; set; } //
        public SortedDictionary<string, string> festivals { get; set; } //
        public string name { get; set; } //       

        public Festival()
        {

        }

        public Festival(string email)
        {
            this.email = email;
        }

        public Festival(string email, SortedDictionary<string, string> artists, SortedDictionary<DateTime, List<Performance>> calendar, string city, SortedDictionary<string, string> festivals, string name)
        {
            this.email = email;
            this.artists = artists;
            this.calendar = calendar;
            this.city = city;
            this.festivals = festivals;
            this.name = name;
        }




        //public string artists { get; set; } //
        //public string calendar { get; set; } //
        //public string city { get; set; } //
        //public string email { get; set; } //
        //public string festivals { get; set; } //
        //public string name { get; set; } //       

        //public Festival()
        //{

        //}

        //public Festival(string email, string artists, string calendar, string city, string festivals, string name)
        //{
        //    this.email = email;
        //    this.artists = artists;
        //    this.calendar = calendar;
        //    this.city = city;
        //    this.festivals = festivals;
        //    this.name = name;
        //}
    }
}
