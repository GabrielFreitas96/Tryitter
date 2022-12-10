using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Models;

namespace Tryitter.Controllers;

[ApiController]
[Route("api")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITryitterRepository _repository; 

    public HomeController(ITryitterRepository repository)
    {
        _repository = repository;
    }
    [HttpGet("teste")]
    public IActionResult GetTeste()
    {
        return Ok("Está funcionando");
    }

}

