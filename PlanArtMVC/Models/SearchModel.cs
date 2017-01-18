using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlanArt.QueryEntities;

namespace PlanArtMVC.Models
{
    public class SearchModel
    {
        public List<ArtistFestivalSearch> objs { get; set; }
        public List<string> pictures { get; set; }

        public string ReturnPicInBase64(string virtualPath, string picName)
        {
            return Picture.ToBase64(virtualPath, picName);
        }

        public Artist castToArtist()
        {
            return (Artist)HttpContext.Current.Session["user"];
        }

        public Festival castToFestival()
        {
            return (Festival)HttpContext.Current.Session["user"];
        }

        public SearchModel()
        {
            objs = new List<ArtistFestivalSearch>();
            pictures = new List<string>();
        }
    }
}