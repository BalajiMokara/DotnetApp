using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class viewaccountbyid
    {

        [Display(Name = "Account Id")]
        [Required(ErrorMessage = "Please enter id")]
        public int cid { get; set; }

        [Display(Name = "Account Type")]
        [Required(ErrorMessage = "Please Select Account Type")]
        public accounttype account { get; set; }



  }
    

    public class viewaccountbyid1 {

        public int aid { get; set; }

        public long custid { get; set; }

        //public string name { get; set; }

        public int balance { get; set; }

        //public string address { get; set; }

        //public string city { get; set; }

        public DateTime lasttransaction { get; set; }

        public DataSet StoreAllData { get; set; }

    


    
    }

}