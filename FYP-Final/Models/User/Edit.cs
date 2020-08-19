using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FYP1.Models
{
    public class Edit
    {
        public string UserName { get; set; }

        public string RepName { get; set; }

        public int Contact_Num { get; set; }

        public string CompanyName { get; set; }

        public string CompanyWebsite { get; set; }

        public string CompanyIndustry { get; set; }

        public string CompanySize { get; set; }

        public string Email { get; set; }

        public int CompanyType { get; set; }
    }
}
