using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIForBloodApp.Models
{
    public class Location
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Address { get; set; }

        public string NameOfFoundation { get; set; }

        public TimeSpan TimeFrom { get; set; }

        public TimeSpan TimeTo { get; set; }

        [Required]
        public DateTime DateOfAction { get; set; }

    }
}