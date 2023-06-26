using BlogProject.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        { 
            RuleFor(c => c.Name).MinimumLength(3).NotNull().NotEmpty().WithName("Kategori Adı");
            RuleFor(c => c.Description).MinimumLength(10).MaximumLength(300).NotEmpty().WithName("Kategori Açıklaması");
        }
    }
}
