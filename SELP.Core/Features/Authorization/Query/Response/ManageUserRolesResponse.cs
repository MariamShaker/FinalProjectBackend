using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Query.Response
{
    public class ManageUserRolesResponse
    {
        public string UserId { get; set; }
        public List<UserRoles> Roles { get; set; }

    }
    public class UserRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }
    }
}
