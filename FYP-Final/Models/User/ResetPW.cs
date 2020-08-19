using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FYP1.Models
{
    public class ResetPW
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter A New Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be 5 characters or more.")]
        public string User_PW_New { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("User_PW_New", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPasswordNew { get; set; }
    }
}
