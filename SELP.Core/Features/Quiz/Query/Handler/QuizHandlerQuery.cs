using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Content.Query.Models;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Quiz.Query.Models;
using SELP.Core.Features.Quiz.Query.Response;
using SELP.Core.Features.Subject.Queries.Models;
using SELP.Core.Features.Subject.Queries.Response;
using SELP.Data.Entities;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Quiz.Query.Handler
{
    public class QuizHandlerQuery : ResponseHandler,
        IRequestHandler<GetQuizByIdQuery, Response<GetQuizByIdResponse>>,
        IRequestHandler<GetAllQuizQuery, Response<List<GetAllQuizResponse>>>,
        IRequestHandler<GetAllQuizForEachContent, Response<List<GetAllQuizForEachContentResponse>>>
    {

        #region fields
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;
        #endregion
        #region constructor
        public QuizHandlerQuery(IQuizService quizService,IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }


        #endregion
        #region Handle fun
        public async Task<Response<GetQuizByIdResponse>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            //service get by id 
            var response = await _quizService.GetQuizByIDAsync(request.Id);
            //check is exist
            if (response == null || response.QuizID == null) return NotFound<GetQuizByIdResponse>("Quiz is empty");
            //mapping
            var mapper = _mapper.Map<GetQuizByIdResponse>(response);
            //return response
            return Success(mapper);
        }

        public async Task<Response<List<GetAllQuizResponse>>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _quizService.GetQuizListAsync();
            if (quiz == null || quiz.Count == 0)
                return NotFound<List<GetAllQuizResponse>>("Quiz is empty");
            var SubMapper = _mapper.Map<List<GetAllQuizResponse>>(quiz);
            return Success(SubMapper);
        }
        #endregion


      

        public async Task<Response<List<GetAllQuizForEachContentResponse>>> Handle(GetAllQuizForEachContent request, CancellationToken cancellationToken)
        {
            var content = await _quizService.GetQuizIdsByContentIdAsync(request.ContentID);

            // Null Checking 
            if (content == null || content.Count == 0)
                return NotFound<List<GetAllQuizForEachContentResponse>>("Content not found or content not assign any subject ");

            // Mapping
            var mapper = _mapper.Map<List<GetAllQuizForEachContentResponse>>(content);
            return Success(mapper);
        }
    }
}
