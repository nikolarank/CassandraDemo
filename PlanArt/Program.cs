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

            //SortedDictionary<string, string> artistsDictionary = new SortedDictionary<string, string>();
            //artistsDictionary.Add("misko", "pisko");
            //artistsDictionary.Add("sakil", "onil");

            //SortedDictionary<DateTime, List<Performance>> calendarDictionary = new SortedDictionary<DateTime, List<Performance>>();
            //List<Performance> lista = new List<Performance>();
            //Performance nastup1 = new Performance();
            //nastup1.performanceID = "1asasa";
            //nastup1.atribut1 = "dsdsd";
            //nastup1.atribut2 = "dffdf";
            //lista.Add(nastup1);
            //Performance nastup2 = new Performance();
            //nastup2.performanceID = "rere";
            //nastup2.atribut1 = "trtrr";
            //nastup2.atribut2 = "ytyty";
            //lista.Add(nastup2);
            //calendarDictionary.Add(new DateTime(2017, 5, 1), lista);
            ////DateTime t = new DateTime("", );

            //SortedDictionary<string, string> festivalsDictionary = new SortedDictionary<string, string>();
            //festivalsDictionary.Add("12", "LoveFest");
            //festivalsDictionary.Add("13", "Exit");

            //Festival f = new Festival("sanantonio@gmail.com", artistsDictionary, calendarDictionary, "Nis", festivalsDictionary, "majmun");
            //Festivals.AddFestival(f);
            //Festivals.GetFestival("perakojot@gmail.com");
            List<string> slike = new List<string>();
            slike.Add("prva");
            slike.Add("druga");
            slike.Add("treca");
            //Post p = new Post("exitf@gmail.com", "exit", null, "exit.jpg", new DateTime(2017, 5, 6), slike, "ovo je neki post");
            //Posts.Add(p);

            //List<Post> lp = Posts.Get("exitf@gmail.com");

            Event e = new Event("calvin.harris@gmail.com", new DateTime(2017, 6, 8, 15, 30, 0, DateTimeKind.Local), "Exit", "exit.jpg");
            //Event e2 = new Event("calvin.harris@gmail.com", new DateTime(2017, 8, 8, 15, 30, 0, DateTimeKind.Local), "LoveFest", "LoveFest.jpg");
            //Events.Add(e);
            //Events.Add(e2);

            //Events.Get("calvin.harris@gmail.com");

            //Post p = new Post();
            //Post p = new Post("exitf@gmail.com", "exit", null, "exit.jpg", new DateTime(2017, 5, 6), slike, "ovo je neki drugi");
            //Posts.Add(p);

            Posts.Get("exitf@gmail.com");
        }
    }
}
