using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIForBloodApp.Models
{
    public class BloodUnit
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [Range(-1, 11)]
        public int NumberOfUnits { get; set; }


        public virtual ICollection<BloodType> BloodTypes { get; set; }


    }
}