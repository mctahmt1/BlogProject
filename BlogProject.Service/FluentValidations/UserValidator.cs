using BlogProject.Entity.Entities;
using FluentValidation;

namespace BlogProject.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x=>x.FirstName).MinimumLength(2).MaximumLength(50).NotNull().WithName("İsim");
            RuleFor(x=>x.LastName).MinimumLength(2).MaximumLength(50).NotNull().WithName("Soyisim");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithName("Email");
            RuleFor(x => x.PhoneNumber).NotNull()
                .Matches(@"[0-9]+").WithName("Telefon Numarası");
        }
    }
}
