using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Students.Queries.Models;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Data.Entities;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery,Response< List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>
    {
        #region Fields
        private readonly IStudentSevice _studentSevice;
        private readonly IMapper _mapper;
        #endregion
        #region constructor
        public StudentQueryHandler(IStudentSevice studentSevice , IMapper mapper)
        {
            _studentSevice = studentSevice;
            _mapper = mapper;
        }
        #endregion
        #region handle fun
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
           var studentList= await _studentSevice.GetStudentListAsync();
            var resultMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success( resultMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentSevice.GetStudentByIDAsync(request.ID);
            if(student == null)
            {
                return NotFound<GetSingleStudentResponse>("Student not found!");
            }
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success( result );
        }
        #endregion

    }
}
