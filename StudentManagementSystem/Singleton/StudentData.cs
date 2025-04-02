using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class StudentData
{
    private static StudentData _instance;
    private static readonly object _lock = new object();
    private readonly IServiceProvider _serviceProvider; // Store service provider

    private StudentData(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static StudentData GetInstance(IServiceProvider serviceProvider)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new StudentData(serviceProvider);
                }
            }
        }
        return _instance;
    }

    public List<Enrollment> GetStudentEnrollments(int userId)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); // Get a fresh DbContext

        var student = context.Students.FirstOrDefault(s => s.UserId == userId);
        if (student == null)
        {
            return new List<Enrollment>();
        }

        return context.Enrollments
                      .Where(e => e.StudentId == student.StudentId)
                      .Include(e => e.Course)
                      .ToList();
    }
}

