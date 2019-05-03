using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIForBloodApp.Models
{

    public class BloodType
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(3)]
        public string Type { get; set; }


        public virtual ICollection<User> Users { get; set; }



        public int? BloodUnitID { get; set; }
        [ForeignKey("BloodUnitID")]
        public virtual BloodUnit BloodUnit { get; set; }


    }

}