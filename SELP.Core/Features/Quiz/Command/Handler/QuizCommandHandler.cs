using AutoMapper;
using MediatR;
using SELP.Core.Bases;

using SELP.Core.Features.Quiz.Command.Models;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Quiz.Command.Handler
{
    public class QuizCommandHandler : ResponseHandler,
                IRequestHandler<AddQuizCommand, Response<string>>,
                IRequestHandler<UpdateQuizCommand, Response<string>>,
                IRequestHandler<DeleteQuizCommand, Response<string>>
    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly IQuizService _quizService;
        #endregion
        #region constructor
        public QuizCommandHandler(IMapper mapper, IQuizService quizService)
        {
            _mapper = mapper;
            _quizService = quizService;
        }


        #endregion
        #region handle function
      
       
        //add
        public async Task<Response<string>> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            // mapping detween request and student
            var quizMapper = _mapper.Map<Data.Entities.Quiz>(request);
            //add 
            var result = await _quizService.AddQuizAsync(quizMapper);
            //check if it exist
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Name is exist ");
            }
            else if (result == "Success")
            {
                return Created("Added Successfully");
            }
            else return BadRequest<string>();
        }


        //edit
        public async Task<Response<string>> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            // Notice i have used the same mapping for add and update because they are the same
            var quiz = await _quizService.GetQuizByIDAsync(request.QuizID);

            if (quiz == null)
                return BadRequest<string>();


            
            var contentMapper = _mapper.Map(request, quiz);

            var result = await _quizService.EditQuizAsync(contentMapper);
            if (result == "Success") return Success<string>("Update Successfully ");
            else return BadRequest<string>();
        }


        //delete
        public async Task<Response<string>> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {

            //check if id is exist
            var quiz = await _quizService.GetQuizByIDAsync(request.Id);
            //return not found
            if (quiz == null)
            {
                return NotFound<string>("Quiz Is Not Found");
            }
            var result = await _quizService.DeleteQuizAsync(quiz);
            if (result == "Success")
            {
                return Deleted<string>();
            }
            return BadRequest<string>();
        }
        #endregion
    }
}
