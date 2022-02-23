using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;
using System.Windows.Forms;
using System.Data;
namespace WebApplication1.Controllers
{
    public class CUStomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GetByID para, GetByID a)
        {
            Session["id123"] = para.id.ToString();
            Session["id1234"] = para.id1.ToString();
           db objDB = new db();
            if (Convert.ToString(Session["id123"]) == "CustomerID")
            {
                if (objDB.checkcusid(a))
                {
                    return RedirectToAction("Update");
                }
                else
                {
                    //ModelState.AddModelError("", "Customer Id does not exists");
                   // MessageBox.Show("coustomer does not exist");
                    ViewData["aw1"] = "aw1";
                    return View();
                }
            }
            if (Convert.ToString(Session["id123"]) == "SSNID")
            {
                if (objDB.checkssnid(a))
                {
                    return RedirectToAction("Update");
                }
                else
                {
                   // ModelState.AddModelError("", "Customer Id does not exists");
                    //MessageBox.Show("cust does not exist");
                    ViewData["aw2"] = "aw2";
                    return View();
                }
            }
            return View();
        }
        //public ActionResult customerdetails() // Calling when we first hit controller.
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult customerdetails(Cusdate MB) // Calling on http post (on Submit)
        //{

        //    if (ModelState.IsValid) //checking model is valid or not
        //    {
        //        db objDB = new db(); //calling class DBdata
        //        string result = objDB.InsertData(MB); // passing Value to DBClass from model

        //        ViewData["result"] = result;
        //        ModelState.Clear(); //clearing model
        //        return View();
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Error in saving data");
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult Update(Cusupd cu)
        {
            int c = 0;
            string a = Session["id123"].ToString();
            string b = Session["id1234"].ToString();
            int nb = Convert.ToInt32(b);
            if (a == "SSNID")
                c = 1;
            else
                if (a == "CustomerID")
                    c = 2;

            db objDB = new db();
            int result = objDB.UpdateCustomer(cu, c, nb);
            if (result == 1)
            {
                ViewData["res"] = "ss";
                //MessageBox.Show("update sucessfull");
            }
            else
            {
                ViewData["res1"] = "ss";
                //MessageBox.Show("account is inactive");
            }
            ViewData["result"] = result;
            ModelState.Clear();
            return View();

        }
        public ActionResult Update() // Calling on http post (on Submit)
        {
            db objDB = new db();
            int c = 0;
            string a = Session["id123"].ToString();
            string b = Session["id1234"].ToString();
            int nb = Convert.ToInt32(b);
            if (a == "SSNID")

                c = 1;

            else

                c = 2;

            if (ModelState.IsValid)
            {
                db objDB1 = new db();
                DataSet ds = objDB1.ViewCustomerbyID(nb, c);
                Cusupd PD = new Cusupd();

                PD.cusID = ds.Tables[0].Rows[0]["custid"].ToString();
                PD.cusname = ds.Tables[0].Rows[0]["cname"].ToString();
                PD.age = ds.Tables[0].Rows[0]["cage"].ToString();
                PD.address1 = ds.Tables[0].Rows[0]["caline1"].ToString();
                PD.address2 = ds.Tables[0].Rows[0]["caline2"].ToString();
                PD.city = ds.Tables[0].Rows[0]["city"].ToString();
                PD.state1 = ds.Tables[0].Rows[0]["cstate"].ToString();
                return View(PD);
            }
            else
            {
                MessageBox.Show("Please Enter valid Customer ID");
            }
            return View();
        }


    }
}