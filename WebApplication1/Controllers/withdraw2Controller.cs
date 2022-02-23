using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApplication1.DALLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class withdraw2Controller : Controller
    {
        // GET: withdraw2
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult fetchdetailswithdraw(withdraw2 d)
        {
            int acid = Convert.ToInt32(Session["accountid"]);
            string actyp = Convert.ToString(Session["account"]);
            operations o = new operations();
            SqlDataReader dr = o.retriveaccountdetails(acid, actyp);
           // dr.Read();
            if (actyp == "savings")
            {
                ViewBag.acid = dr["savingsaccountid"];
                ViewBag.cid = dr["customerId"];
                ViewBag.actp = actyp;
                ViewBag.bala = dr["balance"];
                return View(d);
            }
            else
            {
                //MessageBox.Show("vvvgv");
                ViewBag.acid = dr["currentaccountid"];
                ViewBag.cid = dr["customerId"];
                ViewBag.actp = actyp;
                ViewBag.bala = dr["balance"];
                return View(d);
            }
            // return View(d);
        }

        [HttpPost]
        public ActionResult viewwithdrawdetails(withdraw2 d)
        {
            operations o = new operations();
            if (Convert.ToString(d.account) == "savings")
            {
                if (o.chcksufficientbalance(d))
                {
                    int s = o.withdraw(d);
                    //o.withdraw(d);
                    //  MessageBox.Show("withdraw sucessfull");
                    ViewBag.cid = d.cusid;
                    ViewBag.acid = d.accid;
                    ViewBag.atype = d.account;
                    ViewBag.pbal = d.bal;
                    ViewBag.nbal = s;

                    return View();
                }
                else
                {
                     //MessageBox.Show("Enter correct amount");
                    //ModelState.AddModelError("","Enter Correct Amount");
                    ViewData["res"] = "1";
                    return RedirectToAction("fetchdetailswithdraw","withdraw2");
                    //return View();
                }
            }
            else
            {
                if (o.chcksufficientbalance(d))
                {
                    int s = o.withdraw(d);
                   // MessageBox.Show("withdraw sucessfull");
                    // return RedirectToAction("afterwithdraw", "withdraw2");
                    ViewBag.cid = d.cusid;
                    ViewBag.acid = d.accid;
                    ViewBag.atype = d.account;
                    ViewBag.pbal = d.bal;
                    ViewBag.nbal = s;

                    return View(d);
                }
                else
                {
                     //MessageBox.Show("Enter correct amount");

                    //ModelState.AddModelError("","Enter Correct Amount");
                    Session["res"] = "1";
                    return RedirectToAction("fetchdetailswithdraw", "withdraw2");
                    // return View();
                }
            }
            
        }

        //[HttpPost]
        //public ActionResult afterwithdraw(withdraw2 d)
        //{
        //   operations o = new operations();
        //int n
        //    ViewBag.acid = d.accid;


        //}


    }
}