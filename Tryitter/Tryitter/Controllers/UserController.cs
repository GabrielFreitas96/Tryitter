using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Models;
using Tryitter.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Tryitter.Controllers;

[ApiController]
[Route("user")]
public class UserController : Controller
{
    private readonly ILogger<UserController>? _logger;
    private readonly ITryitterRepository _repository; 

    public UserController(ITryitterRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        var users = _repository.GetUsers();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        if(User.Identity.Name != Convert.ToString(id))
        {
            return Unauthorized($"{id} não logado");
        }
        var user = _repository.GetUser(id);
        if (user == null) return NotFound("User not exists");
        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Create(string name, string email, string password)
    {
        _repository.AddUser(new User()
        {
            Name = name,
            Email = email,
            Password = GenerateHash.Generate(password),
        });
        return Created("Created", $"Usuário {name} criado com sucesso!");
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        if (User.Identity.Name != Convert.ToString(id))
        {
            return Unauthorized($"{id} não logado");
        }
        var isDeleted =  _repository.DeleteUser(id);
        if (isDeleted) return Ok();
        return BadRequest();
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Update(int id, string? name, string email)
    {
        if (User.Identity.Name != Convert.ToString(id))
        {
            return Unauthorized($"{id} não logado");
        }
        var isUpdated = _repository.UpdateUser(id, name!, email);
        if (isUpdated) return Ok();
        return BadRequest();
    }

}

