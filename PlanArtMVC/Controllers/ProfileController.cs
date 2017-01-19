using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanArtMVC.Models;
using PlanArt.QueryEntities;
using PlanArt.Data_Access;
using PlanArtRedisCache.Data_Layer;

namespace PlanArtMVC.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Profile(HomeModel homeModel)
        {
            ProfileModel profileModel = new ProfileModel();
            profileModel.events = EventsCache.GetFromRedis(homeModel.email, 0, 7);
            profileModel.calendar = homeModel.calendar;
            profileModel.city = homeModel.city;
            profileModel.email = homeModel.email;
            profileModel.firstname = homeModel.firstname;
            profileModel.following = homeModel.following;
            profileModel.lastname = homeModel.lastname;
            profileModel.nickname = homeModel.nickname;
            profileModel.password = homeModel.password;
            profileModel.picture = homeModel.picture;

            return View(profileModel);
        }

        public ActionResult Visit(ProfileModel model)
        {
            Artist artist = Artists.GetArtist(model.email);
            Festival festival = Festivals.GetFestival(model.email);
            ProfileModel profileModel = new ProfileModel();
            if (ModelState.IsValid && ((artist.password == model.password) || (festival.password == model.password)))
            {
                if (artist.email != null)
                {
                    Session["status"] = "artist";
                    Session["user"] = artist;
                    profileModel.email = artist.email;
                    profileModel.password = artist.password;
                    profileModel.city = artist.city;
                    profileModel.firstname = artist.firstname;
                    profileModel.calendar = artist.calendar;
                    //profileModel.picture = Picture.ToBase64("~/Content/profilePictures/", artist.picture);
                    profileModel.picture = artist.picture;
                    profileModel.lastname = artist.lastname;
                    profileModel.nickname = artist.nickname;
                    profileModel.following = artist.following;
                    //profileModel.posts = Posts.GetToHome(profileModel.following);
                    //profileModel.posts = Posts.GetToHome(profileModel.following);
                    PostsCache.LoadToRedis(profileModel.email, artist.following);
                    EventsCache.LoadToRedis(profileModel.email);
                }
                else
                    if (festival.email != null)
                {
                    Session["status"] = "festival";
                    Session["user"] = festival;
                    profileModel.email = festival.email;
                    profileModel.password = festival.password;
                    profileModel.city = festival.city;
                    profileModel.firstname = festival.firstname;
                    profileModel.calendar = festival.calendar;
                    //profileModel.picture = Picture.ToBase64("~/Content/profilePictures/", festival.picture);
                    profileModel.picture = festival.picture;
                    profileModel.following = festival.following;
                    //profileModel.posts = Posts.GetToHome(profileModel.following);
                    PostsCache.LoadToRedis(profileModel.email, festival.following);
                    EventsCache.LoadToRedis(profileModel.email);
                }

                return View("~/Views/Profile/Profile.cshtml", profileModel);
            }
            else
            {
                return View();
            }
        }
    }
}