using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SELP.Core.Bases;
using SELP.Core.Features.Authorization.Command.Models;
using SELP.Data.Entities.Identity;
using SELP.Infrastructur.Data;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Command.Handler
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
         IRequestHandler<DeleteRoleCommand, Response<string>>,


         IRequestHandler<UpdateUserClaims, Response<string>>
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _dbContext;

        #endregion
        #region Constructor
        public RoleCommandHandler(RoleManager<IdentityRole> roleManager,
            IAuthorizationService authorizationService, UserManager<User> userManager
            , ApplicationDBContext dbContext)
        {
            _roleManager = roleManager;
            _authorizationService = authorizationService;
            this._userManager = userManager;
           _dbContext = dbContext;
        }


        #endregion
        #region Action
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.Name);
            if (result == "Success")
            {
                return Success("");
            }
            if(result == "RoleExists")
            {
                return BadRequest<string>("Role is already Exist!");
            }
            return BadRequest<string>("Faild");




            //var identityRole = new IdentityRole();
            //identityRole.Name = request.Name;
            //var result = await _roleManager.CreateAsync(identityRole);
            //if (result.Succeeded)
            //{
            //    return Success("Success");
            //}
            //return BadRequest<string>("Faild");
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            

            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
            {
                return BadRequest<string>("RoleNotFound");
            }

            // Update the existing role with the new name
            role.Name = request.Name;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return Success("Success");
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }
           
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
            {
                return BadRequest<string>("RoleNotFound");
            }

            // delete the existing role with the new name
            //Chech if user has this role or not
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            //return exception 
            if (users != null && users.Count() > 0) return BadRequest<string>("User uses role");
            //delete
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Success("Success");
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }
        }

        public async Task<Response<string>> Handle(UpdateUserClaims request, CancellationToken cancellationToken)
        {
            var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return BadRequest<string>("UserIsNull");
                }
                //remove old Claims
                var userClaims = await _userManager.GetClaimsAsync(user);
                var removeClaimsResult = await _userManager.RemoveClaimsAsync(user, userClaims);
                if (!removeClaimsResult.Succeeded)
                    return BadRequest<string>("FailedToRemoveOldClaims");
                var claims = request.Claims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));

                var addUserClaimResult = await _userManager.AddClaimsAsync(user, claims);
                if (!addUserClaimResult.Succeeded)
                    return BadRequest<string>("FailedToAddNewClaims");

                await transact.CommitAsync();
                return Success("Success");
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return BadRequest<string>("FailedToUpdateClaims");
            }
        }
        //public async Task<bool> IsRoleExstists(string Name)=> await _roleManager.RoleExistsAsync(Name);



        #endregion
    }
}
