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
            Artist artist = Artists.GetArtist(model.Mail);
            //Korisnik user = Korisnici.Procitaj(model.LogInModel.UsernameLogIn, db);
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid && artist != null && artist.password == model.Password)
            {
                //Session["user"] = user;
                //Session["Id"] = user.KorisnikID;
                //Session["Username"] = user.Korisnicko_Ime;
                //Session["Status"] = user.Status;
                //Session["Ime"] = user.Ime;
                //Session["Instruktor"] = user.Moj_Instruktor;
                HomeModel homeModel = new HomeModel();
                homeModel.name = artist.name;
                homeModel.nickname = artist.nickname;
                homeModel.lname = artist.lastname;
                homeModel.password = artist.password;
                homeModel.city = artist.city;
                homeModel.calendar = artist.calendar;
                homeModel.festivals = artist.festivals;
                homeModel.artists = artist.artists;


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