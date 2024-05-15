using FluentValidation;
using SELP.Core.Features.Authentication.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Command.Validation
{
    public class ConfirmEmailValidator : AbstractValidator<ComfirmEmail>
    {
        #region Fields
        #endregion

        #region constructor
        public ConfirmEmailValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region handleFun
        public void ApplyValidationRules()
        {



            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" Email Required");

            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" PassWord Required");



        }
        public void ApplyCustomValidationRules()
        {


        }
        #endregion
    }
}
