using ProjectManagement.Domain.Entities;
using ProjectManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.API.IntegrationTests.Common
{
    public class DbTestTools
    {
        public static void DbTestInitialization(ProjectManagementDbContext context)
        {
            context.Projects.Add(
                new Project
                {
                    ProjectId = Guid.Parse("3cc4b084-de16-4e4f-9fd7-0e649e87e724"),
                    ProjectName = "TestProject 1",
                    Description = "This is first in-memory test project."
                }
            );
            context.Projects.Add(
                new Project
                {
                    ProjectId = Guid.Parse("8d5e7d6e-35bd-4a24-b850-aa61cf6a29e5"),
                    ProjectName = "TestProject 2",
                    Description = "This is second in-memory test project."
                }
            );
            context.Projects.Add(
                new Project
                {
                    ProjectId = Guid.Parse("344cdc7f-4b19-45da-b360-110344951599"),
                    ProjectName = "TestProject 3",
                    Description = "This is third in-memory test project."
                }
            );

            context.SaveChanges();
        }
    }
}
