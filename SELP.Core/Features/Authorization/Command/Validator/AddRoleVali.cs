using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SELP.Core.Features.Authorization.Command.Handler;
using SELP.Core.Features.Authorization.Command.Models;
using SELP.Data.Entities.Identity;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Command.Validator

{
    public class AddRoleVali : AbstractValidator<AddRoleCommand>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthorizationService _authorizationService;

        //private readonly IAuthorizationServices _authorizationService;
        #endregion
        #region Constructors
        public AddRoleVali( RoleManager<IdentityRole> roleManager,
             IAuthorizationService authorizationService
                                )
        {


            ApplyValidationsRules();
            ApplyCustomValidationsRules();

            _roleManager = roleManager;
            _authorizationService = authorizationService;
        }
        #endregion


        #region Actions
        public void ApplyValidationsRules()
        {
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
