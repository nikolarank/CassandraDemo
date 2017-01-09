using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using PlanArt.QueryEntities;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Json;

namespace PlanArt.Data_Access
{
    public class SearchByNames
    {
        public static List<string> ReturnAllNamesThatStartsWith(string letters)
        {
            List<string> lista = new List<string>();
            try
            {
                ISession session = SessionManager.GetSession();


                if (session == null)
                    return null;

                RowSet SearchByNameData = session.Execute("select * from \"SearchByName\"");
                if (letters != null && letters != "")
                    foreach (Row data in SearchByNameData)
                    {
                        if (data["name"].ToString().Substring(0, letters.Length) == letters)
                            lista.Add(data["name"].ToString());
                    }
            }
            catch
            {

            }
            

            return lista;
        }
    }
}
