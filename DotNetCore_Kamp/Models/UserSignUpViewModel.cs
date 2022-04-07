using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Models
{
    public class UserSignUpViewModel  //* Admin Paneli için Kayıt işlemi validasyon model sınıfı
    {
        [Display(Name ="Ad-Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz.")]
        public string NameSurname { get; set; }

        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Lütfen bir kullanıcı adı giriniz.")]
        public string Username { get; set; }

        [Display(Name ="E-posta")]
        [Required(ErrorMessage ="Lütfen geçerli bir E-posta giriniz.")]
        public string Email { get; set; }

        [Display(Name ="Parola")]
        [Required(ErrorMessage ="Lütfen geçerli bir parola belirleyiniz.")]
        public string Password { get; set; }

        [Display(Name ="Parola Tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler eşleşmemektedir. Lütfen tekrar giriniz.")]
        public string ConfirmPassword { get; set; }

        public bool TermofUse { get; set; }
    }
}