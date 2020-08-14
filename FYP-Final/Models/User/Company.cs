using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FYP1.Models
{
    public class Company
    {

        //Company Details 

        //public int CompanyID { get; set; }

        [Required(ErrorMessage = "Please enter Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please enter Company Website")]
        public string CompanyWebsite { get; set; }

        [Required(ErrorMessage = "Please enter Company Industry")]
        public string CompanyIndustry { get; set; }

        [Required(ErrorMessage = "Please indicate number of employees")]
        public string CompanySize { get; set; }

        public int CompanyType { get; set; }

        //Account 
        [Required(ErrorMessage = "Please Enter Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be 5 characters or more.")]
        public string User_PW { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("User_PW", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        //Company Representative

        [Required(ErrorMessage = "Please enter Name")]
        public string RepName { get; set; }
        [Required(ErrorMessage = "Please Enter Contact Number")]
        public int Contact_Num { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

    }
}
