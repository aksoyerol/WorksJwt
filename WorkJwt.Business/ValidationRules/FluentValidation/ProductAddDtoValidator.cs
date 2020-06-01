using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.DTOs.ProductDtos;

namespace WorkJwt.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name area cannot be null !");
        }
    }
}
