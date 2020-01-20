﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Bio { get; set; }
        
        public string Email { get; set; }
        
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Minimum Budget")]
        public double MinBudget { get; set; }

        [Display(Name = "Maximum Budget")]
        public double MaxBudget { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
        [NotMapped]
        public List<Concert> events { get; set; }

        public int RateCount //KEEP COMMMED OUT TILL IT GETS WORKING FOR TESTING PURP
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
    }
}