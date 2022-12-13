using System;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Helpers;
using Tryitter.JWT;
using Microsoft.AspNetCore.Authorization;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("login")]
    public class Login : Controller
	{
        private readonly ITryitterRepository _repository;
        public Login(ITryitterRepository repository)
        {
            _repository = repository;
        }
		[HttpPost]
        [AllowAnonymous]
        public IActionResult  LoginUser(string email, string password)
		{
			var hashPassword = GenerateHash.Generate(password);
			var user = _repository.Login(email, hashPassword);
			if(user == null)
			{
				return Unauthorized("Email ou senha incorreta");
			}
			return Ok(Token.GenerateToken(user));

		}
	}
}

