using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Instructors.Command.Models;
using SELP.Data.Entities;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Instructors.Command.Handler
{
    public class InstructorCommandHandler : ResponseHandler,
                                           IRequestHandler<AddInstructorModel, Response<string>>,
                                           IRequestHandler<UpdateInstructorCommandModel, Response<string>>,
                                            IRequestHandler<DeleteInstructorCommandModel, Response<string>>
                                             
    {

        #region fields
        private readonly IMapper _mapper;
        private readonly IInstructorServices _instructorServices;
        #endregion
        #region constructor
        public InstructorCommandHandler(IMapper mapper, IInstructorServices instructorServices)
        {
            _mapper = mapper;
            _instructorServices = instructorServices;
        }


        #endregion
        #region handler fun
        public async Task<Response<string>> Handle(AddInstructorModel request, CancellationToken cancellationToken)
        {
            // mapping detween request and student
            var instructorMapper = _mapper.Map<Instructor>(request);
            //add 
            var result = await _instructorServices.AddInstructor(instructorMapper,request.ImageUrl);
            //check if it exist
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("instructor is exist ");
            }
            else if (result == "Success")
            {
                return Created("Added Successfully");
            }
            else return BadRequest<string>();
        }
        //update
        public async Task<Response<string>> Handle(UpdateInstructorCommandModel request, CancellationToken cancellationToken)
        {
            
                // Notice i have used the same mapping for add and update because they are the same
                var instructor = await _instructorServices.GetInstructorById(request.InsId);
                if (instructor == null)
                    return BadRequest<string>();
                    

            //var InstructorMapper = _mapper.Map<Data.Entites.Instructor>(request);
            var InstructorMapper = _mapper.Map(request, instructor);

                var result = await _instructorServices.UpdateInstructor(InstructorMapper,request.ImageUrl);
                if (result == "Success") return Success<string>("Update Successfully ");
                else return BadRequest<string>();
            
        }
        //delete
        public async Task<Response<string>> Handle(DeleteInstructorCommandModel request, CancellationToken cancellationToken)
        {
            //check if id is exist
            var instructor = await _instructorServices.GetInstructorById(request.Id);
            //return not found
            if (instructor == null)
            {
                return NotFound<string>("Student Is Not Found");
            }
            var result = await _instructorServices.DeleteInstructor(instructor);
            if (result == "Success")
            {
                return Deleted<string>();
            }
            return BadRequest<string>();
           
        }


#endregion
    }
}
