using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        // Registers the DB context, Sql server w. connectionstr. & the specified repo types and their implementation.
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProjectManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
