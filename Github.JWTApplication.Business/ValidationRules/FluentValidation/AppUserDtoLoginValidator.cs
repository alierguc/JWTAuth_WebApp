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
    public class AppUserDtoLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserDtoLoginValidator()
        {
            RuleFor(I => I.userName).NotEmpty().WithMessage(ValidatorMessages.USERNAME_NULL);
            RuleFor(I => I.password).NotEmpty().WithMessage(ValidatorMessages.PASSWORD_NULL);
        }
    }
}
