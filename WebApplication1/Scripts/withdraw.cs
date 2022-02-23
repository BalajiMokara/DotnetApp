using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class withdraw
    {
     [Required]
            public int accountid { get; set; }
            public accounttype account { get; set; }
        }

        public enum accounttype
        {
            savings,current
        }
    }
