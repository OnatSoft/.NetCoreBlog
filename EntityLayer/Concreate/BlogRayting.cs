
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class BlogRayting
    {
        [Key]
        public int RaytingID { get; set; }
        public int BlogID { get; set; }
        public int TotalScore { get; set; }
        public int BlogRaytingCount { get; set; }
    }
}
