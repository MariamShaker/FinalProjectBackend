using MediatR;
using Microsoft.AspNetCore.Http;
using SELP.Core.Bases;
using System.ComponentModel.DataAnnotations;


namespace SELP.Core.Features.Instructors.Command.Models
{
    public class UpdateInstructorCommandModel : IRequest<Response<string>>

    {
        public int InsId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? position { get; set; }
        public string? phone { get; set; }
        [Required]
        public string? Email { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
