using Application.UseCases.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers;

[ApiController]
[Route("users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <returns>Returns the created user information.</returns>
    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }
    
    /// <summary>
    /// Authenticate a user.
    /// </summary>
    /// <returns>Returns authentication result (e.g., token or success status).</returns>
    [HttpPost("login")]
    public Task<ActionResult> AuthenticateUser()
    {
        // Logic to authenticate user
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get information about a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>Returns user details.</returns>
    [HttpGet("{userId:guid}")]
    public Task<ActionResult> GetUserById(Guid userId)
    {
        // Logic to get user by ID
        throw new NotImplementedException();
    }
}