using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanArt;
using PlanArtMVC.Models;
using PlanArt.QueryEntities;
using PlanArt.Data_Access;
using PlanArtRedisCache.Data_Layer;

namespace PlanArtMVC.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/
        public ActionResult LogIn()
        {
            LogInModel model = new LogInModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Logovanje(LogInModel model)
        {
            Artist artist = Artists.GetArtist(model.mail);
            Festival festival = Festivals.GetFestival(model.mail);
            HomeModel homeModel = new HomeModel();
            ViewBag.Postovi = new List<Post>();
            if (ModelState.IsValid && ( (artist.password == model.password) || (festival.password == model.password) ))
            {
                if (artist.email != null)
                {
                    Session["status"] = "artist";
                    Session["user"] = artist;
                    if (((Artist)Session["user"]).following == null)
                        ((Artist)Session["user"]).following = new List<string>();
                    homeModel.email = artist.email;
                    homeModel.password = artist.password;
                    homeModel.city = artist.city;
                    homeModel.firstname = artist.firstname;
                    homeModel.calendar = artist.calendar;
                    //homeModel.picture = Picture.ToBase64("~/Content/profilePictures/", artist.picture);
                    homeModel.picture = artist.picture;
                    homeModel.lastname = artist.lastname;
                    homeModel.nickname = artist.nickname;
                    homeModel.following = artist.following;
                    //homeModel.posts = Posts.GetToHome(homeModel.following);
                    //homeModel.posts = Posts.GetToHome(homeModel.following);
                    PostsCache.LoadToRedis(homeModel.email, artist.following);
                    //homeModel.posts = PostsCache.GetFromRedis(homeModel.email, 0, 4);
                    homeModel.posts = PostsCache.GetAllFromRedis(homeModel.email);
                    EventsCache.LoadToRedis(homeModel.email);
                    homeModel.upcoming = EventsCache.GetUpcomingFromRedis(homeModel.email);
                }
                else
                    if (festival.email != null)
                    {
                        Session["status"] = "festival";
                        Session["user"] = festival;
                        if (((Festival)Session["user"]).following == null)
                            ((Festival)Session["user"]).following = new List<string>();
                        homeModel.email = festival.email;
                        homeModel.password = festival.password;
                        homeModel.city = festival.city;
                        homeModel.firstname = festival.firstname;
                        homeModel.calendar = festival.calendar;
                        //homeModel.picture = Picture.ToBase64("~/Content/profilePictures/", festival.picture);
                        homeModel.picture = festival.picture;
                        homeModel.following = festival.following;
                        //homeModel.posts = Posts.GetToHome(homeModel.following);
                        PostsCache.LoadToRedis(homeModel.email, festival.following);
                        //homeModel.posts = PostsCache.GetFromRedis(homeModel.email, 0, 4);
                       homeModel.posts = PostsCache.GetAllFromRedis(homeModel.email);
                        EventsCache.LoadToRedis(homeModel.email);
                        homeModel.upcoming = EventsCache.GetUpcomingFromRedis(homeModel.email);
                }

                return View("~/Views/Home/Home.cshtml", homeModel);
            }
            else
            {
                ViewBag.BadLogin = true;
                return View("LogIn", model);
            }
        }
	}
}