using SELP.Data.Entities;
using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Abstract
{
    public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
    {
        public Task<Subject> GetByIdWithInstructors(int Id);
        public Task<Subject> GetByIdWithStudents(int Id);
        public Task<Subject> GetByIdWithContents(int Id);
    }
}
