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

        public SearchModel()
        {
            objs = new List<ArtistFestivalSearch>();
            pictures = new List<string>();
        }
    }
}