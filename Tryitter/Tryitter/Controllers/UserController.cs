using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Models;

namespace Tryitter.Controllers;

[ApiController]
[Route("user")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly ITryitterRepository _repository; 

    public UserController(ITryitterRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var users = _repository.GetUsers();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _repository.GetUser(id);
        if (user == null) return NotFound("User not exists");
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(string name, string email, string password)
    {
        _repository.AddUser(new User()
        {
            Name = name,
            Email = email,
            Password = password
        });
        return Created("Created", $"Usuário {name} criado com sucesso!");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted =  _repository.DeleteUser(id);
        if (isDeleted) return Ok();
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, string? name, string email)
    {
        var isUpdated = _repository.UpdateUser(id, name!, email);
        if (isUpdated) return Ok();
        return BadRequest();
    }

}

