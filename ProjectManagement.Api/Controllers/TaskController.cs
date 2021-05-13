using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Tasks.Commands.CreateTask;
using ProjectManagement.Application.Features.Tasks.Commands.DeleteTask;
using ProjectManagement.Application.Features.Tasks.Commands.UpdateTask;
using ProjectManagement.Application.Features.Tasks.Queries.GetSpecificTask;
using ProjectManagement.Application.Features.Tasks.Queries.GetTaskList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all tasks
        [HttpGet("all", Name = "GetAllTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TaskListVM>>> GetAllTasks()
        {
            var taskVM = await _mediator.Send(new GetTasksListQuery());
            return Ok(taskVM);
        }

        // Get specific task
        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<ActionResult<SpecificTaskVM>> GetTaskById(Guid id)
        {
            var query = new GetSpecificTaskQuery() { TaskId = id };
            return Ok(await _mediator.Send(query));
        }

        // Create new task
        [HttpPost(Name = "AddTask")]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] CreateTaskCommand createTaskCommand)
        {
            var res = await _mediator.Send(createTaskCommand);
            return Ok(res);
        }

        // change a task
        [HttpPut(Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTask([FromBody] UpdateTaskCommand updateTaskCommand)
        {
            await _mediator.Send(updateTaskCommand);
            return NoContent();
        }

        // Delete a task
        [HttpDelete("{id}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            var delTask = new DeleteTaskCommand() { TaskId = id };
            await _mediator.Send(delTask);
            return NoContent();
        }
    }
}
