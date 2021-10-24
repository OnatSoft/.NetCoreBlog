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
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı boş geçilemez.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Blog başlığı 50 karakterden az olmalı.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriği boş geçilemez.");
            RuleFor(x => x.Content).Length(50, 2500).WithMessage("Blog içeriği 2500 karakterden az olmalı.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori alanı boş geçilemez.");
            RuleFor(x => x.İmage).NotEmpty().WithMessage("Blog görsel alanı boş geçilemez.");
        }
    }
}
