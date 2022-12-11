using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;

namespace Tryitter.Controllers;

[ApiController]
[Route("post")]
public class PostController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly ITryitterRepository _repository; 

    public PostController(ITryitterRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var posts = _repository.GetPosts();
        return Ok(posts);
    }

}