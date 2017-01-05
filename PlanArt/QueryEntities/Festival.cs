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
        public SortedDictionary<string, string> festivals { get; set; } //
        public string name { get; set; } //       
    }
}
