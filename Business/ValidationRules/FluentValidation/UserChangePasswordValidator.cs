using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserChangePasswordValidator: AbstractValidator<UserChangePasswordDto>
    {
        public UserChangePasswordValidator()
        {
            RuleFor(p => p.NewPassword).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir.");
            RuleFor(p => p.NewPassword).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir.");
            RuleFor(p => p.NewPassword).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir.");
            RuleFor(p => p.NewPassword).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir.");
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Şifre boş olamaz.");
        }
    }
}
