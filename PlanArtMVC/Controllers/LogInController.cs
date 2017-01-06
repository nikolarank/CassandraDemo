using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanArt;
using PlanArtMVC.Models;

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
	}
}