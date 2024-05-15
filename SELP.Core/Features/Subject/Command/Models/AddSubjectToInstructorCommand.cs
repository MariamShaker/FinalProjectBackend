﻿using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Command.Models
{
    public class AddSubjectToInstructorCommand : IRequest<Response<string>>
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
    }
}