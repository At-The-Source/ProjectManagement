using Moq;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProjectRepository> GetProjectRepository()
        {
            // Create dummy projects
            var projects = new List<Project>
            {
                new Project
                {
                    ProjectId = Guid.Parse("de2dbc42-98b0-4951-bb21-1847eb623ffe"),
                    ProjectName = "MockProject 1",
                    Description = "This is first mock project."
                },
                new Project
                {
                    ProjectId = Guid.Parse("3230901b-d696-4424-956c-c81dcf817b7b"),
                    ProjectName = "MockProject 2",
                    Description = "This is second mock project."
                },
                new Project
                {
                    ProjectId = Guid.Parse("f945eadd-88e7-48f4-b83d-52b3531cad8a"),
                    ProjectName = "MockProject 3",
                    Description = "This is third mock project."
                }
            };

            // Create mock implementation of IAsyncRepository & return all projects
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(repo => repo.ListAllAsync()).ReturnsAsync(projects);

            // On project add
            projectRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Project>()))
                .ReturnsAsync((Project project) => 
                {
                    projects.Add(project);
                    return project;
                });

            // On specifc


            return projectRepositoryMock;
        }

        public static Mock<ITaskRepository> GetTaskRepository()
        {
            var tasks = new List<Domain.Entities.Task>
            {
                new Domain.Entities.Task
                {
                    TaskId = Guid.Parse("7323637a-8ddf-499c-8c3a-0196bfadaa4a"),
                    TaskName = "MockTask 1",
                    Description = "This is Mock task 1",
                    StartDate = DateTime.Now.AddDays(3),
                    StopDate = DateTime.Now.AddDays(5)
                },
                new Domain.Entities.Task
                {
                    TaskId = Guid.Parse("289636fb-aeec-4f39-b1f2-299aa6ef9a6e"),
                    TaskName = "MockTask 2",
                    Description = "This is Mock task 2",
                    StartDate = DateTime.Now.AddDays(5),
                    StopDate = DateTime.Now.AddDays(8)
                },
                new Domain.Entities.Task
                {
                    TaskId = Guid.Parse("484379c7-515e-4bd6-a06c-5289f1572db1"),
                    TaskName = "MockTask 3",
                    Description = "This is Mock task 3",
                    StartDate = DateTime.Now.AddDays(1),
                    StopDate = DateTime.Now.AddDays(7)
                },

            };
            
            // List all
            var taskRepositoryMock = new Mock<ITaskRepository>();
            taskRepositoryMock.Setup(repo => repo.ListAllAsync()).ReturnsAsync(tasks);

            return taskRepositoryMock;
        }

        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<User>
            {
                new User
                {
                    UserId = Guid.Parse("58b2c545-5e01-445a-ba6a-2de5279af37b"),
                    FirstName = "MockFirstName 1",
                    LastName = "MockLastName 1",
                    UserName = "MockUserName 1"
                },
               new User
                {
                    UserId = Guid.Parse("789cacf1-5b48-419a-9c84-06d0b8cce283"),
                    FirstName = "MockFirstName 2",
                    LastName = "MockLastName 2",
                    UserName = "MockUserName 2"
                },
               new User
                {
                    UserId = Guid.Parse("3df97651-0054-4db0-a548-abd39ea2d222"),
                    FirstName = "MockFirstName 3",
                    LastName = "MockLastName 3",
                    UserName = "MockUserName 3"
                }

            };

            // List all
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.ListAllAsync()).ReturnsAsync(users);

            return userRepositoryMock;
        }
    }
}
