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
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var posts = _repository.GetPost(id);
        if (posts == null) return NotFound("Post not exists");
        return Ok(posts);
    }

    [HttpPost]
    public IActionResult Create(string content, int userId)
    {
        var createdPost = _repository.AddPost(content, userId);
        if (createdPost == null) return BadRequest();
        return Created("Post Created", createdPost);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _repository.DeletePost(id);
        if (isDeleted) return Ok();
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, string? content)
    {
        var isUpdated = _repository.UpdatePost(id, content!);
        if (isUpdated) return Ok();
        return BadRequest();
    }


}