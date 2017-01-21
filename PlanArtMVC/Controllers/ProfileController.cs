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

        public ActionResult AddEvent(ProfileModel profileModel, DateTime datum, DateTime vreme)
        {
            DateTime tmp = datum.Date.Add(vreme.TimeOfDay);
            Festival f = Festivals.GetFestival(profileModel.newEvent.FestName); //festname je zapravo mail
            Event e = new Event(((Artist)Session["user"]).email, tmp, f.firstname, f.picture);
            profileModel.newEvent.email = e.email;
            profileModel.newEvent.datetime = e.datetime;
            profileModel.newEvent.FestName = e.FestName;
            profileModel.newEvent.FestPic = e.FestPic;
            profileModel.events.Add(e);
            Events.Add(e);
            return View("~/Views/Profile/Profile.cshtml", profileModel);
        }
    }
}