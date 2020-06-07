using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Concrete;
using WorksJwt.Entities.DTOs.ProductDtos;

namespace WorkJwt.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be null !");
        }
    }
}
