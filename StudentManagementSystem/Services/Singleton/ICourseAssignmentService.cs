using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services.Singletons
{
    public interface ICourseAssignmentService
    {
        Task AssignCourseToStudentAsync(int studentId, int courseId);
        Task<List<Student>> GetAvailableStudentsAsync();
        Task<List<Course>> GetAvailableCoursesAsync();
    }
}