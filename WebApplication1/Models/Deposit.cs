using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Deposit
    {
        
        [Display(Name = "Customer Id")]
        public long custid{get;set;}
        
        //[Required(ErrorMessage = "Please Enter Id")]
        [Display(Name = "AccountId")]
        public long accid { get; set; }

        //[Required(ErrorMessage = "Please Enter Id")]
        [Display(Name = "Account Type")]
        public string actype { get; set; }

        [Display(Name = "Balance")]
        public long balance { get; set; }

        [Display(Name = "Deposit Amount")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = ".")]
        [Range(0, 10000000, ErrorMessage = "Enter Valid Amount")]
        public long amount { get; set; }
        




    }
}