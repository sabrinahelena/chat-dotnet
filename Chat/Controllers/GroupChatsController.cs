using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupChatsController : ControllerBase
{
    private readonly ILogger<GroupChatsController> _logger;

    public GroupChatsController(ILogger<GroupChatsController> logger)
    {
        _logger = logger;
    }
}