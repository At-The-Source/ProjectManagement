using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        // Register Automapper & MediatR with the Service collection, due to not having direct access 
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // TODO: Add Mediatr & AutoMapper to services.
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
