﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Auth { get; set; }
        public string ThumbnailImage { get; set; }
        public string İmage { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int WriterID { get; set; }
        public Writer Writers { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
