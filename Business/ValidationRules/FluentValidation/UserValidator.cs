using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            //RuleFor(p => p.Password).NotEmpty();
            //RuleFor(p => p.Password).MinimumLength(5);
            RuleFor(p => p.Email).Must(Contains);

        }

        private bool Contains(string arg)
        {
            return arg.Contains("@");
        }
    }
}
