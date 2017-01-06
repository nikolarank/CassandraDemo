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
        public string mail { get; set; }
        public string name{ get; set; }
        public string lname { get; set; }
        public string nickname { get; set; }
        public string city { get; set; }
        public string password { get; set; }
        public SortedDictionary<string, string> artists { get; set; }
        public SortedDictionary<DateTime, List<Performance>> calendar { get; set; }
        public SortedDictionary<string, string> festivals { get; set; }
    }
}