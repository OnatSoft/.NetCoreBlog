﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class Message2
    {
        [Key]
        public int ID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
        public Writer SenderWriter { get; set; }
        public Writer ReceiverWriter { get; set; }
    }
}
