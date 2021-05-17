using AutoMapper;
using Moq;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Application.Features.Projects;
using ProjectManagement.Application.MappingProfiles;
using ProjectManagement.Application.UnitTests.Mocks;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.Application.UnitTests.Queries.GetSpecificProject
{
    public class GetSpecificProjectQueryHandlerTests
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly IMapper _mapper;

        public GetSpecificProjectQueryHandlerTests()
        {
            // configure mapper by passing in profiles
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

            // Get mock repo
            _projectRepositoryMock = RepositoryMocks.GetProjectRepository();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetProjectsListTest()
        {
            // TODO: Finish specificqueryhandler test
            // Arrange
            //var projectHandler = new GetSpecificProjectQueryHandler(_mapper, _projectRepositoryMock.Object);
            // Act
            //var result = await projectHandler.Handle(new GetSpecificProjectQuery(), CancellationToken.None);
            // Assert
            //result.Should().BeOfType<List<ProjectListVM>>().Which.Count.Should().Be(3);
        }
    }
}
