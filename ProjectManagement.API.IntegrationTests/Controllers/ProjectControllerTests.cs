using Newtonsoft.Json;
using ProjectManagement.Api;
using ProjectManagement.API.IntegrationTests.Common;
using ProjectManagement.Application.Features.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace ProjectManagement.API.IntegrationTests.Controllers
{
    public class ProjectControllerTests : IClassFixture<WebAppFactory<Startup>>
    {
        private readonly WebAppFactory<Startup> _factory;

        public ProjectControllerTests(WebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task SaveProjectsToDbTest()
        {
            // Call API
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/project/all");
            response.EnsureSuccessStatusCode();
            // Convert response to list of VM and Assert
            var str = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ProjectListVM>>(str);
            result.Should().BeOfType<List<ProjectListVM>>().Which.Should().NotBeEmpty()
                .And.OnlyHaveUniqueItems();
        }
    }
}
