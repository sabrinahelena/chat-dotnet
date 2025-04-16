using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers;

[ApiController]
[Route("rooms")]
public class GroupChatsController : ControllerBase
{
    private readonly ILogger<GroupChatsController> _logger;

    public GroupChatsController(ILogger<GroupChatsController> logger)
    {
        _logger = logger;
    }
}