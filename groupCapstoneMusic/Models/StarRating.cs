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
        public int Rate { get; set; }
        public string IpAddress { get; set; }

        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer customer { get; set; }

        public int MusicId { get; set; }
        [ForeignKey("MusicId")]
        public virtual Musician musician { get; set; }
    }
}