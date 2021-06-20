using FluentValidation;
using Github.JWTApplication.Core.Constants;
using Github.JWTApplication.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.userName).NotEmpty().WithMessage(ValidatorMessages.USERNAME_NULL);
            RuleFor(I => I.password).NotEmpty().WithMessage(ValidatorMessages.PASSWORD_NULL);
            RuleFor(I => I.fullName).NotEmpty().WithMessage(ValidatorMessages.FULLNAME_NULL);
            RuleFor(I => I.lastName).NotEmpty().WithMessage(ValidatorMessages.LASTNAME_NULL);
           
        }
    }
}
