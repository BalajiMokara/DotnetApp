using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ministatement
    {
        [Required(ErrorMessage ="Please Select Id Type")]
        [Display(Name = "Select")]
        public id_type select { get; set; }

        [Required(ErrorMessage = "Please Enter Id ")]
        [Display(Name = "Id")]
        public long id { get; set; }

        //[Required(ErrorMessage = "Please Select Account Type ")]
        //[Display(Name = "Account Type")]
        //public actype accounttype { get; set; }

        [Required(ErrorMessage = "Please Select Start Date")]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startdate { get; set; }


        [Required(ErrorMessage = "Please Select End Date")]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime enddate { get; set; }

        public DataSet StoreAllData { get; set; }


    }
    public enum id_type {
        select,
        AccountId,
        CustomerId
    }

}