using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Projects;
using ProjectManagement.Application.Features.Projects.Commands.CreateProject;
using ProjectManagement.Application.Features.Projects.Commands.DeleteProject;
using ProjectManagement.Application.Features.Projects.Commands.UpdateProject;
using ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all projects
        [HttpGet("all", Name = "GetAllProjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProjectListVM>>> GetAllProjects()
        {
            var projectVM = await _mediator.Send(new GetProjectsListQuery());
            return Ok(projectVM);
        }

        // Get all projects with tasks
        [HttpGet("allwithtasks", Name = "GetAllProjectsWithTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProjectTaskListVM>>> GetAllProjectsWithTasks(bool includeHistory)
        {
            var projectTaskVM = await _mediator.Send(new GetProjectsListWithTasksQuery() { IncludeHistory = includeHistory }) ;
            return Ok(projectTaskVM);
        }

        // Get specific project
        [HttpGet("{id}", Name = "GetProjectById")]
        public async Task<ActionResult<SpecificProjectVM>> GetTaskById(Guid id)
        {
            var query = new GetSpecificProjectQuery() { ProjectId = id };
            return Ok(await _mediator.Send(query));
        }

        // Create new project
        // TODO: project POST should return dto containing a command response, now it is temporarly returning an id.
        [HttpPost(Name = "AddProject")]
        public async Task<ActionResult<Guid>> CreateProject([FromBody] CreateProjectCommand createProjectCommand)
        {
            var createResponse = await _mediator.Send(createProjectCommand);
            return Ok(createResponse);
        }

        // change a project
        [HttpPut(Name = "UpdateProject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProject([FromBody] UpdateProjectCommand updateProjectCommand)
        {
            await _mediator.Send(updateProjectCommand);
            return NoContent();
        }

        // Delete a project
        [HttpDelete("{id}", Name = "DeleteProject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            var deleteProject = new DeleteProjectCommand() { ProjectId = id };
            await _mediator.Send(deleteProject);
            return NoContent();
        }
    }
}
