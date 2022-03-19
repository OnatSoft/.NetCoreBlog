using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Kategori adı 20 karakterden az olmalı.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori adı 3 karakterden fazla olmalı.");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("Kategori açıklaması 150 karakterden az olmalı.");
            RuleFor(x => x.Description).MinimumLength(30).WithMessage("Kategori açıklaması 30 karakterden fazla olmalı.");
        }
    }
}
