using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Predeposit
    {
        [Required(ErrorMessage = "Please Enter Id")]
        [Display(Name = "AccountId")]
         public long accountid { get; set; }
        
        [Required(ErrorMessage = "Please Select Account Type")]
        [Display(Name = "Account Type")]
        public actype select { get; set; }

    }

    public enum actype { 
    savings,current
    }
}