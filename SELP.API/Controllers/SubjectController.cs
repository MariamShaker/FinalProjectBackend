using MediatR;
using Microsoft.AspNetCore.Http;
using SELP.API.Base;
using Microsoft.AspNetCore.Mvc;
using SELP.Core.Features.Subject.Queries.Models;
using SELP.Data.AppMetaData;
using SELP.Data.Entities;
using SELP.Core.Features.Instructors.Command.Models;
using SELP.Core.Features.Subject.Command.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SELP.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Subjects.Command.Models;
using Microsoft.AspNetCore.Authorization;

namespace SELP.API.Controllers
{
    [Route("")]
    [ApiController]
    public class SubjectController : AppControllerBase
    {
        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.SubjectRouting.GetByID)]
        //[SwaggerOperation(Summary = "عرض مادة بالرقم المعرف", OperationId = "GetSubjectById")]
        public async Task<IActionResult> GetSubjectById([FromRoute] int id)

        {
            var response = await Mediator.Send(new GetSubjectByIdQuery(id));
            return NewResult(response);
        }
        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.SubjectRouting.GetAllSubject)]
        
        public async Task<IActionResult> GetAllSubjects()
        {
            var response = await Mediator.Send(new GetAllSubjectQuery());
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route(Router.SubjectRouting.AddSubject)]
        

        public async Task<IActionResult> AddSubject([FromForm] AddSubjectCommand Command)
        {
            var response = await Mediator.Send(Command);
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route(Router.SubjectRouting.DeleteSubject)]
        public async Task<IActionResult> DeleteSubject([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteSubjectCommand(id));
            return NewResult(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route(Router.SubjectRouting.UpdateSubject)]
        public async Task<IActionResult> EditSubject([FromForm] UpdateSubjectCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.SubjectRouting.GetSubjectsForInstructor)]
        //عرض المواد الخاصة باحد المدرسين
        public async Task<IActionResult> GetSubjectsForInstructor([FromQuery] int Id)
        {
            return NewResult(await Mediator.Send(new GetSubjectByInstructorQuery(Id)));
        }

        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.SubjectRouting.GetSubjectsForStudent)]
       
        public async Task<IActionResult> GetSubjectsForStudent([FromQuery] int Id)
        {
            return NewResult(await Mediator.Send(new GetSubjectByStudentQuery(Id)));
        }

        //content
        [Authorize(Roles = "Admin,Teacher,Student,User")]
        [HttpGet]
        [Route(Router.SubjectRouting.GetSubjectsForContent)]

        public async Task<IActionResult> GetSubjectsForContent([FromQuery] int Id)
        {
            return NewResult(await Mediator.Send(new GetSubjectByContent(Id)));
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        [Route(Router.SubjectRouting.AddContentToSubject)]
        
        public async Task<IActionResult> AddContentToSubject([FromBody] AddContentToSubject command)
        {
            return NewResult(await Mediator.Send(command));
        }

        //end content
        [Authorize(Roles = "Admin,Student")]
        [HttpPost]
        [Route(Router.SubjectRouting.AddSubjectToStudent)]
        //اضافة مادة لاحد الطلاب
        public async Task<IActionResult> AddSubjectToStudent([FromBody] AddSubjectToStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route(Router.SubjectRouting.RemoveSubjectFromStudent)]
        //حذف مادة من احد الطلاب
        public async Task<IActionResult> RemoveSubjectFromStudent([FromBody] RemoveSubjectFromStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        [Route(Router.SubjectRouting.AddSubjectToInstructor)]
       // اضافة مادة لاحد المدرسين
        public async Task<IActionResult> AddSubjectToInstructor([FromBody] AddSubjectToInstructorCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }

    }
}
