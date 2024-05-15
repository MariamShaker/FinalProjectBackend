using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.ApplicationUser.Command.Models;
using SELP.API.Base;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Core.Features.AuthenticationUser.Query.Models;
using SELP.Data.AppMetaData;

namespace SELP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [AllowAnonymous]
        //Create User
        [HttpPost(Router.ApplicationUser.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        //Get List
        [HttpGet(Router.ApplicationUser.List)]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetAllUserQuery());
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        //get user by id
        [HttpGet(Router.ApplicationUser.GetByID)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]

        //update user

        [HttpPut(Router.ApplicationUser.Edit)]
        public async Task<IActionResult> EditUser([FromBody] UpdateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Roles = "Admin")]
        //delete user
        [HttpDelete(Router.ApplicationUser.Delete)]

        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }


        [Authorize(Roles = "Admin,Teacher,Student,User")]
        //change pass user

        [HttpPut(Router.ApplicationUser.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
