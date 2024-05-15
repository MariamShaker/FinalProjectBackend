using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Subjects.Command.Models;
using SELP.Core.Bases;
using SELP.Core.Features.Subject.Command.Models;
using SELP.Data.Entities;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SELP.Core.Features.Subject.Command.Handler
{
    public class SubjectCommandHandler : ResponseHandler,
                IRequestHandler<AddSubjectCommand, Response<string>>,
                IRequestHandler<DeleteSubjectCommand, Response<string>>,
        IRequestHandler<UpdateSubjectCommand, Response<string>>,
        IRequestHandler<AddSubjectToInstructorCommand, Response<string>>,
        IRequestHandler<AddSubjectToStudentCommand, Response<string>>,
        IRequestHandler<RemoveSubjectFromStudentCommand, Response<string>>
        //content 
        //IRequestHandler<AddContentToSubject, Response<string>>



    {

        #region fields
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;
        #endregion
        #region constructor
        public SubjectCommandHandler(IMapper mapper, ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
        }


        #endregion
        #region handle fun


        public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            // mapping detween request and student
            var subjectMapper = _mapper.Map<Data.Entities.Subject>(request);
            //add 
            var result = await _subjectService.AddSubject(subjectMapper);
            //check if it exist
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Subject is exist ");
            }
            else if (result == "Success")
            {
                return Created("Added Successfully");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            //check if id is exist
            var subject = await _subjectService.GetSubjectByIDAsync(request.Id);
            //return not found
            if (subject == null)
            {
                return NotFound<string>("Student Is Not Found");
            }
            var result = await _subjectService.DeleteSubject(subject);
            if (result == "Success")
            {
                return Deleted<string>();
            }
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            // Notice i have used the same mapping for add and update because they are the same
            var subject = await _subjectService.GetSubjectByIDAsync(request.SubID);
            if (subject == null)
                return BadRequest<string>();


            //var InstructorMapper = _mapper.Map<Data.Entites.Instructor>(request);
            var subjectMapper = _mapper.Map(request, subject);

            var result = await _subjectService.EditSubjectAsync(subjectMapper);
            if (result == "Success") return Success<string>("Update Successfully ");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AddSubjectToInstructorCommand request, CancellationToken cancellationToken)
        {
            var result = await _subjectService.AddInstructorToSubjectAsync(request.InstructorId, request.SubjectId);
            switch (result)
            {
                case "InstructorNotFound":
                    return BadRequest<string>("InstructorNotFound");
                case "SubjectNotFound":
                    return BadRequest<string>("SubjectNotFound");
                case "Already Exsists":
                    return BadRequest<string>("Already Exsists");
                default:
                    return Success<string>("Added successfully");

            }
        }

       




        public async Task<Response<string>> Handle(AddSubjectToStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _subjectService.AddStudentToSubjectAsync(request.StudentId, request.SubjectId,request.grade);
            switch (result)
            {
                case "StudentNotFound":
                    return BadRequest<string>("StudentNotFound");
                case "SubjectNotFound":
                    return BadRequest<string>("SubjectNotFound");
                case "Already Exsists":
                    return BadRequest<string>("Already Exsists");
                default:
                    return Success<string>("Added successfully");

            }
        }
        public async Task<Response<string>> Handle(RemoveSubjectFromStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _subjectService.RemoveStudentFromSubjectAsync(request.StudentId, request.SubjectId);
            switch (result)
            {
                case "StudentNotFound":
                    return BadRequest<string>();
                case "SubjectNotFound":
                    return BadRequest<string>();
                case "AlreadyNotExsists":
                    return BadRequest<string>();
                default:
                    return Success<string>("removed subject successfuly");

            }
        }

        //public async Task<Response<string>> Handle(AddContentToSubject request, CancellationToken cancellationToken)
        //{
        //    var result = await _subjectService.AddContentToSubjectAsync(request.ContentId,request.ContentName, request.SubjectId);
        //    switch (result)
        //    {
        //        case "InstructorNotFound":
        //            return BadRequest<string>("Content Not Found");
        //        case "SubjectNotFound":
        //            return BadRequest<string>("Subject Not Found");
        //        case "Already Exsists":
        //            return BadRequest<string>("Already Exsists");
        //        default:
        //            return Success<string>("Added successfully");

        //    }
        }

        //public async Task<Response<string>> Handle(RemoveSubjectFromInstructorCommand request, CancellationToken cancellationToken)
        //{
        //    //var result = await _subjectService.RemoveInstructorFromSubjectAsync(request.InstructorId, request.SubjectId);
        //    //switch (result)
        //    //{
        //    //    case "StudentNotFound":
        //    //        return BadRequest<string>();
        //    //    case "SubjectNotFound":
        //    //        return BadRequest<string>();
        //    //    case "AlreadyNotExsists":
        //    //        return BadRequest<string>();
        //    //    default:
        //    //        return Success<string>("Removed subject successfuly");

        //    //}
        //    return null;
        //}

        #endregion
    
}
