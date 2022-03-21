using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string İmage1 { get; set; }
        public string İmage2 { get; set; }
        public bool Status { get; set; }
    }
}
