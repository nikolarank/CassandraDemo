using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanArt;
using PlanArtMVC.Models;
using PlanArt.QueryEntities;
using PlanArt.Data_Access;

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
            if (ModelState.IsValid && ( (artist.password == model.password) || (festival.password == model.password) ))
            {
                if (artist.email != null)
                {
                    Session["status"] = "artist";
                    homeModel.email = artist.email;
                    homeModel.password = artist.password;
                    homeModel.city = artist.city;
                    homeModel.firstname = artist.firstname;
                    homeModel.calendar = artist.calendar;
                    homeModel.picture = Picture.ToBase64(artist.picture);
                    homeModel.lastname = artist.lastname;
                    homeModel.nickname = artist.nickname;
                }
                else
                    if (festival.email != null)
                    {
                        Session["status"] = "festival";
                        homeModel.email = festival.email;
                        homeModel.password = festival.password;
                        homeModel.city = festival.city;
                        homeModel.firstname = festival.firstname;
                        homeModel.calendar = festival.calendar;
                        homeModel.picture = Picture.ToBase64(festival.picture);
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