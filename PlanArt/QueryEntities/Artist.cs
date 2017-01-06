using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanArt.QueryEntities
{
    public class Artist
    {
        public string email { get; set; } // 
        public SortedDictionary<string, string> artists { get; set; } //
        public SortedDictionary<DateTime, List<Performance>> calendar { get; set; } //
        public string city { get; set; } //
        public SortedDictionary<string, string> festivals { get; set; } //
        public string lastname { get; set; } //
        public string name { get; set; } //
        public string nickname { get; set; } //    
        public string password { get; set; } //   
    }
}
