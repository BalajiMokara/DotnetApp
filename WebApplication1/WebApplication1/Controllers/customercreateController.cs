using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;

namespace WebApplication1.Controllers
{
    public class customercreateController : Controller
    {
        // GET: customercreate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(customercreate c)
        {
                                                                  
            if (ModelState.IsValid)
            {
                DALLayer.dalayer d = new DALLayer.dalayer();
                int d1 = d.customerinsert(c);
                string result = Convert.ToString(d1);
                if (result != "0")
                {


                    ViewData["result"] = result;
                }
                ModelState.Clear(); //clearing model
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }



    }
}