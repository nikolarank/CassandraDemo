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

            string query = "CREATE KEYSPACE if not exists \"PlanArt2\" WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };";
            session.Execute(query);

            session.Execute("use \"PlanArt2\"");

            //artist table
            query = "CREATE TABLE if not exists \"Artist\" ( email text, city text, firstname text, following list<text>, lastname text, nickname text, \"password\" text, picture text, PRIMARY KEY (email) ) ; ";
            session.Execute(query);

            //festival table
            query = "CREATE TABLE if not exists \"Festival\" ( email text, city text, firstname text, following list<text>, \"password\" text, picture text, PRIMARY KEY (email) ) ;  ";
            session.Execute(query);

            //ArtistFestivalSearch table
            query = "CREATE TABLE if not exists \"ArtistFestivalSearch\" ( email text, firstname text, lastname text, picture text, PRIMARY KEY (email) ) ; ";
            session.Execute(query);

            //SearchByName table
            query = "CREATE TABLE if not exists \"SearchByName\" ( name text, emails list<text>, PRIMARY KEY (name) ) ; ";
            session.Execute(query);

            //Event table
            query = "CREATE TABLE if not exists \"Event\" ( email text, time timestamp, fest_pic text, festival text, PRIMARY KEY (email, time) ) ; ";
            session.Execute(query);

            //Post table
            query = "CREATE TABLE if not exists \"Post\" ( email text, post_id timeuuid, firstname text, images list<text>, lastname text, likes int, profilepic text, \"text\" text, time timestamp, PRIMARY KEY (email, post_id) ) ; ";
            session.Execute(query);




            //artist data
            query = "insert into \"Artist\" JSON '{ \"email\" : \"jeff.mills@gmail.com\", \"city\" : \"London\", \"firstname\" : \"Jeff\", \"following\" : [\"jeff.mills@gmail.com\", \"david.guetta@gmail.com\", \"ellie.goulding@gmail.com\", \"nisville@gmail.com\"], \"lastname\" : \"Mills\", \"nickname\" : \"Jeff\", \"password\" : \"jeff123\", \"picture\" : \"jeffmills.jpg\" }' if not exists;"; 
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"ellie.goulding@gmail.com\", \"city\" : \"London\", \"firstname\" : \"Ellie\", \"following\" : [\"ellie.goulding@gmail.com\"], \"lastname\" : \"Goulding\", \"nickname\" : \"Ellie\", \"password\" : \"ellie123\", \"picture\" : \"llie-goulding.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"wiz.khalifa@gmail.com\", \"city\" : \"LA\", \"firstname\" : \"Wiz\", \"following\" : [\"wiz.khalifa@gmail.com\"], \"lastname\" : \"Khalifa\", \"nickname\" : \"Wiz\", \"password\" : \"wiz123\", \"picture\" : \"wiz.jpg\" }' if not exists;"; 
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"nicky.romero@gmail.com\", \"city\" : \"Amsterdam\", \"firstname\" : \"Nicky\", \"following\" : [\"nicky.romero@gmail.com\"], \"lastname\" : \"Romero\", \"nickname\" : \"Nicky\", \"password\" : \"nicky123\", \"picture\" : \"nicky-romero.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"nina.kraviz@gmail.com\", \"city\" : \"Moscow\", \"firstname\" : \"Nina\", \"following\" : [\"nina.kraviz@gmail.com\"], \"lastname\" : \"Kraviz\", \"nickname\" : \"Nina\", \"password\" : \"nina123\", \"picture\" : \"nina-kraviz.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"city\" : \"Paris\", \"firstname\" : \"David\", \"following\" : [\"david.guetta@gmail.com\", \"exit@gmail.com\", \"coachella@gmail.com\", \"nicky.romero@gmail.com\", \"nina.kraviz@gmail.com\", \"jeff.mills@gmail.com\"], \"lastname\" : \"Guetta\", \"nickname\" : \"David\", \"password\" : \"david123\", \"picture\" : \"David-Guetta.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"rihanna@gmail.com\", \"city\" : \"Barbados\", \"firstname\" : \"Rihanna\", \"following\" : [\"rihanna@gmail.com\"], \"lastname\" : \"Fenti\", \"nickname\" : \"Rihanna\", \"password\" : \"rihanna123\", \"picture\" : \"rihanna.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"snoop.dog@gmail.com\", \"city\" : \"LA\", \"firstname\" : \"Snoop \", \"following\" : [\"snoop.dog@gmail.com\"], \"lastname\" : \"Dogg\", \"nickname\" : \"Snoop \", \"password\" : \"snoop123\", \"picture\" : \"snoop-dogg.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"bon.jovi@gmail.com\", \"city\" : \"New York City\", \"firstname\" : \"Bon\", \"following\" : [\"bon.jovi@gmail.com\"], \"lastname\" : \"Jovi\", \"nickname\" : \"Bon\", \"password\" : \"bon123\", \"picture\" : \"Jon-Bon.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"nick.cave@gmail.com\", \"city\" : \"Warracknabeal\", \"firstname\" : \"Nick\", \"following\" : [\"nick.cave@gmail.com\"], \"lastname\" : \"Cave\", \"nickname\" : \"Nick\", \"password\" : \"nick123\", \"picture\" : \"Nick-Cave.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Artist\" JSON ' { \"email\" : \"black.coffie@gmail.com\", \"city\" : \"Cape Town\", \"firstname\" : \"Black\", \"following\" : [\"black.coffie@gmail.com\"], \"lastname\" : \"Coffee\", \"nickname\" : \"Black\", \"password\" : \"black123\", \"picture\" : \"blackcoffee.jpg\" }' if not exists;";
            session.Execute(query);

            //festival data
            query = "insert into \"Festival\" JSON '{ \"email\" : \"glastonbury@gmail.com\", \"city\" : \"Glastonbury\", \"firstname\" : \"Glastonbury\", \"following\" : [\"glastonbury@gmail.com\"], \"password\" : \"glastonbury123\", \"picture\" : \"glastonbury.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Festival\" JSON ' { \"email\" : \"coachella@gmail.com\", \"city\" : \"Indio\", \"firstname\" : \"Coachella\", \"following\" : [\"coachella@gmail.com\", \"david.guetta@gmail.com\", \"exit@gmail.com\", \"rihanna@gmail.com\", \"nina.kraviz@gmail.com\", \"nicky.romero@gmail.com\", \"nisville@gmail.com\", \"wiz.khalifa@gmail.com\"], \"password\" : \"coachella123\", \"picture\" : \"Coachella.JPG\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Festival\" JSON ' { \"email\" : \"exit@gmail.com\", \"city\" : \"Novi Sad\", \"firstname\" : \"Exit\", \"following\" : [\"exit@gmail.com\", \"coachella@gmail.com\", \"david.guetta@gmail.com\", \"nicky.romero@gmail.com\", \"nina.kraviz@gmail.com\", \"nick.cave@gmail.com\"], \"password\" : \"exit123\", \"picture\" : \"exit.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Festival\" JSON ' { \"email\" : \"nisville@gmail.com\", \"city\" : \"Nis\", \"firstname\" : \"Nisville\", \"following\" : [\"nisville@gmail.com\"], \"password\" : \"nisville123\", \"picture\" : \"nisville.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Festival\" JSON ' { \"email\" : \"ultramusic@gmail.com\", \"city\" : \"Singapore\", \"firstname\" : \"Ultra Music Festival\", \"following\" : [\"ultramusic@gmail.com\"], \"password\" : \"ultramusic123\", \"picture\" : \"ultra.jpg\" }' if not exists;";
            session.Execute(query);

            //ArtistFestivalSearch data
            query = "insert into \"ArtistFestivalSearch\" JSON '{ \"email\" : \"glastonbury@gmail.com\", \"firstname\" : \"Glastonbury\", \"lastname\" : null, \"picture\" : \"glastonbury.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"jeff.mills@gmail.com\", \"firstname\" : \"Jeff\", \"lastname\" : \"Mills\", \"picture\" : \"jeffmills.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"ellie.goulding@gmail.com\", \"firstname\" : \"Ellie\", \"lastname\" : \"Goulding\", \"picture\" : \"llie-goulding.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"coachella@gmail.com\", \"firstname\" : \"Coachella\", \"lastname\" : null, \"picture\" : \"Coachella.JPG\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"exit@gmail.com\", \"firstname\" : \"Exit\", \"lastname\" : null, \"picture\" : \"exit.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"wiz.khalifa@gmail.com\", \"firstname\" : \"Wiz\", \"lastname\" : \"Khalifa\", \"picture\" : \"wiz.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"nisville@gmail.com\", \"firstname\" : \"Nisville\", \"lastname\" : null, \"picture\" : \"nisville.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"nicky.romero@gmail.com\", \"firstname\" : \"Nicky\", \"lastname\" : \"Romero\", \"picture\" : \"nicky-romero.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"nina.kraviz@gmail.com\", \"firstname\" : \"Nina\", \"lastname\" : \"Kraviz\", \"picture\" : \"nina-kraviz.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"firstname\" : \"David\", \"lastname\" : \"Guetta\", \"picture\" : \"David-Guetta.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"rihanna@gmail.com\", \"firstname\" : \"Rihanna\", \"lastname\" : \"Fenti\", \"picture\" : \"rihanna.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"snoop.dog@gmail.com\", \"firstname\" : \"Snoop\", \"lastname\" : \"Dog\", \"picture\" : \"snoop-dogg.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"ultramusic@gmail.com\", \"firstname\" : \"Ultra Music Festival\", \"lastname\" : null, \"picture\" : \"ultra.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"bon.jovi@gmail.com\", \"firstname\" : \"Bon\", \"lastname\" : \"Jovi\", \"picture\" : \"Jon-Bon.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"nick.cave@gmail.com\", \"firstname\" : \"Nick\", \"lastname\" : \"Cave\", \"picture\" : \"Nick-Cave.jpg\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"ArtistFestivalSearch\" JSON ' { \"email\" : \"black.coffie@gmail.com\", \"firstname\" : \"Black\", \"lastname\" : \"Coffee\", \"picture\" : \"blackcoffee.jpg\" }' if not exists;";
            session.Execute(query);

            //SearchByName data
            query = "insert into \"SearchByName\" JSON '{ \"name\" : \"David\", \"emails\" : [\"david.guetta@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Bon\", \"emails\" : [\"bon.jovi@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Wiz\", \"emails\" : [\"wiz.khalifa@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Nina\", \"emails\" : [\"nina.kraviz@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Ellie\", \"emails\" : [\"ellie.goulding@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Coachella\", \"emails\" : [\"coachella@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Exit\", \"emails\" : [\"exit@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Black\", \"emails\" : [\"black.coffie@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Jeff\", \"emails\" : [\"jeff.mills@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Ultra Music Festival\", \"emails\" : [\"ultramusic@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Nick\", \"emails\" : [\"nick.cave@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Rihanna\", \"emails\" : [\"rihanna@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Snoop \", \"emails\" : [\"snoop.dog@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Glastonbury\", \"emails\" : [\"glastonbury@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Nicky\", \"emails\" : [\"nicky.romero@gmail.com\"] }' if not exists;";
            session.Execute(query);
            query = "insert into \"SearchByName\" JSON ' { \"name\" : \"Nisville\", \"emails\" : [\"nisville@gmail.com\"] }' if not exists;";
            session.Execute(query);

            //Event data
            query = "insert into \"Event\" JSON '{ \"email\" : \"david.guetta@gmail.com\", \"time\" : \"2017-01-10T19:30:00Z\", \"fest_pic\" : \"Coachella.JPG\", \"festival\" : \"Coachella\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Event\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"time\" : \"2017-01-14T19:20:00Z\", \"fest_pic\" : \"glastonbury.jpg\", \"festival\" : \"Glastonbury\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Event\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"time\" : \"2017-01-31T09:10:00Z\", \"fest_pic\" : \"ultra.jpg\", \"festival\" : \"Ultra Music Festival\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Event\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"time\" : \"2017-08-18T12:14:00Z\", \"fest_pic\" : \"exit.jpg\", \"festival\" : \"Exit\" }' if not exists;";
            session.Execute(query);

            //Post data
            query = "insert into \"Post\" JSON '{ \"email\" : \"jeff.mills@gmail.com\", \"post_id\" : \"89f387a5-dfa5-11e6-be41-a375660ad5aa\", \"firstname\" : \"Jeff\", \"images\" : [\"dj_jeff_mills.jpg\"], \"lastname\" : \"Mills\", \"likes\" : 0, \"profilepic\" : \"jeffmills.jpg\", \"text\" : \"@ work\", \"time\" : \"2017-01-21T06:47:55.841Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"jeff.mills@gmail.com\", \"post_id\" : \"89f3fdc6-dfa5-11e6-be69-12be02f9122e\", \"firstname\" : \"Jeff\", \"images\" : null, \"lastname\" : \"Mills\", \"likes\" : 0, \"profilepic\" : \"jeffmills.jpg\", \"text\" : \"coffee time\", \"time\" : \"2017-01-21T06:47:55.844Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"coachella@gmail.com\", \"post_id\" : \"dcdab992-dfa6-11e6-aec9-c27a504e8000\", \"firstname\" : \"Coachella\", \"images\" : [\"coa.jpg\", \"landscape-1460484627-coachella-2015-street-style-144.jpg\"], \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"Coachella.JPG\", \"text\" : \"last night\", \"time\" : \"2017-01-21T06:57:24.426Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"coachella@gmail.com\", \"post_id\" : \"dcdb5672-dfa6-11e6-b000-b72c60eb9bc9\", \"firstname\" : \"Coachella\", \"images\" : null, \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"Coachella.JPG\", \"text\" : \"record is broken\", \"time\" : \"2017-01-21T06:57:24.43Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"coachella@gmail.com\", \"post_id\" : \"dcdc1971-dfa6-11e6-9a3d-c1d384eacfb0\", \"firstname\" : \"Coachella\", \"images\" : null, \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"Coachella.JPG\", \"text\" : \"see u next year\", \"time\" : \"2017-01-21T06:57:24.435Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"exit@gmail.com\", \"post_id\" : \"9e952b61-dfa6-11e6-a32b-0f1005af57c2\", \"firstname\" : \"Exit\", \"images\" : null, \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"exit.jpg\", \"text\" : \"thanks david\", \"time\" : \"2017-01-21T06:55:39.952Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"exit@gmail.com\", \"post_id\" : \"dcd4fb6e-dfa6-11e6-aa54-252528dfce56\", \"firstname\" : \"Exit\", \"images\" : [\"910x630_summer-of-love_.jpg\", \"hp-slider_lineup_en.jpg\"], \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"exit.jpg\", \"text\" : \"lineup 2017\", \"time\" : \"2017-01-21T06:57:24.388Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"exit@gmail.com\", \"post_id\" : \"dcd5bf02-dfa6-11e6-9a81-6340ebcd7c5d\", \"firstname\" : \"Exit\", \"images\" : null, \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"exit.jpg\", \"text\" : \"new stage soon\", \"time\" : \"2017-01-21T06:57:24.393Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"wiz.khalifa@gmail.com\", \"post_id\" : \"89f646d1-dfa5-11e6-aed5-48319c34fcad\", \"firstname\" : \"Wiz\", \"images\" : [\"Wiz_Site_Updates_ReplaceBop_Images_ONIFC.jpg\"], \"lastname\" : \"Khalifa\", \"likes\" : 0, \"profilepic\" : \"wiz.jpg\", \"text\" : \"celebration\", \"time\" : \"2017-01-21T06:47:55.859Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"wiz.khalifa@gmail.com\", \"post_id\" : \"dcd2c460-dfa6-11e6-9031-459d1d34603d\", \"firstname\" : \"Wiz\", \"images\" : null, \"lastname\" : \"Khalifa\", \"likes\" : 0, \"profilepic\" : \"wiz.jpg\", \"text\" : \"tomorrow england\", \"time\" : \"2017-01-21T06:57:24.374Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"nisville@gmail.com\", \"post_id\" : \"325aec05-dfa6-11e6-9f5f-a8a9eeda6a39\", \"firstname\" : \"Nisville\", \"images\" : null, \"lastname\" : \"\", \"likes\" : 0, \"profilepic\" : \"nisville.jpg\", \"text\" : \"thank you joss stone\", \"time\" : \"2017-01-21T06:52:38.376Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"nisville@gmail.com\", \"post_id\" : \"9e87148a-dfa6-11e6-baf7-615f156b69c4\", \"firstname\" : \"Nisville\", \"images\" : [\"nis.jpg\"], \"lastname\" : \"\", \"likes\" : 2, \"profilepic\" : \"nisville.jpg\", \"text\" : \"beautiful night\", \"time\" : \"2017-01-21T06:55:39.859Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"nicky.romero@gmail.com\", \"post_id\" : \"325c606d-dfa6-11e6-8baa-1dcdbdb87c35\", \"firstname\" : \"Nicky\", \"images\" : null, \"lastname\" : \"Romero\", \"likes\" : 0, \"profilepic\" : \"nicky-romero.jpg\", \"text\" : \"new album soon\", \"time\" : \"2017-01-21T06:52:38.385Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"nicky.romero@gmail.com\", \"post_id\" : \"dcd3e953-dfa6-11e6-be16-57ac28e72bba\", \"firstname\" : \"Nicky\", \"images\" : [\"tuluz.jpg\"], \"lastname\" : \"Romero\", \"likes\" : 0, \"profilepic\" : \"nicky-romero.jpg\", \"text\" : \"Toulouse\", \"time\" : \"2017-01-21T06:57:24.381Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"nina.kraviz@gmail.com\", \"post_id\" : \"89f24f5c-dfa5-11e6-8a00-1baf0e3e6da9\", \"firstname\" : \"Nina\", \"images\" : null, \"lastname\" : \"Kraviz\", \"likes\" : 0, \"profilepic\" : \"nina-kraviz.jpg\", \"text\" : \"good morning people\", \"time\" : \"2017-01-21T06:47:55.833Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"nina.kraviz@gmail.com\", \"post_id\" : \"89f2eb86-dfa5-11e6-8416-fa571ccf9644\", \"firstname\" : \"Nina\", \"images\" : [\"nina-kraviz (1).jpg\"], \"lastname\" : \"Kraviz\", \"likes\" : 0, \"profilepic\" : \"nina-kraviz.jpg\", \"text\" : \"mixing\", \"time\" : \"2017-01-21T06:47:55.837Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"post_id\" : \"0f960ee7-dfa4-11e6-8aac-5636ef7cd365\", \"firstname\" : \"David\", \"images\" : [\"david_guetta_2-exit2016.jpg\", \"dexit.jpeg\"], \"lastname\" : \"Guetta\", \"likes\" : 0, \"profilepic\" : \"David-Guetta.jpg\", \"text\" : \"Lets go exit\", \"time\" : \"2017-01-21T06:37:21.05Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"post_id\" : \"0f972048-dfa4-11e6-9e80-1040dd07e5fe\", \"firstname\" : \"David\", \"images\" : null, \"lastname\" : \"Guetta\", \"likes\" : 0, \"profilepic\" : \"David-Guetta.jpg\", \"text\" : \"Hello my fans\", \"time\" : \"2017-01-21T06:37:21.057Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"post_id\" : \"89efa3ac-dfa5-11e6-aa8d-208f91e632ac\", \"firstname\" : \"David\", \"images\" : null, \"lastname\" : \"Guetta\", \"likes\" : 4, \"profilepic\" : \"David-Guetta.jpg\", \"text\" : \"amazing night @Coachella\", \"time\" : \"2017-01-21T06:47:55.816Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"david.guetta@gmail.com\", \"post_id\" : \"89f02b26-dfa5-11e6-96b8-75116aa04860\", \"firstname\" : \"David\", \"images\" : null, \"lastname\" : \"Guetta\", \"likes\" : 0, \"profilepic\" : \"David-Guetta.jpg\", \"text\" : \"Hello my fans\", \"time\" : \"2017-01-21T06:47:55.819Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"rihanna@gmail.com\", \"post_id\" : \"a6408e93-dfa4-11e6-930a-d76ebe3d5a26\", \"firstname\" : \"Rihanna\", \"images\" : [\"2014+MTV+Movierihanna.jpg\", \"mtv-rihanna.jpg\", \"Rihanna+Arrivals+MTV+Movie+Awards+Part+3+hhHXLGnVsFEl.jpg\"], \"lastname\" : \"Fenti\", \"likes\" : 0, \"profilepic\" : \"rihanna.jpg\", \"text\" : \"MTV awards\", \"time\" : \"2017-01-21T06:41:33.825Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"rihanna@gmail.com\", \"post_id\" : \"a6412aea-dfa4-11e6-a141-223b7a447307\", \"firstname\" : \"Rihanna\", \"images\" : null, \"lastname\" : \"Fenti\", \"likes\" : 0, \"profilepic\" : \"rihanna.jpg\", \"text\" : \"perfect night!\", \"time\" : \"2017-01-21T06:41:33.829Z\" }' if not exists;";
            session.Execute(query);
            query = "insert into \"Post\" JSON ' { \"email\" : \"rihanna@gmail.com\", \"post_id\" : \"a641c701-dfa4-11e6-ab1f-276279bceec2\", \"firstname\" : \"Rihanna\", \"images\" : [\"rihanna-759.jpg\"], \"lastname\" : \"Fenti\", \"likes\" : 0, \"profilepic\" : \"rihanna.jpg\", \"text\" : \"Paris\", \"time\" : \"2017-01-21T06:41:33.833Z\" }' if not exists;";
            session.Execute(query);
        }
    }
}