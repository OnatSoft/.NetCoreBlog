using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}
