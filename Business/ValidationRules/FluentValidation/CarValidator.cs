using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük fiyatı 0 dan fazla olmalıdır.");
            RuleFor(p => p.Description).MinimumLength(2).WithMessage("arac açıklaması minimum 5 karakter olmalıdır");
            RuleFor(p => p.BrandId).NotNull();
            RuleFor(p => p.ColorId).NotNull();


        }
    }
}
