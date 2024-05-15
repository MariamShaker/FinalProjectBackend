using Microsoft.EntityFrameworkCore;
using SELP.Data.Entities;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Data;
using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Repository
{
    public class ContentRepository : GenericRepositoryAsync<Content>, IContentRepository
    {
        #region Fields and properities
        private DbSet<Content> _content { get; set; }
        #endregion

        #region constructor
        public ContentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _content = dBContext.Set<Content>();
        }
        #endregion

        #region handel fun
        public async Task<List<Content>> GetContentListAsync()
        {
            return await _content.ToListAsync();
        }
        #endregion
    }
}
