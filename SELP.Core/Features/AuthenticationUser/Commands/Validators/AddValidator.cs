using FluentValidation;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.AuthenticationUser.Commands.Validators
{
    public class AddValidator: AbstractValidator<AddUserCommand>
    {
        #region Fields
        #endregion

        #region constructor
        public AddValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region handleFun
        public void ApplyValidationRules()
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

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" PassWord Required");


            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage("ConfirmPassword Must Equal Password");
            RuleFor(x => x.UserRole)
                .NotEmpty().WithMessage("Must NotEmpty")
                .NotNull().WithMessage(" PassWord Required")
                .NotEqual("Admin").WithMessage("UserRole Must Not Equal Admin");
        }
        public void ApplyCustomValidationRules()
        {
            

        }
        #endregion
    }
}
