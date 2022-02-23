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
    public class ministatementController : Controller
    {
        // GET: ministatement
        


        public ActionResult getministatement1()
        {
           // MessageBox.Show("inside45");
            return View();
        }

        [HttpPost]
        public ActionResult getministatement1(ministatement m) {
          //  MessageBox.Show("inside2");

            dbmd d = new dbmd();
            if (Convert.ToString(m.select) == "AccountId")
            {
                if (d.accountidexistsinbothtbl(m.id))
                {

                    m.StoreAllData = d.getmini(m);
                    if (m.StoreAllData.Tables[0].Rows.Count>0)
                        return View("getministatement",m);
                    else
                    {
                        ModelState.AddModelError("", "No transaction with this Id");
                        return View("getministatement1");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Account Id does not exists");
                    return View("getministatement1");
                }
            }

            else if(Convert.ToString(m.select) == "CustomerId") {
                if (d.chkidexists(m.id))
                {

                    m.StoreAllData = d.getmini(m);

                    if (m.StoreAllData.Tables[0].Rows.Count > 0)
                        return View("getministatement",m);
                    else
                    {
                        ModelState.AddModelError("", "No transaction with this Id");
                        return View("getministatement1");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Customer does not exists");
                    return View("getministatement1");
                }

            }
            return View();
        }

        public ActionResult getministatement(ministatement m) {
            return View(m);
        }

    }
}