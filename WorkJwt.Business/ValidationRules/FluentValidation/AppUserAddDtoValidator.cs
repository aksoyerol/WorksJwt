using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WorksJwt.Entities.DTOs.AppUserDtos;

namespace WorkJwt.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName cannot null");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot null");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name cannot null");
        }
    }
}
