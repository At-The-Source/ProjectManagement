using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Users.Commands.CreateUser;
using ProjectManagement.Application.Features.Users.Commands.DeleteUser;
using ProjectManagement.Application.Features.Users.Commands.UpdateUser;
using ProjectManagement.Application.Features.Users.Queries.GetSpecificUser;
using ProjectManagement.Application.Features.Users.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all users
        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserListVM>>> GetAllUsers()
        {
            var userVM = await _mediator.Send(new GetUserListQuery());
            return Ok(userVM);
        }

        // Get specific user
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<SpecificUserVM>> GetUserById(Guid id)
        {
            var query = new GetSpecificUserQuery() { UserId = id };
            return Ok(await _mediator.Send(query));
        }

        // Create new user
        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var creationResponse = await _mediator.Send(createUserCommand);
            return Ok(creationResponse);
        }

        // Change a user
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }

        // Delete a user
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var deleteUser = new DeleteUserCommand() { UserId = id };
            await _mediator.Send(deleteUser);
            return NoContent();
        }
    }
}
