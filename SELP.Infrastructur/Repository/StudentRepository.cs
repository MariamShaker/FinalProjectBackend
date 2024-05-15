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
    public class StudentRepository :GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region fields
        private readonly DbSet<Student> _students;
        #endregion
        #region Constructor
        public StudentRepository(ApplicationDBContext dBContext):base(dBContext) 
        {
            _students = dBContext.Set<Student>();
        }
        #endregion
        #region HandleFun
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.ToListAsync();
        }
        #endregion

    }
}
