using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace FYP1.Models
{
    public class Event
    {
        public int event_id { get; set; }

        [Required(ErrorMessage = "Please enter event title")]
        [StringLength(45, ErrorMessage = "Maximum 45 characters")]
        public string event_name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [StringLength(450, ErrorMessage = "Maximum 450 characters")]
        public string event_description { get; set; }

        [Required(ErrorMessage = "Please enter venue")]
        [StringLength(50, ErrorMessage = "Maximum 75 characters")]
        public string venue { get; set; }

        [Required(ErrorMessage = "Please select category")]
        public string category { get; set; }

        [Required(ErrorMessage = "Please enter start date & time")]
        public DateTime start_dt { get; set; }

        [Required(ErrorMessage = "Please enter end date & time")]
        public DateTime end_dt { get; set; }

        [Required(ErrorMessage = "Please select group of user to invite")]
        public int CompanyType { get; set; }

        public IFormFile[] document { get; set; }
        public string docName { get; set; }

        public string status { get; set; }

        public string repeat { get; set; }

        [Range(1, 10, ErrorMessage ="No. of occurence should be from 1 to 10")]
        public int occurence { get; set; }
        [Range(1, 10, ErrorMessage = "Repeated should be from 1 to 10")]
        public int repeatOnNo { get; set; }
        public string repeatOnType { get; set; }


    }
}
