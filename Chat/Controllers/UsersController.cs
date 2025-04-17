using Application.UseCases.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Users.Commands.AuthenticateUser;
using Application.UseCases.Users.Queries.GetUser;

namespace Chat.Controllers;

/// <summary>
/// This class handles the management of user-related operations, including
/// user registration, login, and retrieval of user information.
/// </summary>
[ApiController]
[Route("users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Registers a new user by accepting their desired username and checking
    /// if it's available. If available, creates a new user in the database.
    /// </summary>
    /// <param name="command">The user data containing the username.</param>
    /// <returns>A response indicating whether the registration was successful.</returns>
    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Logs in a user by validating their username and returning an authentication token.
    /// </summary>
    /// <param name="command">The login request containing the user's credentials.</param>
    /// <returns>A confirmation for the logged-in user.</returns>
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