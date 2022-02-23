using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DALLayer;

namespace WebApplication1.Controllers
{
    public class viewallcustomerController : Controller
    {
        // GET: viewallcustomer
        public ActionResult Index()
        {
            
            return View();
        }

        
        public ActionResult showallcustomer(viewallcustomer MB)
        {
          db_MD d = new db_MD(); //calling class DBdata
            MB.StoreAllData = d.viewAllCustomer();
            return View(MB);
        } 
    }
}