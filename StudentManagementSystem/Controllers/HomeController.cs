using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Entities;

namespace StudentManagementSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize] // Chỉ user đã đăng nhập mới truy cập được
    public IActionResult Home()
    {
        return View();
    }

    [Authorize(Roles = "Admin")] // Chỉ Admin truy cập được
    public IActionResult AdminDashboard()
    {
        return View();
    }
    [Authorize(Roles = "Teacher")] // Trang chỉ dành cho Teacher
    public IActionResult TeacherDashboard()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
