using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
