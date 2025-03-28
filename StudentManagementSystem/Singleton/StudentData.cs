using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class StudentData
{
    private static StudentData _instance;
    private static readonly object _lock = new object();
    private readonly ApplicationDbContext _context;

    private StudentData(ApplicationDbContext context)
    {
        _context = context;
    }

    public static StudentData GetInstance(ApplicationDbContext context)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new StudentData(context);
                }
            }
        }
        return _instance;
    }

    public List<Enrollment> GetStudentEnrollments(int userId)
    {
        var student = _context.Students.FirstOrDefault(s => s.UserId == userId);
        if (student == null)
        {
            return new List<Enrollment>(); // Return empty list if student not found
        }

        return _context.Enrollments
                       .Where(e => e.StudentId == student.StudentId)
                       .Include(e => e.Course) // Include course details if needed
                       .ToList();
    }
}
