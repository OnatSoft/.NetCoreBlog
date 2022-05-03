using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen bir rol adı giriniz.")]
        public string Name { get; set; }
    }
}
