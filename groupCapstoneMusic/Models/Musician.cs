using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Band Name")]
        public string BandName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string Bio { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Selected Genre")]
        public string SelectedGenre { get; set; } //FOR FILTERED SEARCH, not a double, keep

        [Display(Name = "Genre Types")]
        public SelectList ListOfGenres = new SelectList(new List<string> { "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka" }); //FOR FILTERED SEARCH, keep

        public List<Musician> musicians { get; set; } //For Filtered search, keep
        public double MusicianRating { get; set; }

        [Display(Name = "Overall Rating")]
        public double AverageMusicianRating { get; set; }

        public double CustomerRating { get; set; }

        [Display(Name = "Set Rate Per Hour")]
        public double SetRate { get; set; }

        [Display(Name = "Dates Available")]
        public string DatesAvailable { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        [NotMapped]
        public List<StarRating> ratings { get; set; }

        [Display(Name ="YouTube Video Name")]
        public string youtubeVideoName { get; set; }

        public string youtubeSearch { get; set; }

        public string iFrameUrl = "https://www.youtube.com/embed/";

        [Display(Name ="Profile Photo Url")]
        public string ImageURL { get; set; }
        public string bannerPic { get; set; }
        [Display(Name = "Facebook profile Url")]
        public string facebookURL { get; set; }
        [Display(Name = "Instagram profile Url")]
        public string instagramURL { get; set; }
        [Display(Name = "Twitter profile Url")]
        public string twitterURL { get; set; }

    }

}