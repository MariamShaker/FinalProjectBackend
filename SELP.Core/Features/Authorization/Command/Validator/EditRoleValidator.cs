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
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;

        //private readonly IAuthorizationServices _authorizationService;
        #endregion
        #region Constructors
        public EditRoleValidator(RoleManager<IdentityRole> roleManager
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
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Must Not Empty")
                 .NotNull().WithMessage("Must Not Null");
        }

        public void ApplyCustomValidationsRules()
        {
            //RuleFor(x => x.Name)
            //    .MustAsync(async (name, cancellationToken) => !await _authorizationService.IsRoleExstists(name))
            //    .WithMessage("Role already exists");
        }

        //private async Task<bool> IsRoleExists(string name)
        //{
        //    return await _roleManager.RoleExistsAsync(name);
        //}
        #endregion
    }
}
