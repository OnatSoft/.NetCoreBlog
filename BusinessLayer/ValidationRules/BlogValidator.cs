using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator: AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Blog başlığı 50 karakterden az olmalı.");

            RuleFor(x => x.İmage).NotEmpty().WithMessage("Lütfen bir resim dosyası yükleyin.");
            RuleFor(x => x.ThumbnailImage).NotEmpty().WithMessage("Lütfen bir resim dosyası yükleyin.");

            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Lütfen bir kategori seçiniz.");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Blog açıklaması 10 karakterden fazla olmalı.");
            RuleFor(x => x.Content).MaximumLength(3000).WithMessage("Blog açıklaması 3000 karakterden az olmalı.");
        }
    }
}
