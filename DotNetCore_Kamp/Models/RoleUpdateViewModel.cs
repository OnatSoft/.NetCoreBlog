using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Models
{
    public class RoleUpdateViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Lütfen güncellenecek bir rol giriniz.")]
        public string name { get; set; }
    }
}
