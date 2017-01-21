using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanArt.QueryEntities
{
    public class Festival
    {
        public string city { get; set; } //
        public string email { get; set; } //
        public string password { get; set; } //
        public string picture { get; set; } //
        public string firstname { get; set; } //   
        public List<string> following;

        public Festival()
        {
            following = new List<string>();
        }

        public Festival(string email, string password, string city, string firstname, string picture)
        {
            this.email = email;
            this.password = password;
            this.city = city;
            this.firstname = firstname;
            this.picture = picture;
            following = new List<string>();
        }

    }
}
