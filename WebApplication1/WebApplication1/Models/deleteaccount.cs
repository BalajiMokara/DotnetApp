using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class deleteaccount
    {


        [Required(ErrorMessage="Please Enter Account Id")]
        [Display(Name = "Account Id")]
        public int accountid { get; set; }

        [Required(ErrorMessage="Please Select Account Type")]
        [Display(Name = "Select")]
        public acctype account { get; set; }
    }
    
public enum acctype
{  savings,
    current}
    
}