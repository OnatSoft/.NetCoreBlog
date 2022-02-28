using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;  //** Parola alanlarının eşitlenmesi için Regex Metodunu bununla dahil etmemiz gerekiyor.**
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator() //** Kayıt olurken doğru ve istenilen şekilde girilmesi için Geçerlilik Kuralları yazıldı **//
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.EMail).EmailAddress().WithMessage("E-posta geçersiz, lütfen geçerli bir E-posta giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.PasswordRepeat).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.İmage).NotEmpty().WithMessage("Lütfen profil resminizi sisteme yükleyin.");
            RuleFor(x => x.About).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");

            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Parola en az 5 karakterli olmalı.");
            RuleFor(x => x.Password).MaximumLength(10).WithMessage("Parola en fazla 10 karakterli olmalı.");
            RuleFor(x => x.PasswordRepeat).MinimumLength(5).WithMessage("Parola Tekrar en az 5 karakterli olmalı.");
            RuleFor(x => x.PasswordRepeat).MaximumLength(10).WithMessage("Parola Tekrar en fazla 10 karakterli olmalı.");

            RuleFor(x => x.Password).Must(IsPasswordValid).WithMessage("Parola da en az 1 küçük harf, 1 büyük harf ve 1 sayı olmalı.");
            RuleFor(x => x.PasswordRepeat).Must(IsPasswordValid).WithMessage("Parola da en az 1 küçük harf, 1 büyük harf ve 1 sayı olmalı.");
        }

        private bool IsPasswordValid(string arg)
        {  
        //** İki parola alanının eşit mi ve harf kontrolünü yapması için "Must kullanıp IsPassWordValid parametresini bu alanda bu şekilde kullanmamız gerekiyor.**
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");  // Regex metodunda nesne oluşturup nasıl harf kontrolü yapacaksak o şekilde kural oluşturuyoruz
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }


    }
}
