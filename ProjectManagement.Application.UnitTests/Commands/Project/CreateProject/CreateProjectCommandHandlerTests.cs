using AutoMapper;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProjectManagement.Application.MappingProfiles;
using ProjectManagement.Application.UnitTests.Mocks;
using Xunit;
using ProjectManagement.Application.Features.Projects.Commands.CreateProject;
using System.Threading;
using FluentAssertions;

namespace ProjectManagement.Application.UnitTests.Commands.CreateProject
{
    public class CreateProjectCommandHandlerTests
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandlerTests()
        {
            // configure mapper by passing in profiles
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

            _projectRepositoryMock = RepositoryMocks.GetProjectRepository();
        }

        [Fact]
        public async System.Threading.Tasks.Task AddProjectTest()
        {
            // Arrange
            var handler = new CreateProjectCommandHandler(_projectRepositoryMock.Object, _mapper);
            await handler.Handle(new CreateProjectCommand() { ProjectName = "Testproject 1", Description = "TestDescription."}, CancellationToken.None);
            
            // Act
            var allProjects = await _projectRepositoryMock.Object.ListAllAsync();
            
            // Assert
            allProjects.Count.Should().Be(4);
        }
    }
}
