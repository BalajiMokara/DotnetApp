using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class withdraw2
    {

        [Display(Name = "Customer Id")]
        public int cusid { get; set; }

        [Display(Name = "AccountId")]
        public int accid { get; set; }
        [Display(Name = "Account Type")]

        public string account { get; set; }
        [Display(Name = "Balance")]
        public int bal { get; set; }

        [Required(ErrorMessage="Please Enter Amount")]
        [Display(Name = "Withdraw Amount")]
        [RegularExpression("([1-9][0-9]*)",ErrorMessage=".")]
        [Range(0, 10000000, ErrorMessage = "Enter Valid Amount")]
        public int wd { get; set; }

    }
}