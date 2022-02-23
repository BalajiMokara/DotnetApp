using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class transfer
    {

        [Required(ErrorMessage ="Please Select Account ")]
        [Display(Name = "Source Account")]
        public int sourceaccount { get; set; }

        [Required(ErrorMessage = "Please Select Account Type ")]
        [Display(Name = "Account Type")]
        public accounttype account { get; set; }
        
        [Required(ErrorMessage = "Please Select Account ")]
        [Display(Name = "Target Account")]
        public int targetaccount { get; set; }

        [Required(ErrorMessage = "Please Select Account Type ")]
        [Display(Name = "Account Type")]
        public accounttype account1 { get; set; }

        [Required(ErrorMessage = "Please Enter Transfer Amount")]
        [Display(Name = "Transfer Amount")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numbers")]
        [Range(1, 10000000, ErrorMessage = "Enter Valid Amount")]
        public int tframt { get; set; }
    }
}