using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DALLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class withdrawController : Controller
    {
        // GET: withdraw
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(withdraw d)
        {
            operations o = new operations();
            if (Convert.ToString(d.account) == "savings")
            {
                if (o.chckwithdrawsavings(d))
                {
                    ModelState.AddModelError("", "savings account exist");
                    Session["accountid"] = d.accountid;
                    Session["account"] = d.account;
                    return RedirectToAction("fetchdetailswithdraw", "withdraw2");
                }
                else
                {
                    ModelState.AddModelError("", "Account Does Not Exists");
                    return View();
                }
            }
            else
            {
                if (o.chckwithdrawcurrent(d))
                {
                    //ModelState.AddModelError("", "current account exist");
                    Session["accountid"] = d.accountid;
                    Session["account"] = d.account;
                    return RedirectToAction("fetchdetailswithdraw", "withdraw2");
                }
                else
                {
                    ModelState.AddModelError("", "Account Does Not Exists");
                    return View();
                }
            }
            
        }
    }
}