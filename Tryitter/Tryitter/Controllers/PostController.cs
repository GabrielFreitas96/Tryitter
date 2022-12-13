using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public IActionResult Get()
    {
        var posts = _repository.GetPosts();
        return Ok(posts);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        var resultId = _repository.GetOwnerPost(id);
        if (resultId == null)
        {
            return NotFound($"Post {id} not Found");
        }
        else if (User.Identity.Name != Convert.ToString(resultId))
        {
            return Unauthorized("Usuário não logado");
        }
        var posts = _repository.GetPost(id);
        if (posts == null) return NotFound("Post not exists");
        return Ok(posts);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(string content, int userId)
    {
        var createdPost = _repository.AddPost(content, userId);
        if (createdPost == null) return BadRequest();
        return Created("Post Created", createdPost);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var resultId = _repository.GetOwnerPost(id);
        if (resultId == null)
        {
            return NotFound($"Post {id} not Found");
        }
        else if (User.Identity.Name != Convert.ToString(resultId))
        {
            return Unauthorized("Usuário não logado");
        }
        var isDeleted = _repository.DeletePost(id);
        if (isDeleted) return Ok();
        return BadRequest();
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Update(int id, string? content)
    {
        var resultId = _repository.GetOwnerPost(id);
        if (resultId == null)
        {
            return NotFound($"Post {id} not Found");
        }
        else if (User.Identity.Name != Convert.ToString(resultId))
        {
            return Unauthorized("Usuário não logado");
        }
        var isUpdated = _repository.UpdatePost(id, content!);
        if (isUpdated) return Ok();
        return BadRequest();
    }


}