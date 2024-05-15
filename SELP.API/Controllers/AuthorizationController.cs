using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.ApplicationUser.Command.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SELP.API.Base;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Core.Features.AuthenticationUser.Query.Models;
using SELP.Core.Features.Authorization.Command.Models;
using SELP.Core.Features.Authorization.Query.Models;
using SELP.Data.AppMetaData;

namespace SELP.API.Controllers
{
 
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppControllerBase
    {

        //Get List
        [HttpGet(Router.Authorization.List)]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetAllRoleQuery());
            return Ok(response);
        }


        //get user by id
        [HttpGet(Router.Authorization.GetByID)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery(id));
            return NewResult(response);
        }






        //Create Role
        [HttpPost(Router.Authorization.Create)]
        public async Task<IActionResult> Create([FromBody] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        
        //edit Roles
        [HttpPut(Router.Authorization.Edit)]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        
        
        //delete Roles
        [HttpDelete(Router.Authorization.Delete)]
        public async Task<IActionResult> DeleteRole([FromRoute]  string id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(id));
            return NewResult(response);
        }


        //manage user role
        [HttpGet(Router.Authorization.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] string UserId)
        {
            var response = await Mediator.Send(new ManageUserRolesQuery() { UserId = UserId });
            return NewResult(response);
        }



        //manage user claims
        [HttpGet(Router.Authorization.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] string userId)
        {
            var response = await Mediator.Send(new ManageUserClaimsQuery(userId));
            return NewResult(response);
        }


        //UpdateUserClaims Claims
        [HttpPut(Router.Authorization.CreateUserClaims)]
     
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaims command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
