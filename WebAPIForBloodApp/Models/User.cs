using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIForBloodApp.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfLastDonation { get; set; }

        public int? BloodTypeID { get; set; }
        [ForeignKey("BloodTypeID")]        
        public virtual BloodType BloodType { get; set; }


    }
}