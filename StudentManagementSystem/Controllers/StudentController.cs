﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;

public class StudentController : Controller
{
    private readonly StudentData _studentData;

    // Inject StudentData instead of ApplicationDbContext
    public StudentController(StudentData studentData)
    {
        _studentData = studentData;
    }

    //public StudentController()
    //{
    //}

    public IActionResult Index()
    {
        // Get logged-in UserId from cookies (Claims)
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized(); // No user logged in
        }

        int userId = int.Parse(userIdClaim);

        // Fetch student enrollments
        List<Enrollment> enrollments = _studentData.GetStudentEnrollments(userId);

        return View(enrollments);
    }

}




