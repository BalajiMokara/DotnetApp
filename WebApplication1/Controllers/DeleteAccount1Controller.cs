using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DALLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DeleteAccount1Controller : Controller
    {
        // GET: DeleteAccount1
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DeleteAccount1 c)
        {
            if (ModelState.IsValid)
            {
                DALLayer.db d = new DALLayer.db();
                int d1 = d.deleteaccount(c);
                string result = Convert.ToString(d1);
                if (result != "0")
                {


                    ViewData["result"] = result;
                }
                ModelState.Clear(); //clearing model
                return RedirectToAction("Index", "UpdateCustomer");
            }
            else
            {
                ModelState.AddModelError("", "Error in Deleting data");
                return View();

            }
        }
    }
}