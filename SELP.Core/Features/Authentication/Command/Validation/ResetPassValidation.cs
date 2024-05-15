using FluentValidation;
using SELP.Core.Features.Authentication.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Command.Validation
{
    public class ResetPassQueryValidation : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        #endregion

        #region constructor
        public ResetPassQueryValidation()
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

           



        }
        public void ApplyCustomValidationRules()
        {


        }
        #endregion
    }
}
