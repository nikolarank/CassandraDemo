using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PlanArtMVC.Models;
using PlanArt.QueryEntities;
using PlanArt.Data_Access;
using PlanArtRedisCache.Data_Layer;

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
                //model.picture = Picture.ToBase64("~/Content/profilePictures/", Path.GetFileName(file.FileName));
                model.picture = file.FileName;
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
                //model.pictures.Add(Picture.ToBase64("~/Content/profilePictures/", ArtistFestivalSearchs.Get(lista[i]).picture));
                model.pictures.Add(ArtistFestivalSearchs.Get(lista[i]).picture);
                model.objs.Add(ArtistFestivalSearchs.Get(lista[i]));        
            }

            return View(model);
        }

        public ActionResult Follow(SearchModel model, string forFollow, string tip)
        {
            if (Session["status"] == "artist")
            {
                if (tip == "1")
                {
                    Artists.Follow(((Artist)Session["user"]).email, forFollow);
                    ((Artist)Session["user"]).following.Add(forFollow);
                }
                else
                {
                    Artists.Unfollow(((Artist)Session["user"]).email, forFollow);
                    ((Artist)Session["user"]).following.Remove(forFollow);
                }                 
            }
            else
            {
                if (tip == "1")
                {
                    Festivals.Follow(((Festival)Session["user"]).email, forFollow);
                    ((Festival)Session["user"]).following.Add(forFollow);
                }                 
                else
                {
                    Festivals.Unfollow(((Festival)Session["user"]).email, forFollow);
                    ((Festival)Session["user"]).following.Remove(forFollow);
                }
                    
            }

            return View("~/Views/Home/Search.cshtml", model);
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
                    lista.Add(file.FileName);
                }
            }

            homeModel.myPost = new PlanArt.Data_Access.Post(homeModel.email, homeModel.firstname, homeModel.lastname, homeModel.picture, DateTime.Now, lista, homeModel.myPost.text);

            homeModel.posts.Add(homeModel.myPost);
            //Posts.Add(homeModel.myPost);
            PostsCache.AddPost(homeModel.myPost);

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

        public ActionResult FetchData(string email, int skipCount, int takeCount)
        {
            List<string> posts = PostsCache.GetFromRedisJSON(email, skipCount, skipCount + takeCount);
            //List<Post> posts = PostsCache.GetFromRedis(email, skipCount, skipCount + takeCount);
            //foreach(Post p in posts)
            //{
            //    p.profilepic = PlanArt.QueryEntities.Picture.ToBase64("~/Content/profilePictures/", p.profilepic);
            //}
            //List<JsonResult> js = new List<JsonResult>();
            //foreach (Post p in posts)
            //{
            //    JsonResult a = Json(
            //        new
            //        {
            //            email = p.email,
            //            firsname = p.firstname,
            //            lastname = p.lastname,
            //            profilepic = p.profilepic,
            //            text = p.text,
            //            time = p.time,
            //            images = p.images
            //        },
            //        JsonRequestBehavior.AllowGet
            //        );
            //    js.Add(a);
            //}
            return Json(new { items = posts, count = posts.Count() }, JsonRequestBehavior.AllowGet);
        }
    }
}