using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Models
{
    public class UserSignInViewModel  //* Admin Paneline kayıtlı kullanıcı giriş yapmak için yazılan Model Sınıfı
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı doğru giriniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen parolanızı doğru giriniz.")]
        public string Password { get; set; }
    }
}
