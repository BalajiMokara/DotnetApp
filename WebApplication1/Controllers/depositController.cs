using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DALLayer;
using WebApplication1.Models;
using System.Windows.Forms;
namespace WebApplication1.Controllers
{
    public class depositController : Controller
    {
        // GET: deposit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult depositamount(Deposit d) {

          //  MessageBox.Show("here");
            long acid = Convert.ToInt64(Session["accid"]);
            string actype = Convert.ToString(Session["actype"]);
            dbmd d1 = new dbmd();
            SqlDataReader ds = d1.retrieveaccountdetails(acid, actype);
            if(actype=="savings")
            ViewBag.acid = ds["savingsaccountid"];
            else
                ViewBag.acid = ds["currentaccountid"];
            ViewBag.custid = ds["customerId"];
            ViewBag.type = actype;
            ViewBag.balance = ds["balance"];

            return View(d);

        }



        [HttpPost]
        public ActionResult depositamountafterview(Deposit d) {
            dbmd d1 = new dbmd();

            long newbalance=d1.depositmoney(d);
           // MessageBox.Show(Convert.ToString(newbalance));
            ViewBag.acid = d.accid;
            ViewBag.custid =d.custid;
            ViewBag.type = d.actype;
            ViewBag.balance = d.balance;
            ViewBag.newbal = newbalance;
            //ModelState.AddModelError("", "amount deposited sucessfully");
            return View();
            // return RedirectToAction("viewdeposittedamount", "deposit");

        }



    }
}