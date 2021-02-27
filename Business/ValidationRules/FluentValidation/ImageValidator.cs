using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class ImageValidator :AbstractValidator<CarImage>
    {
        public ImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("carId alanı boş bırakılamaz.");
            RuleFor(p => p.ImagePath).NotEmpty().WithMessage("lütfen bir resim seçiniz..");
        }
    }
}
