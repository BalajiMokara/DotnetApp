using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class viewallcustomer
    {
        
        public int cid { get; set; }

        public long ssnid { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; } 

        public DataSet StoreAllData { get; set; } 








    }
}