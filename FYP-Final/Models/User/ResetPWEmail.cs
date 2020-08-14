using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FYP1.Models
{
    public class ResetPWEmail
    {

        [Required(ErrorMessage = "Email address does not exist")]
        public string Email { get; set; }
    }
}
