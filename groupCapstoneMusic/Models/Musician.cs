using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public class Musician
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public int Zip { get; set; }

        public string Bio { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Set Rating")]
        public double Rating { get; set; }

        [Display(Name = "Set Rate")]
        public double SetRate { get; set; }

        [Display(Name = "Dates Available")]
        public string DatesAvailable { get; set; }      
    }
}