using Microsoft.AspNetCore.Identity;
using SELP.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.DataSeeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> _userManager)
        {
            var usersCount = _userManager.Users.Count();
            if (usersCount <= 0)
            {
                var defaultUser = new User()
                {
                    UserName = "admin",
                    FirstName = "SELP_Project",
                    LastName = "Final_Project",
                    Email = "admin@project.com",
                    PhoneNumber = "123456",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(defaultUser, "Admin_123456");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(defaultUser, "Admin");
                }
                else
                {
                    // If user creation failed, throw an exception with an error message
                    throw new Exception($"Failed to create user: {result.Errors.FirstOrDefault()?.Description}");
                }
            }
        }
    }
}
