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
            Artist a = Artists.GetArtist("artist.email");

            Artists.AddArtist(a);
        }
    }
}
