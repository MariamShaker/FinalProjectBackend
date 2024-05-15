using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Students.Queries.Models
{
    public class GetStudentByIDQuery :IRequest<Response<GetSingleStudentResponse>>
    {
        public int ID { get; set; }
        public GetStudentByIDQuery(int id)
        {
            ID= id;
        }
    }
}
