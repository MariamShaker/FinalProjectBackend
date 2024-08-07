﻿using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Subject.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Queries.Models
{
    public class GetSubjectByContent : IRequest<Response<List<GetSubjectByContentResponse>>>
    {
        public int ContentId { get; set; }
        public GetSubjectByContent(int id)
        {
            ContentId = id;
        }
    }
}
