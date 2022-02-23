using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class homepageController : Controller
    {
        // GET: homepage
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult executive() {


            return View();
        }
        public ActionResult cashier()
        {


            return View();
        }
    }
}