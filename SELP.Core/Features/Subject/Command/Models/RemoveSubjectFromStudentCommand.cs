﻿using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Command.Models
{
    public class RemoveSubjectFromStudentCommand:IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
