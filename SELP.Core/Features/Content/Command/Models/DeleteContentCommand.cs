using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Command.Models
{
    public class DeleteContentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteContentCommand(int id)
        {
            Id = id;
        }
    }
}
