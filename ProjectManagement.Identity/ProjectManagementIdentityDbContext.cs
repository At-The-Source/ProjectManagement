using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Identity.Models;

namespace ProjectManagement.Identity
{
    public class ProjectManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectManagementIdentityDbContext(DbContextOptions<ProjectManagementIdentityDbContext> options) : base(options)
        {
                
        }
    }
}
