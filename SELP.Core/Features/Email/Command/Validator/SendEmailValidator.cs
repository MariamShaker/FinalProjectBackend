using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SELP.Core.Features.Authorization.Command.Models;
using SELP.Core.Features.Email.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Email.Command.Validator
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Fields

        //private readonly IAuthorizationServices _authorizationService;
        #endregion
        #region Constructors
        public SendEmailValidator(
                                )
        {


            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion


        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Must Not Empty")
                 .NotNull().WithMessage("Must Not Null");
            RuleFor(x => x.Message)
                 .NotEmpty().WithMessage("Must Not Empty")
                 .NotNull().WithMessage("Must Not Null");
        }

        public void ApplyCustomValidationsRules()
        {
        }

      
        #endregion
    }
}
