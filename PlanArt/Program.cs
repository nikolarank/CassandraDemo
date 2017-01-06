using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanArt.Data_Access;
using PlanArt.QueryEntities;

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

            SortedDictionary<DateTime, List<Performance>> calendarDictionary = new SortedDictionary<DateTime, List<Performance>>();
            List<Performance> lista = new List<Performance>();
            Performance nastup1 = new Performance();
            nastup1.performanceID = "123";
            nastup1.atribut1 = "456";
            nastup1.atribut2 = "789";
            lista.Add(nastup1);
            Performance nastup2 = new Performance();
            nastup2.performanceID = "456";
            nastup2.atribut1 = "123";
            nastup2.atribut2 = "789";
            lista.Add(nastup2);
            calendarDictionary.Add(new DateTime(2017, 5, 1), lista);
            //DateTime t = new DateTime("", );

            SortedDictionary<string, string> festivalsDictionary = new SortedDictionary<string, string>();
            festivalsDictionary.Add("12", "LoveFest");
            festivalsDictionary.Add("13", "Exit");

            Festival f = new Festival("perakojot@gmail.com", artistsDictionary, calendarDictionary, "Nis", festivalsDictionary, "majmun");
            Festivals.AddFestival(f);
        }
    }
}
