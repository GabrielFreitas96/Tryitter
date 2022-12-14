using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tryitter.Controllers;
using Tryitter.Models;
using Tryitter.Repository;

namespace Tryitter.Tests;

public class PostController_Test
{
    [Fact]
    public void GetPostsShouldReturn200Status()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        mockRepo.Setup(repo => repo.GetPosts()).Returns(new List<Post>());
        var controller = new PostController(mockRepo.Object);
        // Act
        var result = (OkObjectResult)controller.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public void CreatePostShouldReturn201Status()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        mockRepo.Setup(repo => repo.AddPost("Post maneiro", 0)).Returns(new Post()
        {
            Content = "Post maneiro",
            UserId = 0
        });
        var controller = new PostController(mockRepo.Object);
        // Act
        var result = (CreatedResult)controller.Create("Post maneiro", 0);

        // Assert
        result.StatusCode.Should().Be(201);
        result.Value.Should().BeOfType<Post>();
    }
    
    [Fact]
    public void CreatePostShouldReturn400StatusBadRequest()
    {
        // Arrange
        var mockRepo = new Mock<ITryitterRepository>();
        mockRepo.Setup(repo => repo.AddPost("Post maneiro", 0));
        var controller = new PostController(mockRepo.Object);
        // Act
        var result = (BadRequestResult)controller.Create("Post maneiro", 0);

        // Assert
        result.StatusCode.Should().Be(400);
    }
}