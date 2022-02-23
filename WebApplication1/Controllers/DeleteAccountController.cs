using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;

namespace WebApplication1.Controllers
{
    public class DeleteAccountController : Controller
    {
        // GET: DeleteAccount
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(DeleteAccount c)
        {
            if (ModelState.IsValid)
            {
                DALLayer.dalayer d = new DALLayer.dalayer();
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