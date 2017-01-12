using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanArt.QueryEntities
{
    public class TimeStampConverter
    {
        public static long ConvertToTimeStamp(DateTime value)
        {
            long e = (value.Ticks - 621355968000000000) / 10000;
            return e;
        }
    }
}
