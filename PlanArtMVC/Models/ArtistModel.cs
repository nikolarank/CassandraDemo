using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlanArt.QueryEntities;

namespace PlanArtMVC.Models
{
    public class ArtistModel
    {
        public string email { get; set; } // 
        public SortedDictionary<string, string> artists { get; set; } //
        public SortedDictionary<DateTime, List<Performance>> calendar { get; set; } //
        public string city { get; set; } //
        public SortedDictionary<string, string> festivals { get; set; } //
        public string lastname { get; set; } //
        public string firstname { get; set; } //
        public string nickname { get; set; } //    
        public string password { get; set; } //   
        public string picture { get; set; } //   
    }
}