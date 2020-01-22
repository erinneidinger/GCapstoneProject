using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Models
{
    public class FilterViewModel
    {
        public List<Musician>musicians { get; set; }

        [Display(Name = "Genre")]
        public string SelectedGenre { get; set; }

        [Display(Name = "Genre Types")]
        public SelectList ListOfGenres { get; set; }
    }
}