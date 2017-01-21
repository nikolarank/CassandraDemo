using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace PlanArt
{
    public static class CreateKeySpace
    {
        public static void Create()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect();

            string query = "CREATE KEYSPACE if not exists \"PlanArt\" WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };";
            session.Execute(query);

            session.Execute("use \"PlanArt\"");

            //artist
            query = "CREATE TABLE if not exists \"Artist\" ( email text, city text, firstname text, following list<text>, lastname text, nickname text, \"password\" text, picture text, PRIMARY KEY (email) ) ; ";
            session.Execute(query);

            //festival
            query = "CREATE TABLE if not exists \"Festival\" ( email text, city text, firstname text, following list<text>, \"password\" text, picture text, PRIMARY KEY (email) ) ;  ";
            session.Execute(query);

            //ArtistFestivalSearch
            query = "CREATE TABLE if not exists \"ArtistFestivalSearch\" ( email text, firstname text, lastname text, picture text, PRIMARY KEY (email) ) ; ";
            session.Execute(query);

            //SearchByName
            query = "CREATE TABLE if not exists \"SearchByName\" ( name text, emails list<text>, PRIMARY KEY (name) ) ; ";
            session.Execute(query);

            //Event
            query = "CREATE TABLE if not exists \"Event\" ( email text, time timestamp, fest_pic text, festival text, PRIMARY KEY (email, time) ) ; ";
            session.Execute(query);

            //Post
            query = "CREATE TABLE if not exists \"Post\" ( email text, post_id timeuuid, firstname text, images list<text>, lastname text, likes int, profilepic text, \"text\" text, time timestamp, PRIMARY KEY (email, post_id) ) ; ";
            session.Execute(query);
        }
    }
}