using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using SELP.Data.Entities.Identity;
using SELP.Infrastructur.Data;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _dbContext;
        #endregion
        #region Fields
        public AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationDBContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;

        }
        #endregion
        #region Fields

        public async Task<string> AddRoleAsync(string roleName)
        {
           var RoleExist=await _roleManager.RoleExistsAsync(roleName);
            if (RoleExist==true) { 
                return "RoleExists";
                
            }
            var IdentityRole = new IdentityRole();
            IdentityRole.Name = roleName;
            var result = await _roleManager.CreateAsync(IdentityRole);
            if (result.Succeeded)
                return "Success";
            else
                return "Failed";
        }
      
        public async Task<bool> IsRoleExstists(string roleName) => await _roleManager.RoleExistsAsync(roleName);
        #endregion
    }
}
