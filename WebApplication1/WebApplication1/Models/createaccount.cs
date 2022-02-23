using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class createaccount
    {

        [Required(ErrorMessage="Please Enter Id")]
        [Display(Name = "CustomerId")]
        public int customerid { get; set; }

        [Required(ErrorMessage="Please Enter Amount")]
        [Display(Name = "Amount")]
        [Range(500, 999999999, ErrorMessage = "minimum deposit should be 500")]
        public int amount { get; set; }

        [Required(ErrorMessage = "Please Select Account Type")]
        public accotype select { get; set; }
    }
    public enum accotype { savings, current }



    }
