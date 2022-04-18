using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Models
{
    public class UserUpdateViewModel
    {
        public string namesurname { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [Display(Name = "Parola değişikliğini onaylıyorum")]
        [Required(ErrorMessage = "Parolanızı değiştirmek için bu kutucuğu işaretlemelisiniz.")]
        public bool password_check { get; set; }
    }
}
