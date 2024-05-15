using AutoMapper;
using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Content.Query.Models;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Subject.Queries.Models;
using SELP.Core.Features.Subject.Queries.Response;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Query.Handler
{
    public class ContentHandlerQuery : ResponseHandler,
        IRequestHandler<GetContentByIdQuery, Response<GetContentByIdResponse>>,
        IRequestHandler<GetAllContentQuery, Response<List<GetAllContentResponse>>>,
        IRequestHandler<GetContentForEachSubject, Response<List<GetContentForEachSubjectResponse>>>
    {

        #region fields
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;
        #endregion
        #region constructor
        public ContentHandlerQuery(IContentService contentService,IMapper mapper)
        {
            _contentService = contentService;
           _mapper = mapper;
        }


        #endregion
        #region Handle fun
        public async Task<Response<GetContentByIdResponse>> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            //service get by id 
            var response = await _contentService.GetContentByIDAsync(request.Id);
            //check is exist
            if (response == null || response.ContentID == null) return NotFound<GetContentByIdResponse>("Content is empty or not found");
            //mapping
            var mapper = _mapper.Map<GetContentByIdResponse>(response);
            //return response
            return Success(mapper);
        }

        public async Task<Response<List<GetAllContentResponse>>> Handle(GetAllContentQuery request, CancellationToken cancellationToken)
        {
            var content = await _contentService.GetContentListAsync();
            if (content == null || content.Count == 0)
                return NotFound<List<GetAllContentResponse>>("content is empty");
            var SubMapper = _mapper.Map<List<GetAllContentResponse>>(content);
            return Success(SubMapper);
        }
        #endregion


        public async Task<Response<List<GetContentForEachSubjectResponse>>> Handle(GetContentForEachSubject request, CancellationToken cancellationToken)
        {
            var content = await _contentService.GetContentIdsBySubjectIdAsync(request.SubId);

            // Null Checking 
            if (content == null || content.Count == 0)
                return NotFound<List<GetContentForEachSubjectResponse>>("Content not found or content not assign any subject ");

            // Mapping
            var mapper = _mapper.Map<List<GetContentForEachSubjectResponse>>(content);
            return Success(mapper);
        }
    }
}
