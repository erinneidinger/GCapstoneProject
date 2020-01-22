using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Venue { get; set; }

        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Genre { get; set; }

        public string Audience { get; set; }

        [Display(Name = "Concert Date")]
        public string ConcertDate { get; set; }

        [Display(Name = "Concert Time")]
        public string ConcertTime { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string apiMapCall = PrivateKeys.googleMap;

        [Display(Name ="Confirm")]
        public bool ConfirmationOfMusician { get; set; }

        public string Musician { get; set; } //I will have it grab the musicians band name if confimation of music it true.

    }
}