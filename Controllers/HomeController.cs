using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using AngularJsApp.Models;

namespace AngularJsApp.Controllers
{
    public class HomeController : Controller
    {
        private DBEntities db = new DBEntities();

        //GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
