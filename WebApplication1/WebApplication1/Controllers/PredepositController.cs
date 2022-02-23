using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;
namespace WebApplication1.Controllers
{
    public class PredepositController : Controller
    {
        // GET: Predeposit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Predeposit p) {

            dbmd d = new dbmd();
            string atype = Convert.ToString(p.select);


                if (d.chkaccidexists(p.accountid,atype))
                {

                    Session["accid"] = p.accountid;
                    Session["actype"] = p.select;

                    return RedirectToAction("depositamount", "deposit");
                }
                else
                {
                    ModelState.AddModelError("", "Account Id does not exists");
                    return View();

                }

            }
        
           

        
        }



    }
