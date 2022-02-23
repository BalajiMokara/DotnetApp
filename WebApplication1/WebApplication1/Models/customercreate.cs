using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class customercreate
    {
         [Required(ErrorMessage = "Please enter Valid SSNID(Aadhar Number)")]
         [Range(100000000, 999999999, ErrorMessage = "Enter the valid SSNID(Aadhar Number)")]
         [Display(Name = "SSNID")]
         public long ssnid { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use Only Alphabets")]
        [MaxLength(25, ErrorMessage = "Exceeding Limit")]
        [DataType(DataType.Text)]
        public string cname { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Display(Name = "Age")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Age must be a Natural Number")]
        [Range(1, 120, ErrorMessage = "Enter the Valid Age")]
        public int cage { get; set; }

        [Required(ErrorMessage = "Please Enter Temporary Address")]
        [Display(Name = "Temporary Address")]
        [MaxLength(50, ErrorMessage = "Exceeding Limit")]
        public string caline1 { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address")]
        [Display(Name = "Permanent Address")]
        [MaxLength(50, ErrorMessage = "Exceeding Limit")]
        public string caline2 { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        [Display(Name = "State")]
        [MaxLength(20, ErrorMessage = "Exceeding Limit")]
        [DataType(DataType.Text)]
        public string cstate { get; set; }

         [Required(ErrorMessage = "Please Enter City")]
         [Display(Name = "City")]
         [MaxLength(20, ErrorMessage = "Exceeding Limit")]
         [DataType(DataType.Text)]
         public string city { get; set; }
        
        

    }
}