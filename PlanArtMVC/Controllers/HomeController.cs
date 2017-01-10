using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PlanArtMVC.Models;
using PlanArt.QueryEntities;
using PlanArt.Data_Access;

namespace PlanArtMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeProfilePicture(HttpPostedFileBase file, HomeModel model)
        {
            if (file != null && file.ContentLength > 0)
            {
                if (Session["status"] == "artist")
                {
                    Artists.ChangeProfilePicture(file.FileName, model.email);
                }
                else
                    if (Session["status"] == "festival")
                    {
                        Festivals.ChangeProfilePicture(file.FileName, model.email);
                    }

                string path = Path.Combine(Server.MapPath("~/Content/profilePictures"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                model.picture = Picture.ToBase64(Path.GetFileName(file.FileName));
            }
            return View("~/Views/Home/Home.cshtml", model);
        }

        [HttpPost]
        public JsonResult ReturnSuggestion(NamesListModel model)
        {
            List<string> names = SearchByNames.ReturnAllNamesThatStartsWith(model.letters);
            return Json(names, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Search()
        {
            string ime = Request.Form["tagovi"];
            SearchModel model = new SearchModel();
            List<string> lista = SearchByNames.ReturnByName(ime);
            for (int i = 0; i < lista.Count; i++ )
            {
                model.pictures.Add(Picture.ToBase64(ArtistFestivalSearchs.Get(lista[i]).picture));
                model.objs.Add(ArtistFestivalSearchs.Get(lista[i]));        
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}