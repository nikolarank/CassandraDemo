using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDemo.QueryEntities
{
    public class Reservation
    {
        public string resID { get; set; }
        public string arrive { get; set; }
        public string depart { get; set; }
        public string hotelID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string rate { get; set; }
        public string roomID { get; set; }
    }
}
