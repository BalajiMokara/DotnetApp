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
    public class createaccountController : Controller
    {
        // GET: createaccount
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Index(createaccount c) {

           // dalayer d = new dalayer();

           //if (d.chkidexists(c))
           // {
           //     if (d.chkid(c))
           //     {

           //         int rs = d.createaccount(c);
           //         string result = Convert.ToString(rs);
           //         if (result != "0")
           //         {
           //             MessageBox.Show("inside2");

           //             ViewData["result"] = result;
           //         }
           //         ModelState.Clear(); //clearing model
           //                             // return RedirectToAction("Index", "customercreate");
           //         return View();
           //     }
           //     else
           //     {
           //         ViewData["result"] = "dontadd";
           //         return View();

           //     }
           // }
           // else {
           //     ViewData["result1"] = "dontadd";
           //     return View();
           // }

            dalayer d = new dalayer();
           // MessageBox.Show("bgjhj");
            if (d.chkidexists(c))
            {
                if (Convert.ToString(c.select) == "savings")
                {
                    if (d.chck2(c))
                    {
                        int s = d.createsavings(c);
                        
                        string result = Convert.ToString(s);
                        if (result != "0")
                        {


                            ViewData["result"] = result;
                        }
                        //ModelState.AddModelError("", "savings account created sucessfull");
                        ModelState.Clear(); //clearing model
                        ModelState.AddModelError("", "savings account created sucessfully");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Savings Account already existed");
                        return View();
                    }

                }
                /*else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }*/

                else
                {
                    if (d.chck3(c))
                    {
                        int q = d.createcurrent(c);
                        string result = Convert.ToString(q);
                        if (result != "0")
                        {


                            ViewData["result"] = result;
                        }
                        //ModelState.AddModelError("", "current account created sucessfull");
                        ModelState.Clear(); //clearing model
                        ModelState.AddModelError("", "current account created sucessfull");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Current account already existed");
                        return View();
                    }
                }
            }
            ModelState.AddModelError("", "Enter the correct CustomerId");
            //MessageBox.Show("enter correct coustomerid");
            return View();
        }
        

    }
}