using Business.Constant;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public class RentalValidator: AbstractValidator<Rental>
    {

        public RentalValidator()
        {
            //returnDate i null olan araclar kullanımda demek ve kiralanamaz.
            RuleFor(p => p.ReturnDate).NotNull().WithMessage(Messages.RentalBusy);
            RuleFor(p => p.RentDate).NotNull();

        }

    }
}
