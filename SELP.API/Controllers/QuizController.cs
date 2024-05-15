using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SELP.API.Base;

using SELP.Core.Features.Quiz.Command.Models;
using SELP.Core.Features.Quiz.Query.Models;
using SELP.Data.AppMetaData;

namespace SELP.API.Controllers
{
    [Route("")]
    [ApiController]
    public class QuizController : AppControllerBase
    {
        [Authorize(Roles = "Admin,Teacher,Student,User")]

        [HttpGet(Router.QuizRouting.List)]
        public async Task<IActionResult> GetContentList()
        {
            var response = await Mediator.Send(new GetAllQuizQuery());
            return Ok(response);
        }


        //[Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.QuizRouting.GetByID)]
        //[SwaggerOperation(Summary = "عرض مادة بالرقم المعرف", OperationId = "GetSubjectById")]
        public async Task<IActionResult> GetContentById([FromRoute] int id)

        {
            var response = await Mediator.Send(new GetQuizByIdQuery(id));
            return NewResult(response);
        }



        #region Add,edit,delete
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost(Router.QuizRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddQuizCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPut(Router.QuizRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] UpdateQuizCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpDelete(Router.QuizRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteQuizCommand(id));
            return NewResult(response);
        }



        #endregion


        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route("GetQuizForEachContent")]

        public async Task<IActionResult> GetQuizForEachContent([FromQuery] int Id)
        {
            return NewResult(await Mediator.Send(new GetAllQuizForEachContent(Id)));
        }
    }
}
