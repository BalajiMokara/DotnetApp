using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DeleteAccount1
    {
        [Display(Name = "Enter Customer Id")]
        public int custid { get; set; }
    }
}