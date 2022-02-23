using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cusupd
    {

        [Required(ErrorMessage = "Please Enter Customer ID")]
        [Display(Name = "Customer ID")]
        [MaxLength(9, ErrorMessage = "Exceeding Limit")]
        [MinLength(9, ErrorMessage = "Please Enter valid SSN ID")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Customer ID must be a Number")]
        public string cusID { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name ")]
        [Display(Name = "Customer Name ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer Name must be between 3 and 50 characters!")]
        [RegularExpression(@"^[a-z A-Z ]+$", ErrorMessage = "Please Enter valid Customer Name")]
        public string cusname { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Display(Name = "Age")]
        [MaxLength(2, ErrorMessage = "Exceeding Limit")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Age must be a Number")]
        public string age { get; set; }

        [Required(ErrorMessage = "Please Enter Address Line1 ")]
        [Display(Name = "Address Line1 ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 50 characters!")]
        public string address1 { get; set; }

        [Required(ErrorMessage = "Please Enter Address Line2")]
        [Display(Name = "Address Line2 ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Address be between 3 and 50 characters!")]
        public string address2 { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter valid City")]
        [RegularExpression(@"^[a-z A-Z ]+$", ErrorMessage = "Please enter valid City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        [Display(Name = "State ")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Please enter valid State")]
        [RegularExpression(@"^[a-z A-Z ]+$", ErrorMessage = "Please enter valid State")]
        public string state1 { get; set; }
    


    }
}