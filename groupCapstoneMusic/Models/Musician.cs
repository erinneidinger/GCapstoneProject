﻿using System;
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

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }

        [Display(Name = "Set Rate")]
        public double SetRate { get; set; }

        [Display(Name = "Dates Available")]
        public string DatesAvailable { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

<<<<<<< HEAD
        public int RateCount
        {
            get { return ratings.Count; }
        }
        public int RateTotal
        {
            get
            {
                return (ratings.Sum(m => m.Rate));
            }
        }
        public virtual ICollection<StarRating> ratings { get; set; }
=======
        public string Lat { get; set; }

        public string Lng { get; set; }
>>>>>>> 00ed503b4220e17509b7fe6752376dc4781e3c32
    }

}