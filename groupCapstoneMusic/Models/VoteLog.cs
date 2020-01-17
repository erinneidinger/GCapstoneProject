using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace groupCapstoneMusic.Models
{
    public class VoteLog
    {
        [Key]
        public int AutoId { get; set; }
        public int SectionId { get; set; }
        public int VoteForId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public bool Active { get; set; }
    }
}