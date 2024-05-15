
using AutoMapper;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Core.Features.Subject.Command.Models;
using SELP.Core.Features.Subject.Queries.Response;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Mapping.SubjectMapping
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, GetSubjectByIdResponse>().ReverseMap();
            CreateMap<Subject, GetAllSubjectResponse>().ReverseMap();
            CreateMap<Subject, AddSubjectCommand>().ReverseMap();
            CreateMap<UpdateSubjectCommand, Subject>()
             .ForMember(dest => dest.SubID, opt => opt.Ignore());


            CreateMap<Subject, GetSubjectByInstructorResponse>().ReverseMap();
            CreateMap<Subject, GetSubjectByStudentResponse>()
      .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.SubjectName))
      .ForMember(dest => dest.grade, opt => opt.MapFrom(src => src.SubjectStudent.Sum(ss => ss.grade) / src.SubjectStudent.Count));



            CreateMap<Subject, GetSubjectByContentResponse>().ReverseMap();
           


        }
    }
}
