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

            //if (ModelState.IsValid)
            //{
            //    Korisnik user = new Korisnik()
            //    {
            //        Ime = model.RegistracijaModel.ImeRegistracija,
            //        Prezime = model.RegistracijaModel.PrezimeRegistracija,
            //        Korisnicko_Ime = model.RegistracijaModel.UsernameRegistracija,
            //        Sifra = model.RegistracijaModel.PasswordRegistracija,
            //        Email = model.RegistracijaModel.EmailRegistracija,
            //        Biografija = "",
            //        Broj_Ocenjivanja = 0,
            //        Rang = 0,
            //        Status = "korisnik",
            //        Korisnik_Plan_Ishranes = null,
            //        Korisnik_Trenings = null,
            //        Korisnik_Uza_Specijalnosts = null,
            //        Moj_Instruktor = null,
            //        Porukas = null,
            //        Porukas1 = null,
            //        Sertifikat_Korisniks = null,
            //        Verifikovan_Nalog = false,
            //        Slika = "unknown-person.jpg",
            //        Zahtev_Za_Instruktora = false
            //    };

            //    Korisnici.Dodaj(user, db);

            //    SendMail(user);
            //    ViewBag.Articles = "one";
            //    return View("RegistracijaVerifikacija");
            //}
            //else
            //{
            //    return View("Registracija", model);
            //}
            if (ModelState.IsValid)
            {
                Festival festival = new Festival(model.EmailRegistracija);
                Festivals.AddFestivalRegistration(festival);
            }



            return View("~/Views/Registration/Registration.cshtml");

        }
	}
}