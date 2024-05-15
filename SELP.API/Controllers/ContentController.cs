using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SELP.API.Base;
using SELP.Core.Features.Content.Command.Models;
using SELP.Core.Features.Content.Query.Models;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Core.Features.Students.Queries.Models;
using SELP.Core.Features.Subject.Queries.Models;
using SELP.Data.AppMetaData;

namespace SELP.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContentController : AppControllerBase
    {
       // [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet(Router.ContentRouting.List)]
        public async Task<IActionResult> GetContentList()
        {
            var response = await Mediator.Send(new GetAllContentQuery());
            return Ok(response);
        }


        //[Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.ContentRouting.GetByID)]
        //[SwaggerOperation(Summary = "عرض مادة بالرقم المعرف", OperationId = "GetSubjectById")]
        public async Task<IActionResult> GetContentById([FromRoute] int id)

        {
            var response = await Mediator.Send(new GetContentByIdQuery(id));
            return NewResult(response);
        }
        //[Authorize(Roles = "Admin,Teacher")]
        #region Add,edit,delete
        [HttpPost(Router.ContentRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddContentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

       // [Authorize(Roles = "Admin,Teacher")]
        [HttpPut(Router.ContentRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] UpdateContentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

       // [Authorize(Roles = "Admin,Teacher")]

        [HttpDelete(Router.ContentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteContentCommand(id));
            return NewResult(response);
        }



        #endregion


        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route("GetContentForEachSubject")]

        public async Task<IActionResult> GetContentForEachSubject([FromQuery] int Id)
        {
            return NewResult(await Mediator.Send(new GetContentForEachSubject(Id)));
        }
    }
}
