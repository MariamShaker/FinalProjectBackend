using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Instructors.Queries.Models;
using SELP.Core.Features.Instructors.Queries.Response;
using SELP.Core.Features.Students.Queries.Models;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Instructors.Queries.Handler
{
    public class InstructorQueryHandler : ResponseHandler,
            IRequestHandler<GetInstructorByIdQuery, Response<GetInstructorByIdResponse>>,
            IRequestHandler<GetAllInstructorsQuery, Response<List<GetInstructorListResponse>>>
    {
        #region fields
        private readonly IInstructorServices _instructorServices;
        private readonly IMapper _mapper;
        #endregion
        #region constructors
        public InstructorQueryHandler(IInstructorServices instructorServices,IMapper mapper)
        {
            _instructorServices= instructorServices;
           _mapper = mapper;
        }

        
        #endregion
        #region handle fun
        #endregion


        async Task<Response<GetInstructorByIdResponse>> IRequestHandler<GetInstructorByIdQuery, Response<GetInstructorByIdResponse>>.Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            //service get by id 
            var response = await _instructorServices.GetInstructorById(request.Id);
            //check is exist
            if (response == null) return NotFound<GetInstructorByIdResponse>();
            //mapping
            var mapper=_mapper.Map<GetInstructorByIdResponse>(response);
            //return response
            return Success<GetInstructorByIdResponse>(mapper);
        }



        public async Task<Response<List<GetInstructorListResponse>>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
        {
            var instructors = await _instructorServices.InstructorListAsync();
            if (instructors == null)
               return NotFound<List<GetInstructorListResponse>>();
            var InsMapper = _mapper.Map<List<GetInstructorListResponse>>(instructors);
            return Success(InsMapper);
        }

    
       // public async Task<Response<List<GetInstructorListResponse>>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
      //  {
        //    var studentList = await _instructorServices.InstructorListAsync();
        //    var resultMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
       //     return Success(resultMapper);
       // }
    }
}
