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
    public class QuizRepository : GenericRepositoryAsync<Quiz>, IQuizRepository
    {
        #region Fields and properities
        private DbSet<Quiz> _quiz { get; set; }
        #endregion

        #region constructor
        public QuizRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _quiz = dBContext.Set<Quiz>();
        }
        #endregion

        #region handel fun
        public async Task<List<Quiz>> GetQuizListAsync()
        {
            return await _quiz.ToListAsync();
        }
        #endregion
    }
}
