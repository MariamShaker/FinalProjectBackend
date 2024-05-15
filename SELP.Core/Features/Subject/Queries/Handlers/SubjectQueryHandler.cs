using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Content.Query.Models;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Instructors.Queries.Models;
using SELP.Core.Features.Instructors.Queries.Response;
using SELP.Core.Features.Subject.Queries.Models;
using SELP.Core.Features.Subject.Queries.Response;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler,
        IRequestHandler<GetSubjectByIdQuery, Response<GetSubjectByIdResponse>>,
        IRequestHandler<GetAllSubjectQuery, Response<List<GetAllSubjectResponse>>>,
        IRequestHandler<GetSubjectByInstructorQuery, Response<List<GetSubjectByInstructorResponse>>>,
        IRequestHandler<GetSubjectByStudentQuery, Response<List<GetSubjectByStudentResponse>>>,
        //content
         IRequestHandler<GetSubjectByContent, Response<List<GetSubjectByContentResponse>>>
       
    {

        #region fields
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        #endregion
        #region constructor
        public SubjectQueryHandler(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }


        #endregion
        #region handle fun
        public async Task<Response<GetSubjectByIdResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            //service get by id 
            var response = await _subjectService.GetSubjectByIDAsync(request.Id);
            //check is exist
            if (response == null) return NotFound<GetSubjectByIdResponse>();
            //mapping
            var mapper = _mapper.Map<GetSubjectByIdResponse>(response);
            //return response
            return Success(mapper);
        }

        public async Task<Response<List<GetAllSubjectResponse>>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            var subject = await _subjectService.GetAllSubjectAsync();
            if (subject == null)
                return NotFound<List<GetAllSubjectResponse>>();
            var SubMapper = _mapper.Map<List<GetAllSubjectResponse>>(subject);
            return Success(SubMapper);
        }

        public async Task<Response<List<GetSubjectByInstructorResponse>>> Handle(GetSubjectByInstructorQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectService.GetSubjectsByInstructorAsync(request.InstrucotId);

            // Null Checking 
            if (subjects == null || subjects.Count == 0)
                return NotFound<List<GetSubjectByInstructorResponse>>("Instructor not found or instructor not assign any subject ");

            // Mapping
            var mapper = _mapper.Map<List<GetSubjectByInstructorResponse>>(subjects);
            return Success(mapper);
        }

       

        async Task<Response<List<GetSubjectByStudentResponse>>> IRequestHandler<GetSubjectByStudentQuery, Response<List<GetSubjectByStudentResponse>>>.Handle(GetSubjectByStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _subjectService.GetSubjectsByStudentAsync(request.StudentId);

            // Null Checking 
            if (student == null || student.Count == 0)
                return NotFound<List<GetSubjectByStudentResponse>>("student not found or student not assign any subject ");

            // Mapping
            var mapper = _mapper.Map<List<GetSubjectByStudentResponse>>(student);
            return Success(mapper);
        }

        public async Task<Response<List<GetSubjectByContentResponse>>> Handle(GetSubjectByContent request, CancellationToken cancellationToken)
        {

            var content = await _subjectService.GetSubjectsByContentsAsync(request.ContentId);

            // Null Checking 
            if (content == null || content.Count == 0)
                return NotFound<List<GetSubjectByContentResponse>>("Content not found or content not assign any subject ");

            // Mapping
            var mapper = _mapper.Map<List<GetSubjectByContentResponse>>(content);
            return Success(mapper);
        }

     


        #endregion
    }
}
