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
        //public int CompanyID { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public int CompanyType { get; set; }
    }
}
