using AutoMapper;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Quiz.Command.Models;
using SELP.Core.Features.Quiz.Query.Response;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Mapping.ContentMapping
{
    public class QuizProfile:Profile
    {
        public QuizProfile()
        {
            CreateMap<Quiz, GetAllQuizResponse>().ReverseMap();
            CreateMap<Quiz, GetQuizByIdResponse>().ReverseMap();
            CreateMap<AddQuizCommand, Quiz>();
            CreateMap<UpdateQuizCommand, Quiz>()
              .ForMember(dest => dest.QuizID, opt => opt.Ignore());


            CreateMap<Quiz, GetAllQuizForEachContentResponse>();
        }
    }
}
