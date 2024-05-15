using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Abstract
{
    public interface IAuthorizationService
    {
        Task<string> AddRoleAsync(string roleName);
        Task<bool> IsRoleExstists(string roleName);
    }
}
