using FluentValidation;
using Microsoft.Extensions.Localization;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.AuthenticationUser.Commands.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Fields
       

        #endregion
        #region Constructors
        public UpdateUserValidator()
        {
          
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion
        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Must NotEmpty")
                .NotNull().WithMessage("FirstName Required")
                .MaximumLength(100).WithMessage("MaximumLength=100");

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("Must NotEmpty")
               .NotNull().WithMessage(" LastName Required")
               .MaximumLength(100).WithMessage("MaximumLength = 100");
            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Must NotEmpty ")
               .NotNull().WithMessage("UserName Required")
               .MaximumLength(100).WithMessage("MaximumLength=100");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" Email Required");

           

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
