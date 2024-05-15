using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Data.Entities;
using SELP.Infrastructur.Abstract;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        private readonly IStudentSevice _studentSevice;
        private readonly IMapper _mapper;
        #region Fields
        #endregion
        #region Constructor
        public StudentCommandHandler(IStudentSevice studentSevice, IMapper mapper)
        {
            _studentSevice = studentSevice;
            _mapper = mapper;

        }
        #endregion
        #region Handle Fun
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // mapping detween request and student
            var studentMapper = _mapper.Map<Student>(request);
            //add 
            var result = await _studentSevice.AddAsync(studentMapper,request.ImageUrl);
            //check if it exist
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Email is exist ");
            }
            else if (result == "Success")
            {
                return Created("Added Successfully");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check if id is exist
            var student = await _studentSevice.GetStudentByIDAsync(request.Id);
            //return not found
            if (student == null) { return NotFound<string>("Student Is Not Found"); }
            //if exist mapping
            var studentMapper = _mapper.Map(request, student);
            //call service that make edit

            var result = await _studentSevice.EditAsync(studentMapper, request.ImageUrl);
            //return response
            if (result == "Success")
            {
                return Success("Edit Successfully ");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check if id is exist
            var student = await _studentSevice.GetStudentByIDAsync(request.Id);
            //return not found
            if (student == null)
            {
                return NotFound<string>("Student Is Not Found");
            }
            var result = await _studentSevice.DeleteAsync(student);
            if (result == "Success")
            {
                return Deleted<string>();
            }
            return BadRequest<string>();
            #endregion
        }
    }
}
