using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DALLayer;
using WebApplication1.Models;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WebApplication1.Controllers
{
    public class viewallcustomer1Controller : Controller
    {
        // GET: viewallcustomer1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult showallcustomer1(viewallcustomer1 MB)
        {
           // MessageBox.Show("hhhh");
            dbmd d = new dbmd(); //calling class DBdata
            MB.StoreAllData = d.viewAllCustomer();
            return View(MB);
        }


        public ActionResult showcustomerbyid(viewallcustomer1 c) {
           // MessageBox.Show("hiii");
            int cid = Convert.ToInt32(Session["id"]);
           // MessageBox.Show(Convert.ToString(cid));
            dbmd d = new dbmd();
            c.StoreAllData = d.retrievecustdetails(cid);
            return View(c);
}

       
        public ActionResult showaccountbyid(viewaccountbyid c)
        {
             //MessageBox.Show("hiii");
            //int cid = Convert.ToInt32(Session["id"]);
            //MessageBox.Show(Convert.ToString(cid));
            //dbmd d = new dbmd();
            //c.StoreAllData = d.retrieveaccountdetails(c.account,c.account);
            return View();
        }
        
        
        public ActionResult showaccountdetails(viewaccountbyid v) {

            //MessageBox.Show("dbsd");

            operations o = new operations();
            if (o.checkaccountidexists(v))
            {
                SqlDataReader sd = o.retrieveaccountdetails(v);

                if (Convert.ToString(v.account) == "savings")
                    ViewBag.aid = sd["savingsaccountid"];
                else
                    ViewBag.aid = sd["currentaccountid"];
                ViewBag.custid = sd["customerid"];

                ViewBag.bal = sd["balance"];
                ViewBag.ltd = sd["lasttransactiondetails"];


                return View();
            }
            else
            {
              //  MessageBox.Show("coming");

                ModelState.AddModelError("","Account  Id does not exists");
                return View("showaccountbyid");
            }

        }


     




        }



    }
