using Microsoft.AspNetCore.Http;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Abstract
{
    public interface IContentService
    {
        public Task<List<Content>> GetContentListAsync();
        public Task<Content> GetContentByIDAsync(int id);
        public Task<string> AddContentAsync(Content content, IFormFile videoFile, IFormFile pdfFile);
        public Task<string> EditContentAsync(Content content);
        public Task<string> DeleteContentAsync(Content content);


        public Task<List<Content>>? GetContentIdsBySubjectIdAsync(int id);


    }
}
