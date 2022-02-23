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
    public class DeleteAccount2Controller : Controller
    {
        // GET: DeleteAccount2
        public ActionResult deleteaccount()
        {
            return View();
        }


        [HttpPost]
        public ActionResult deleteaccount(deleteaccount d)
        {
           // MessageBox.Show("hyete");
            dalayer s = new dalayer();
            //MessageBox.Show(Convert.ToString(d.account));
            if (Convert.ToString(d.account)=="savings")
            {
                if (s.chckdelesavings(d))
                {
                    if (s.chcksavingsbal(d))
                    {
                        if (s.chcksavingacctstatus(d))
                        {
                            int r = s.deletesavings(d);
                            string result = Convert.ToString(s);
                            if (result != "0")
                            {
                                

                                ViewData["result"] = "ss";
                            }
                           
                            ModelState.AddModelError("", "Deactivated sucessfull");
                            ModelState.Clear(); //clearing model
                            return View();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Account does not exist");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "savings account have the balance");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Enter correct savings account id");
                }
            }
            else
            {
                if (s.chckdeletcurrent(d))
                {
                    if (s.chckcurrentbal(d))
                    {
                        if (s.chckcurrentaccountstatus(d))
                        {
                            int r = s.deletecurrent(d);
                            string result = Convert.ToString(s);
                            if (result != "0")
                            {
                              //  MessageBox.Show(result);

                                ViewData["result"] = "ss";
                            }
                            ModelState.AddModelError("", "Deactivation sucessfull");
                            ModelState.Clear(); //clearing model
                            return View();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Account does not existed");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "current account have the balance");
                    }


                }
                else
                {
                    ModelState.AddModelError("", "Enter correct current account id");
                }
                //return View();
            }
            return View();

        }
    }
}