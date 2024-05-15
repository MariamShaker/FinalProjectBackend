using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SELP.Core.Bases;
using SELP.Core.Features.AuthenticationUser.Query.Models;
using SELP.Core.Features.AuthenticationUser.Query.Response;
using SELP.Core.Features.Authorization.Query.Models;
using SELP.Core.Features.Authorization.Query.Response;
using SELP.Data.Entities.Identity;
using SELP.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Query.Handler
{
    public class GetRolesHandler : ResponseHandler,
                 IRequestHandler<GetAllRoleQuery, Response<List<GetAllRolesResponse>>>,
                 IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>,
        IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResponse>>,
        IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResponse>>

    {


        #region Fields
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        #endregion
        #region constructor
        public GetRolesHandler(IMapper mapper,
                                  RoleManager<IdentityRole> roleManager,
                                   UserManager<User> userManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        #endregion
        #region Handle Fun
      

        public async Task<Response<List<GetAllRolesResponse>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var users =await _roleManager.Roles.ToListAsync();
            var resultMapper = _mapper.Map<List<GetAllRolesResponse>>(users);
            return Success(resultMapper);
        }

        

        async Task<Response<GetRoleByIdResponse>> IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>.Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id==request.Id);
            var user = await _roleManager.FindByIdAsync(request.ID.ToString());
            if (user == null) return NotFound<GetRoleByIdResponse>("Not Found");
            var result = _mapper.Map<GetRoleByIdResponse>(user);
            return Success(result);
        }





        public async Task<Response<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return NotFound<ManageUserRolesResponse>();

            var response = new ManageUserRolesResponse();
            var rolesList = new List<UserRoles>();

            //Roles
            var roles = await _roleManager.Roles.ToListAsync();
            response.UserId = user.Id;

            foreach (var role in roles)
            {
                var userrole = new UserRoles();
                userrole.Id = role.Id;
                userrole.Name = role.Name;
                userrole.HasRole = await _userManager.IsInRoleAsync(user, role.Name);
                //if (await _userManager.IsInRoleAsync(user, role.Name))
                //{
                //    userrole.HasRole = true;
                //}
                //else
                //{
                //    userrole.HasRole = false;
                //}
                rolesList.Add(userrole);
            }

            response.Roles = rolesList;
            return Success(response); 
        }

        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserClaimsResponse>();
            var response = new ManageUserClaimsResponse();
            var usercliamsList = new List<UserClaims>();
            response.UserId = user.Id;
            //Get USer Claims
            var userClaims = await _userManager.GetClaimsAsync(user); //edit
                                                                      //create edit get print
            foreach (var claim in ClaimsStore.claims)
            {
                var userclaim = new UserClaims();
                userclaim.Type = claim.Type;
                if (userClaims.Any(x => x.Type == claim.Type))
                {
                    userclaim.Value = true;
                }
                else
                {
                    userclaim.Value = false;
                }
                usercliamsList.Add(userclaim);
            }
            response.Claims = usercliamsList;
            //return Result
            return Success(response);
        }
        #endregion
    }
}
