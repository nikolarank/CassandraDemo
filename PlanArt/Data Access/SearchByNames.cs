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

        public static void Add(Artist artist)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            Row searchData1 = session.Execute("select * from \"SearchByName\" where \"name\"=" + "'" + artist.firstname + "'").FirstOrDefault();
            RowSet searchData2;
            if (searchData1 == null)
            {
                searchData2 = session.Execute("insert into \"SearchByName\" (\"name\") " + " values ('" + artist.firstname + "');");
                searchData2 = session.Execute("update \"SearchByName\" set emails = ['" + artist.email + "'] where \"name\"='" + artist.firstname + "';");
            }
            else
            {
                searchData2 = session.Execute("update \"SearchByName\" set emails = emails + ['" + artist.email + "'] where \"name\"='" + artist.firstname + "';");
            }       
        }

        public static void Add(Festival festival)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            Row searchData1 = session.Execute("select * from \"SearchByName\" where \"name\"=" + "'" + festival.firstname + "'").FirstOrDefault();
            RowSet searchData2;
            if (searchData1 == null)
            {
                searchData2 = session.Execute("insert into \"SearchByName\" (\"name\") " + " values ('" + festival.firstname + "');");
                searchData2 = session.Execute("update \"SearchByName\" set emails = ['" + festival.email + "'] where \"name\"='" + festival.firstname + "';");
            }
            else
            {
                searchData2 = session.Execute("update \"SearchByName\" set emails = emails + ['" + festival.email + "'] where \"name\"='" + festival.firstname + "';");
            }  
        }

        public static List<string> ReturnByName(string name)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;

            List<string> lista = new List<string>();
            Row searchData = session.Execute("select emails from \"SearchByName\" where \"name\"=" + "'" + name + "'").FirstOrDefault();
            for (int i = 0; i < ((String[])searchData["emails"]).Length; i++)
                lista.Add(((String[])searchData["emails"])[i]);
            return lista;
        }

    }
}
