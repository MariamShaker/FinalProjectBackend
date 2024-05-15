using AutoMapper;
using SELP.Core.Features.Instructors.Command.Models;
using SELP.Core.Features.Instructors.Queries.Models;
using SELP.Core.Features.Instructors.Queries.Response;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Mapping.InstructorMapping
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, GetInstructorByIdResponse>().ReverseMap();
            CreateMap<Instructor, GetInstructorListResponse>()
    .ForMember(dest => dest.subjectsForEachInstructors, opt => opt.MapFrom(src =>
        src.In_subjects.Where(insSubject => insSubject.subject != null)
                       .Select(insSubject => new SubjectsForEachInstructor
                       {
                           SubjectName = insSubject.subject.SubjectName
                       }).ToList()));



            CreateMap<Instructor, AddInstructorModel>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorCommandModel>().ReverseMap();
        }
    }
}
