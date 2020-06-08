using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.DTOs.AppUserDtos;

namespace WorkJwt.Business.ValidationRules.FluentValidation
{
    public class AppUserSigninDtoValidator : AbstractValidator<AppUserSigninDto>
    {
        public AppUserSigninDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required !");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required !");
        }
    }
}
