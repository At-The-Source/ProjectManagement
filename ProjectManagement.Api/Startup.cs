using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManagement.Application;
using ProjectManagement.Persistence;
using Microsoft.OpenApi.Models;
using ProjectManagement.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Api.Exceptions;

namespace ProjectManagement.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Swagger
            AddSwagger(services);

            // Add services from other layers
            services.AddApplicationServices();
            services.AddPersistenceServices(Configuration);
            services.AddIdentityService(Configuration);

            // Support for working with controllers
            services.AddControllers();

            // Opens up API to be used by client-side technologies (UI layer)
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Authentication
            app.UseAuthentication();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectManagement API");
                x.RoutePrefix = string.Empty;
            });

            // exception handler
            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            // Authorization
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Enable routing to controllers
                endpoints.MapControllers();
            });
        }

        // Swagger documentation & security
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Auth header using Bearer scheme. \n
                                Enter 'Bearer' and then your token in the input below. \n
                                Example: Bearer 3245ghder",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                    });

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "ProjectManagement API",
                });

            });
        }
    }
}
