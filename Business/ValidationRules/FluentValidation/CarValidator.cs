using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.InvalidPrice);
            //RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(Messages.DailyPriceNotExists);
            //RuleFor(c => c.BrandId).NotEmpty().WithMessage(Messages.BrandRequired);
        }
    }
}
