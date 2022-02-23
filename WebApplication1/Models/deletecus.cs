using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class deletecus
    {


        [Required(ErrorMessage = "Please Enter Customer ID")]
        [Display(Name = "Customer ID")]
        public string cusID { get; set; }
    }
}