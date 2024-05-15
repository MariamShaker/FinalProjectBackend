using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Abstract
{
    public interface IQuizService
    {
        public Task<List<Quiz>> GetQuizListAsync();
        public Task<Quiz> GetQuizByIDAsync(int id);

        public Task<string> AddQuizAsync(Quiz quiz);
        public Task<string> EditQuizAsync(Quiz quiz);
        public Task<string> DeleteQuizAsync(Quiz quiz);


        public Task<List<Quiz>>? GetQuizIdsByContentIdAsync(int id);
    }
}
