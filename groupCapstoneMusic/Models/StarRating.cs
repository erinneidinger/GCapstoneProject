using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public class StarRating
    {
        [Key]
        public int RateId { get; set; }

        [ForeignKey("ApplicationRater")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }

        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer customer { get; set; }

        public int MusicId { get; set; }
        [ForeignKey("MusicId")]
        public virtual Musician musician { get; set; }


    }
}