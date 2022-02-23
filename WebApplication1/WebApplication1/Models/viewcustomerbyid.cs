using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class viewcustomerbyid
    {

        [Display(Name ="Customer Id")]
        [Required(ErrorMessage ="Please enter id")]
        public int cid { get; set; }



    }
}