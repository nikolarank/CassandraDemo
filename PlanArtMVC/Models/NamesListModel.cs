using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanArtMVC.Models
{
    public class NamesListModel
    {
        public List<string> ListOfNames { get; set; }

        public string letters { get; set; }

        public NamesListModel()
        {
            ListOfNames = new List<string>();
        }
    }
}