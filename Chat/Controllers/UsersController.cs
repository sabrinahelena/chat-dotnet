using Application.UseCases.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Users.Commands.AuthenticateUser;
using Application.UseCases.Users.Queries.GetUser;

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
    public async Task<ActionResult<AuthenticateUserResponse>> AuthenticateUser([FromBody] AuthenticateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        if (!result.Success)
            return Unauthorized(new { Message = "Login ou senha inválidos." });

        return Ok(result);
    }

    /// <summary>
    /// Get information about a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>Returns user details.</returns>
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<GetUserResponse>> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new GetUserQuery(userId),
            cancellationToken);

        return Ok(response);
    }
}