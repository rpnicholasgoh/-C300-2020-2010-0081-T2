using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FYP1.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool ForgotPW { get; set; }
    }
}
