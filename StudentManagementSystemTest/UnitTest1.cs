using Moq;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Controllers;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;

public class UnitTest1
{
    private readonly Mock<IRepository<User>> _mockUserRepo;
    private readonly Mock<IRepository<Student>> _mockStudentRepo;
    private readonly AccountController _controller;

    public UnitTest1()
    {
        _mockUserRepo = new Mock<IRepository<User>>();
        _mockStudentRepo = new Mock<IRepository<Student>>();
        _controller = new AccountController(_mockUserRepo.Object, _mockStudentRepo.Object);
    }

    [Fact]
    public void Register_ReturnsViewResult()
    {
        var result = _controller.Register();

        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task Register_Post_ReturnsView_WhenModelStateIsInvalid()
    {
        var model = new UserDTO();
        _controller.ModelState.AddModelError("Username", "Required");

        var result = await _controller.Register(model);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(model, viewResult.Model);
    }

    [Fact]
    public async Task Register_Post_ReturnsView_WithError_WhenUsernameExists()
    {
        var model = new UserDTO { Username = "testuser" };
        _mockUserRepo.Setup(repo => repo.GetByUsernameAsync("testuser"))
            .ReturnsAsync(new User { Username = "testuser" });

        var result = await _controller.Register(model);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.True(_controller.ModelState.ContainsKey("Username"));
    }

    [Fact]
    public async Task Register_Post_CreatesUserAndRedirects()
    {
        var model = new UserDTO { Username = "newuser", Password = "password123", Role = "Student" };

        _mockUserRepo.Setup(repo => repo.GetByUsernameAsync("newuser")).ReturnsAsync((User)null);
        _mockUserRepo.Setup(repo => repo.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

        var result = await _controller.Register(model);

        _mockUserRepo.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
        Assert.IsType<ViewResult>(result);
    }
}
