using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SELP.Data.Entities;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Data;
using SELP.Infrastructur.Repository;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Implementation
{
    public class ContentService : IContentService
    {
        #region fields
        private readonly IContentRepository _contentRepository;
        private readonly ApplicationDBContext _context;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion
        #region constructor
        public ContentService(IContentRepository contentRepository, ApplicationDBContext context, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
           _contentRepository = contentRepository;
            this._context = context;
               this._fileService = fileService;
                this._httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region handle fun
        //get list content
        public async Task<List<Content>> GetContentListAsync()
        {
            return await _contentRepository.GetContentListAsync();
        }
        //get content by id

        public async Task<Content> GetContentByIDAsync(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            return content;
        }


        //  add content

        public async Task<string> AddContentAsync(Content content,IFormFile videoFile, IFormFile pdfFile)
        {
            //check if the name is exist or not
            var contentResult = _contentRepository.GetTableNoTracking()
                .Where(x => x.Name.Equals(content.Name)).FirstOrDefault();
            if (contentResult != null)
            {
                return "Exist";
            }

            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var videoUrl = await _fileService.UploadImage("Contents/videos", videoFile);
          
            switch (videoUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            var pdfUrl = await _fileService.UploadImage("Contents/Material", pdfFile);
            switch (pdfUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }

            content.pdf = baseUrl + pdfUrl;
            content.video = baseUrl + videoUrl;
            try
            {
                await _contentRepository.AddAsync(content);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }

           
        }



        //edit content
        public async Task<string> EditContentAsync(Content content)
        {
            await _contentRepository.UpdateAsync(content);
            return "Success";
        }
        // delete content
        public async Task<string> DeleteContentAsync( Content content)
        {
            var truns = _contentRepository.BeginTransaction();
            try
            {
                await _contentRepository.DeleteAsync(content);
                await truns.CommitAsync();
                return "Success";
            }
            catch
            {
                await truns.RollbackAsync();
                return "Failds";
            }
        }
        #endregion




        public async Task<List<Content>>? GetContentIdsBySubjectIdAsync(int subjectId)
        {
            var contentInfo = await _context.Set<Content>()
          .Where(c => c.subjectID == subjectId) // Assuming SubjectID is the correct property name
          .ToListAsync();

            return contentInfo;
        }
    }
}
