using PlanArt.QueryEntities;
using PlanArt.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanArtMVC.Models
{
    public class ProfileModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string picture { get; set; }
        public string city { get; set; }
        public string firstname { get; set; }
        public List<string> following { get; set; }

        public string lastname { get; set; }
        public string nickname { get; set; }

        public Event newEvent { get; set; }
        public List<Event> events { get; set; }



        public string typo { get; set; }

        public List<SelectListItem> allFestivals = Festivals.GetAllFestivals();


        public string ReturnPicInBase64(string virtualPath, string picName)
        {
            return Picture.ToBase64(virtualPath, picName);
        }
        public ProfileModel()
        {
            events = new List<Event>();
            following = new List<string>();
        }

    }
}