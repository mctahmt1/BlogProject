using BlogProject.Entity.Entities;
using FluentValidation;

namespace BlogProject.Service.FluentValidations
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator() 
        {
            RuleFor(x => x.Title).Length(5,150).NotEmpty().NotNull().WithName("Başlık");
            RuleFor(x => x.Content).MinimumLength(100).NotEmpty().NotNull().WithName("İçerik");
        }
    }
}
