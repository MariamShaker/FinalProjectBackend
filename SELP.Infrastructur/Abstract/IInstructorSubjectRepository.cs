using SELP.Data.Entities;
using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Abstracts
{
    public interface IInstructorSubjectRepository:IGenericRepositoryAsync<Ins_Subject>
    {
        public Task<Ins_Subject> GetInstructorSubject(int InsID, int SubId);
    }

}
