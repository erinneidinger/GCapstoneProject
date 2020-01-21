using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Models
{
    public class CustomerMusiciansViewModel
    {
        public List<Musician>musicians { get; set; }

        [Display(Name = "Genre")]
        public string selectGenre { get; set; }

        [Display(Name = "Genre Types")]
        public SelectList ListOfGenres { get; set; }

        [Display(Name = "Zipcode")]
        public string selectZipCode { get; set; }

        [Display(Name = "Rate Per Hour")]
        public string selectRate { get; set; }

        [Display(Name = "Rate Per Hour")]
        public SelectList RateRange { get; set; }

        [Display(Name = "City")]
        public string selectCity { get; set; }

        [Display(Name = "State")]
        public string selectState { get; set; }
    }
}