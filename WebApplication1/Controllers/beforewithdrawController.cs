using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;
namespace WebApplication1.Controllers
{
    public class beforewithdrawController : Controller
    {
        // GET: beforewithdraw
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Index(transfer d)
        {
            operations o = new operations();
            if ((Convert.ToString(d.account) == "savings") && (Convert.ToString(d.account1) == "current"))
            {
                if (o.chcksavingsaccountwithactive(d))
                {

                    if (o.chcksourceaccountbalance(d))
                    {
                        o.transfer(d);
                        ModelState.AddModelError("", "Transfer Sucessfull");
                        return View();

                    }
                    else
                    {
                        ModelState.AddModelError("", "Insufficient Funds");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Account not exist");
                    return View();
                }

            }

            else if ((Convert.ToString(d.account) == "current") && (Convert.ToString(d.account1) == "savings"))
            {
                if (o.chcksavingsaccountwithactive(d))
                {
                    if (o.chcksourceaccountbalance(d))
                    {
                        o.transfer(d);
                        ModelState.AddModelError("", "Transfer Successfull");
                        return View();

                    }
                    else
                    {
                        ModelState.AddModelError("", "Insufficient Funds");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Account does not exist");
                    return View();
                }
            }
            else
            {

                if ((Convert.ToString(d.account) == "savings") && (Convert.ToString(d.account1) == "savings"))
                {
                    ModelState.AddModelError("", "Select Different Accounts");
                    return View();
                }

                else if ((Convert.ToString(d.account) == "current") && (Convert.ToString(d.account1) == "current"))
                {
                    ModelState.AddModelError("", "Select Different Accounts");
                    return View();
                }

            }

            /* else if ((Convert.ToString(d.account) == "savings") && (Convert.ToString(d.account1) == "savings"))
             {

                 if ((o.chcksavingsaccountwithactive(d)) && (o.chcksavingsaccountwithactive(d)))
                 {
                     if (o.chcksourceaccountbalance(d))
                     {
                         o.transfer(d);
                         ModelState.AddModelError("", "Transfer Sucessfull");
                         return View();

                     }
                     else
                     {
                         ModelState.AddModelError("", "Insufficinet Funds");
                         return View();
                     }

                 }

                 else
                 {
                     ModelState.AddModelError("", "Account does not exist");
                     return View();
                 }
             }

             else if ((Convert.ToString(d.account) == "current") && (Convert.ToString(d.account1) == "current"))
             {

                 if ((o.chcksavingsaccountwithactive(d)) && (o.chcksavingsaccountwithactive(d)))
                 {
                     if (o.chcksourceaccountbalance(d))
                     {
                         o.transfer(d);
                         ModelState.AddModelError("", "Transfer Sucessfull");
                         return View();

                     }
                     else
                     {
                         ModelState.AddModelError("", "Insufficinet Funds");
                         return View();
                     }
                 }
                 else
                 {
                     ModelState.AddModelError("", "account does not exist");
                     return View();
                 }





                 //return View();
             }*/
            return View();
        }


    }
}