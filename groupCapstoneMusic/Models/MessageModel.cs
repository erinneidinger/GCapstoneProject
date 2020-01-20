using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public class MessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public int ParentMessageId { get; set; }
        public bool IsViewed { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ViewDate { get; set; }
    }
}