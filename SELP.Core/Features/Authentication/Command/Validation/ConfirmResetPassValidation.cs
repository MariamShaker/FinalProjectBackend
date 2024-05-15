using FluentValidation;
using SELP.Core.Features.Authentication.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Command.Validation
{
    public class ConfirmResetPassValidation : AbstractValidator<ConfirmResetPassCommand>
    {
        #region Fields
        #endregion

        #region constructor
        public ConfirmResetPassValidation()
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
     
             RuleFor(x => x.ConfirmPassword)
                  .Equal(x => x.Password).WithMessage("ConfirmPassword must equal Password");



        }
        public void ApplyCustomValidationRules()
        {


        }
        #endregion
    }
}
