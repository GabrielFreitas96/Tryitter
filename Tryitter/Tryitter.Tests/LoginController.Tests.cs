using Tryitter.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tryitter.Controllers;
using Tryitter.Helpers;
using Tryitter.Models;

namespace Tryitter.Tests;

public class LoginController_Tests
{
    [Fact]
    public void LoginInvalidUserShouldReturn401UnauthorizedStatus()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        mockRepo.Setup(repo => repo.Login("email", "password")).Returns(new User());
        var controller = new Login(mockRepo.Object);
        // Act
        var result = (UnauthorizedObjectResult)controller.LoginUser("email", "passsword");

        // Assert
        result.StatusCode.Should().Be(401);
    }
    
    [Fact]
    public void LoginValidUserShouldReturn200Status()
    {
        // Arrange
        
        var mockRepo = new Mock<ITryitterRepository>();
        var hash = GenerateHash.Generate("password");
        mockRepo.Setup(repo => repo.Login("email", hash)).Returns(new User()
        {
            Email = "email",
            Password = hash,
            Name = "Cleito"
        });
        var controller = new Login(mockRepo.Object);
        
        // Act
        
        var result = (OkObjectResult)controller.LoginUser("email", "password");

        // Assert
        result.StatusCode.Should().Be(200);
    }
}
