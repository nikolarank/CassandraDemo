using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanArtMVC.Models;
using PlanArt.Data_Access;
using PlanArt.QueryEntities;

namespace PlanArtMVC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: /Registracija/
        public ActionResult Registration()
        {
            RegistrationModel model = new RegistrationModel();
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                string email = model.email;
                string password = model.password;
                string city = model.city;
                string firstname = model.firstname;

                if (model.status == "Artist")
                {
                    string lastname = model.lastname;
                    string nickname = model.nickname;

                    Artist artist = new Artist(email, password, city, firstname, lastname, nickname, "unknown-person.jpg");
                    Artists.Add(artist);
                    SearchByNames.Add(artist);
                    Artists.Follow(email, email);
                }
                else
                {
                    Festival festival = new Festival(email, password, city, firstname, "unknown-person.jpg");
                    Festivals.Add(festival);
                    SearchByNames.Add(festival);
                    Festivals.Follow(email, email);
                }     
         
                return View("~/Views/LogIn/LogIn.cshtml");
            }
            else
            {
                return View("Registration", model);
            }
        }
	}
}