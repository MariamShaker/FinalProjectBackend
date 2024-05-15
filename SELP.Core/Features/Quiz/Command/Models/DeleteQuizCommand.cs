using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Quiz.Command.Models
{
    public class DeleteQuizCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteQuizCommand(int id)
        {
            Id = id;
        }
    }
}
