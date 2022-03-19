using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Models
{
    public class BlogModel
    {
        public int BlogID { get; set; }
        public string BlogName { get; set; }
        public string BlogAuth { get; set; }
        public string Content { get; set; }
        public string BlogThumbnailİmage { get; set; }
        public string Blogİmage { get; set; }
        public string CreateDate { get; set; }

    }
}
