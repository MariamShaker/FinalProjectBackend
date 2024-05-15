using SELP.Data.Entities;
using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Abstract
{
    public interface IInstructorRepository : IGenericRepositoryAsync<Instructor>
    {
        public Task<List<Instructor>> GetInstructorListAsync();
    }
}
