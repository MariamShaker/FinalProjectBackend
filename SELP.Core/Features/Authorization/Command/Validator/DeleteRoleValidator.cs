using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SELP.Core.Features.Authorization.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Command.Validator
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;

        //private readonly IAuthorizationServices _authorizationService;
        #endregion
        #region Constructors
        public DeleteRoleValidator(RoleManager<IdentityRole> roleManager
                                )
        {


            ApplyValidationsRules();
            ApplyCustomValidationsRules();

            _roleManager = roleManager;
        }
        #endregion


        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("Must Not Empty")
                 .NotNull().WithMessage("Must Not Null");
          
        }

        public void ApplyCustomValidationsRules()
        {
            
        }

        
        #endregion
    }
}
