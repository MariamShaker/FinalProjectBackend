using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SELP.API.Base;
using SELP.Core.Features.Instructors.Command.Models;
using SELP.Core.Features.Instructors.Queries.Models;

using SELP.Data.AppMetaData;

namespace SELP.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
   

    public class InstructorController : AppControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet(Router.InstructorRouting.GetByID)]
        public async Task<IActionResult> GetInstructorById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetInstructorByIdQuery(id));
            return NewResult(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route(Router.InstructorRouting.GetAllInstructors)]

        public async Task<IActionResult> GetAllInstructors()
        {
            return NewResult(await Mediator.Send(new GetAllInstructorsQuery()));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route(Router.InstructorRouting.AddInstructor)]
        //[SwaggerOperation(Summary = "اضافة مدرس جديد", OperationId = "Add New Instructor")]

        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorModel Command)
        {
            return NewResult(await Mediator.Send(Command));
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPut]
        [Route(Router.InstructorRouting.UpdateInstructor)]
        

        public async Task<IActionResult> UpdateInstructor([FromForm] UpdateInstructorCommandModel Command)
        {
            return NewResult(await Mediator.Send(Command));
        }
        //delete
        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.InstructorRouting.DeleteInstructor)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteInstructorCommandModel(id));
            return NewResult(response);
        }

    }
}
