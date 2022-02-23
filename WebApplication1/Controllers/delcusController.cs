using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;
using System.Windows.Forms;
namespace WebApplication1.Controllers
{
    public class delcusController : Controller
    {
        // GET: delcus
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult delcusdetails() // Calling when we first hit controller.
        {
            return View();
        }

        [HttpPost]
        public ActionResult delcusdetails(deletecus MB) // Calling on http post (on Submit)
        {
            db objDB = new db();//calling class DBdata
            if (objDB.check7(MB))
            {

                if (ModelState.IsValid) //checking model is valid or not
                {
                    if (objDB.chckaccountswithactive(MB))
                    {
                        //if (objDB.chckbalance(MB))
                        //{
                        //DAL.dalClass1 objDB = new DAL.dalClass1(); //calling class DBdata
                        /*string result = objDB.delcustomer(MB); // passing Value to DBClass from model

                        ViewData["result"] = result;
                        ModelState.Clear(); //clearing model
                        return View();*/

                        //else
                        //{
                        ModelState.AddModelError("", "Balance exist in the account associated with the Customer");
                        return View();
                        //}
                    }
                    else
                    {
                        objDB.deleinaccounts(MB);
                        string result = objDB.delcustomer(MB); // passing Value to DBClass from model
                        ViewData["result"] = result;
                        ModelState.Clear(); //clearing model
                        return View();
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
            }
            else
            {
               // MessageBox.Show("enter a valid customerId");
                ModelState.AddModelError("", "Enter valid Customer id");
                return View();
            }
           
        }

    }
}