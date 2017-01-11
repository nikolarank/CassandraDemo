using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanArt.Data_Access
{
    public class Post
    {
        public string email { get; set; }
        public DateTime time { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string profilepic { get; set; }
        public string text { get; set; }
        public List<string> images{ get; set; }

        public Post()
        {
            images = new List<string>();
        }

        public Post(string email, string firstname, string lastname, string pic, DateTime time, List<string> images, string text)
        {
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.profilepic = pic;
            this.time = time;
            this.images = images;
            this.text = text;
        }
    }
}
