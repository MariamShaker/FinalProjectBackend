using MediatR;
using SELP.Core.Bases;


namespace SELP.Core.Features.Authorization.Command.Models
{
    public class AddRoleCommand:IRequest<Response<string>>
    {
        public string Name { get; set; }
    }
}
