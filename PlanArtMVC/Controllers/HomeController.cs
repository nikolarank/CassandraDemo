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

        public ActionResult Home(HomeModel homeModel)
        {
            return View(homeModel);
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
                model.picture = Picture.ToBase64("~/Content/profilePictures/", Path.GetFileName(file.FileName));
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
                model.pictures.Add(Picture.ToBase64("~/Content/profilePictures/", ArtistFestivalSearchs.Get(lista[i]).picture));
                model.objs.Add(ArtistFestivalSearchs.Get(lista[i]));        
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Post(IEnumerable<HttpPostedFileBase> files, HomeModel homeModel)
        {
            List<string> lista = new List<string>();
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/postedPictures"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    lista.Add(Picture.ToBase64("~/Content/postedPictures/", file.FileName));
                }
            }

            homeModel.myPost = new PlanArt.Data_Access.Post(homeModel.email, homeModel.firstname, homeModel.lastname, homeModel.picture, DateTime.Now, lista, homeModel.myPost.text);
            Posts.Add(homeModel.myPost);

            return View("~/Views/Home/Home.cshtml", homeModel);
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