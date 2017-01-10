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

        //artist
        public string lastname { get; set; }       
        public string nickname { get; set; } 

        //festival

    }
}

        
          
          
  