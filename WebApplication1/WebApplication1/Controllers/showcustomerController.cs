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
    public class showcustomerController : Controller
    {
        // GET: showcustomer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(viewcustomerbyid v)
        {
          //  MessageBox.Show("hhhh");
            dbmd d = new dbmd();
            if (d.chkidexists(v.cid))
            {
                Session["id"] = v.cid;
                return RedirectToAction("showcustomerbyid", "viewallcustomer1");

            }
            else
            {
                ViewData["qw"] = "d";
                return View();
            }


        }
    }
}