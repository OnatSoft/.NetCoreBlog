using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public  int BlogScore { get; set; }
        public bool Status { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
