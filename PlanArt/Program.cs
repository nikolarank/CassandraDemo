using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanArt.Data_Access;
using PlanArt.QueryEntities;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Json;

namespace PlanArt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Artist a = Artists.GetArtist("nikolarank94@gmail.com");
            //Festival b = Festivals.GetFestival("peradetlic");

            SortedDictionary<string, string> artistsDictionary = new SortedDictionary<string, string>();
            artistsDictionary.Add("pera", "govnonja");
            artistsDictionary.Add("krepao", "kotao");
            string artists = JsonConvert.SerializeObject(artistsDictionary);

            SortedDictionary<DateTime, List<Performance>> calendarDictionary = new SortedDictionary<DateTime, List<Performance>>();
            List<Performance> lista = new List<Performance>();
            Performance nastup = new Performance();
            nastup.performanceID = "123";
            lista.Add(nastup);
            calendarDictionary.Add(DateTime.Now, lista);
            string calendar = JsonConvert.SerializeObject(calendarDictionary);

            SortedDictionary<string, string> festivalsDictionary = new SortedDictionary<string, string>();
            festivalsDictionary.Add("12", "LoveFest");
            festivalsDictionary.Add("13", "Exit");
            string festivals = JsonConvert.SerializeObject(festivalsDictionary);
            JsonSerializer s = new JsonSerializer();
            string pomocna = s.Stringify(festivalsDictionary);
            

            Festival f = new Festival("majmundjoka@gmail.com", artists, calendar, "Nis", festivals, "majmun");
            Festivals.AddFestival(f);
        }
    }
}
