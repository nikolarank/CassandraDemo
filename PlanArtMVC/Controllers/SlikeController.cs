using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanArt.QueryEntities;
namespace PlanArtMVC.Controllers
{
    public class SlikeController : Controller
    {
        // GET: Slike
        public ActionResult Index()
        {
            return View();
        }

        public string Vrati(string name)
        {
            string slika = Picture.ToBase64("~/Content/profilePictures/", name);
            return slika;
            //return Json(new { items = posts, count = posts.Count() }, JsonRequestBehavior.AllowGet)
        }
    }
}