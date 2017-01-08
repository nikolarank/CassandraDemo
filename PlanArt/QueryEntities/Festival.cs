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
        public string password { get; set; } //
        public string picture { get; set; } //
        public SortedDictionary<string, string> festivals { get; set; } //
        public string firstname { get; set; } //       

        public Festival()
        {

        }

        public Festival(string email, string password, string city, string firstname, string picture)
        {
            this.email = email;
            this.password = password;
            this.city = city;
            this.firstname = firstname;
            this.picture = picture;
        }

    }
}
