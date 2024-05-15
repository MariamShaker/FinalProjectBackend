using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SELP.API.Base;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Core.Features.Students.Queries.Models;
using SELP.Core.Features.Subject.Command.Models;
using SELP.Data.AppMetaData;

namespace SELP.API.Controllers
{
    
    [ApiController]
    [Authorize]
  

    public class StudentController : AppControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIDQuery(id));
            return NewResult(response);
        }
        [Authorize(Roles = "Admin")]
        //add new student
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Roles = "Admin,Student")]
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
