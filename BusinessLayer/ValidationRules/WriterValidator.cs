using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator() //** Kayıt olurken doğru ve istenilen şekilde girilmesi için Geçerlilik Kuralları yazıldı **//
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.EMail).EmailAddress().WithMessage("Lütfen geçerli bir E-posta giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Giriş yapabilmek için bir parola oluşturunuz.");
            RuleFor(x => x.PasswordRepeat).NotEmpty().WithMessage("Giriş yapabilmek için bir parola oluşturunuz.");
            RuleFor(x => x.Password).Length(6).WithMessage("Parola en az 6 karakterli olmalı.");
            RuleFor(x => x.PasswordRepeat).Length(6).WithMessage("Parola en az 6 karakterli olmalı.");
        }
    }
}
