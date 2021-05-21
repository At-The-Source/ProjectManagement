using Microsoft.AspNetCore.Identity;
using ProjectManagement.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Identity.Seed
{
    public class UserCreator
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager)
        {
            var appUser = new ApplicationUser
            {
                FirstName = "Thomas",
                LastName = "Karlsson",
                UserName = "thomas",
                Email = "thomas@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(appUser.Email);
            if (user == null) { await userManager.CreateAsync(appUser, "Haxx0r?"); }
        }
    }
}
