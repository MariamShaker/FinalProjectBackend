using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Content.Command.Models;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Core.Features.Subject.Command.Models;
using SELP.Data.Entities;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Command.Handler
{
    public class ContentCommandHandler : ResponseHandler,
                IRequestHandler<AddContentCommand, Response<string>>,
                IRequestHandler<UpdateContentCommand, Response<string>>,
                IRequestHandler<DeleteContentCommand, Response<string>>

    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly IContentService _contentService;
        #endregion
        #region constructor
        public ContentCommandHandler(IMapper mapper, IContentService contentService)
        {
            _mapper = mapper;
            _contentService = contentService;
        }


        #endregion
        #region handle function
        //add content
        public async Task<Response<string>> Handle(AddContentCommand request, CancellationToken cancellationToken)
        {

            // mapping detween request and student
            var contentMapper = _mapper.Map<Data.Entities.Content>(request);
            //add 
            var result = await _contentService.AddContentAsync(contentMapper,request.video,request.pdf);
            //check if it exist
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Name is exist ");
            }
            else if (result == "Success")
            {
                return Created("Added Successfully");
            }
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            // Notice i have used the same mapping for add and update because they are the same
            var content = await _contentService.GetContentByIDAsync(request.ContentID);
            if (content == null)
                return BadRequest<string>();


            //var InstructorMapper = _mapper.Map<Data.Entites.Instructor>(request);
            var contentMapper = _mapper.Map(request, content);

            var result = await _contentService.EditContentAsync(contentMapper);
            if (result == "Success") return Success<string>("Update Successfully ");
            else return BadRequest<string>();
            #endregion
        }
        //delete
        public async Task<Response<string>> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            //check if id is exist
            var content = await _contentService.GetContentByIDAsync(request.Id);
            //return not found
            if (content == null)
            {
                return NotFound<string>("Content Is Not Found");
            }
            var result = await _contentService.DeleteContentAsync(content);
            if (result == "Success")
            {
                return Deleted<string>();
            }
            return BadRequest<string>();
        }
    }
}
