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
    public class QuizService :IQuizService
    {
        #region fields
        private readonly IQuizRepository _quizRepository;
        private readonly ApplicationDBContext _context;

        #endregion
        #region constructor
        public QuizService(IQuizRepository quizRepository, ApplicationDBContext context)
        {
            _quizRepository = quizRepository;
            _context = context;
        }
        #endregion
        #region handle fun
        //get list content
        public async Task<List<Quiz>> GetQuizListAsync()
        {
            return await _quizRepository.GetQuizListAsync();
        }
        //get content by id

        public async Task<Quiz> GetQuizByIDAsync(int id)
        {
            var quiz = await _quizRepository.GetByIdAsync(id);
            return quiz;
        }



        #region add,edit,delete
        //  add Quiz

        public async Task<string> AddQuizAsync(Quiz quiz)
        {
            //check if the name is exist or not
            var quizResult = _quizRepository.GetTableNoTracking()
                .Where(x => x.Name.Equals(quiz.Name)).FirstOrDefault();
            if (quizResult != null)
            {
                return "Exist";
            }

            //add student class

            await _quizRepository.AddAsync(quiz);
            return "Success";
        }



        //edit Quiz
        public async Task<string> EditQuizAsync(Quiz quiz)
        {
            await _quizRepository.UpdateAsync(quiz);
            return "Success";
        }
        // delete Quiz
        public async Task<string> DeleteQuizAsync(Quiz quiz)
        {
            var truns = _quizRepository.BeginTransaction();
            try
            {
                await _quizRepository.DeleteAsync(quiz);
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



        public async Task<List<Quiz>>? GetQuizIdsByContentIdAsync(int contentId)
        {
            var QuizInfo = await _context.Set<Quiz>()
          .Where(c => c.ContentID == contentId)
          .ToListAsync();

            return QuizInfo;
        }
        #endregion
    }
}
