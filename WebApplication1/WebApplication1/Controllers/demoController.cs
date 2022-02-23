using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class demoController : Controller
    {
        // GET: demo
        public ActionResult Index()
        {

            ViewBag.nm= "ayush";
            return View();
        }

        
    }
}