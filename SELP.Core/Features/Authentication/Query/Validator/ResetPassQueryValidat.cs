using FluentValidation;
using SELP.Core.Features.Authentication.Command.Models;
using SELP.Core.Features.Authentication.Query.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Query.Validator
{
    public class ResetPassQueryValidat : AbstractValidator<ResetPasswordQuery>
    {
        #region Fields
        #endregion

        #region constructor
        public ResetPassQueryValidat()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region handleFun
        public void ApplyValidationRules()
        {



            RuleFor(x => x.ResetCode)
                 .NotEmpty().WithMessage("Must NotEmpty")
                 .NotNull().WithMessage(" Email Required");
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
