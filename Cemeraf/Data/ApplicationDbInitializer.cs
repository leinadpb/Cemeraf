using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.Data
{
    public static class ApplicationDbInitializer
    {

        public static async Task<bool> SeedUsers(UserManager<CemerafUser> userManager, string password)
        {
            if (userManager.FindByEmailAsync("digrape07@gmail.com").Result == null)
            {
                CemerafUser user = new CemerafUser
                {
                    UserName = "digrape07@gmail.com",
                    Email = "digrape07@gmail.com",
                    IsAdmin = true,
                    Firstname = "Admin",
                    Lastname = "Admin"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "ADMINISTRATORS");
                    return true;
                }
            }
            return false;
        }
    }
}
