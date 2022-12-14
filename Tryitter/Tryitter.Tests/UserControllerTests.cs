using System.Security.Claims;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tryitter.Controllers;
using Tryitter.Models;
using Tryitter.Repository;

namespace Tryitter.Tests;

public class UserControllerTests
{
    [Fact]
    public void GetUsersShouldReturn200Status()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        mockRepo.Setup(repo => repo.GetUsers()).Returns(new List<User>());
        var controller = new UserController(mockRepo.Object);
        // Act
        var result = (OkObjectResult)controller.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public void GetUserShouldReturn200StatusWithToken()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        var mockedUser = new User()
        {
            Name = "Sr Tito",
            Password = "1234567899",
            Email = "emailll"
        };
        mockRepo.Setup(repo => repo.GetUser(1)).Returns(mockedUser);
        var controller = new UserController(mockRepo.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "1"),
    
        }, "mock"));
        controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        // Act
        
        var response = (OkObjectResult)controller.GetById(1);

        // Assert
        response.StatusCode.Should().Be(200);
        response.Value.Should().Be(mockedUser);
        response.Should().BeOfType<OkObjectResult>();
    }
    
    
    [Fact]
    public void GetUserShouldReturn401StatusWithoutToken()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        var mockedUser = new User()
        {
            Name = "Sr Tito",
            Password = "1234567899",
            Email = "emailll"
        };
        mockRepo.Setup(repo => repo.GetUser(1)).Returns(mockedUser);
        var controller = new UserController(mockRepo.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "No auth"),
    
        }, "mock"));
        controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        // Act
        
        var response = (UnauthorizedObjectResult)controller.GetById(1);

        // Assert
        response.StatusCode.Should().Be(401);
        response.Value.Should().NotBe(mockedUser);
        response.Should().BeOfType<UnauthorizedObjectResult>();
    }
    
    [Theory]
    [InlineData("luisita", "trybes2", "luisita@gmail.com")]
    [InlineData("Mayara", "trybe1", "luisita442@gmail.com")]
    [InlineData("Rahel", "123456", "luisito2321@gmail.com")]
    [InlineData("Marina", "software", "hav@gmail.com")]
    public void CreateUserWithSuccess(string name, string password, string email)
    {
        User user = new User 
        {
            Email = email,
            Name = name,
            Password = password
        };
        var mockObject = new Mock<ITryitterRepository>();
        mockObject.Setup(x => x.AddUser(user));

        var response = (CreatedResult)new UserController(mockObject.Object).Create(name, email ,password);
        
        response.StatusCode.Should().Be(201);
        response.Value.Should().Be($"Usuário {name} criado com sucesso!");
    }
}