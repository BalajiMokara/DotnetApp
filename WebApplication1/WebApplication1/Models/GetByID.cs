using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GetByID
    {
        public options id { get; set; }
        public int id1 { get; set; }
    }

    public enum options {
    Select=0,
        SSNID=1,
        CustomerID=2
    }

}