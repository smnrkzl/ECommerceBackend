using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş olamaz.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir email adresi yazınız.");
            
        }
    }
}
