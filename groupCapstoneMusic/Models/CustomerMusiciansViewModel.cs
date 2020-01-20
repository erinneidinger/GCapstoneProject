using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public class CustomerMusiciansViewModel
    {
        public List<Musician> musicians { get; set; }

        [Display(Name = "Genre")]
        public string selectGenre { get; set; }

        [Display(Name = "Zipcode")]
        public string selectZipCode { get; set; }

        [Display(Name = "Rate")]
        public string selectRate { get; set; }

        [Display(Name = "City")]
        public string selectCity { get; set; }

        [Display(Name = "State")]
        public string selectState { get; set; }
    }
}