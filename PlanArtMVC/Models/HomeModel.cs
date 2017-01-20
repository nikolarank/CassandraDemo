using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PlanArt.Data_Access;
using PlanArt.QueryEntities;

namespace PlanArtMVC.Models
{
    public class HomeModel
    {
        //zajednicki atributi artista i festivala
        public string email { get; set; }
        public string password { get; set; }
        public string picture { get; set; }
        public string city { get; set; } 
        public string firstname { get; set; }
        public SortedDictionary<DateTime, List<Performance>> calendar { get; set; }
        public List<string> following { get; set; }

        //artist
        public string lastname { get; set; }       
        public string nickname { get; set; }

        //festival
        //...

        public Post myPost { get; set; }
        public List<Post> posts { get; set; }

        public Event upcoming { get; set; }

        public string ReturnPicInBase64(string virtualPath, string picName)
        {
            return Picture.ToBase64(virtualPath, picName);
        }

        public string ReturnPic(string virtualPath, string picName)
        {
            return virtualPath + "\\Content\\profilePictures\\" + picName;
        }

        public HomeModel()
        {
            posts = new List<Post>();
            following = new List<string>();
        }
    }
}

        
          
          
  