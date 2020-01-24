﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public double MusicianRating { get; set; }

        public double CustomerRating { get; set; }

        [Display(Name = "Overall Rating")]
        public double AverageCustomerRating { get; set; }

        public List<Concert> gigs { get; set; }

        [NotMapped]
        public List<Concert> events { get; set; }

        [Display(Name = "Profile Photo Url")]
        public string ImageURL { get; set; }

    }
}