using FluentValidation;
using SELP.Core.Features.Authentication.Command.Models;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Command.Validation
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        #endregion

        #region constructor
        public SignInValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region handleFun
        public void ApplyValidationRules()
        {
            
            

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" Email Required");

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" PassWord Required");


            
        }
        public void ApplyCustomValidationRules()
        {


        }
        #endregion
    }
}
