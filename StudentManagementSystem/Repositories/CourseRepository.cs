using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            return await _context.Courses
                .Select(c => new CourseDTO
                {
                    CourseId = c.CourseId,
                    UserId = c.UserId,
                    CourseName = c.CourseName,
                    CourseCode = c.CourseCode,
                    Credits = c.Credits,
                    Description = c.Description, // Thêm ánh xạ Description
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    IsActive = c.IsActive
                }).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Course> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                return await _context.Courses
                    .FirstOrDefaultAsync(c => c.UserId == user.UserId);
            }
            return null;
        }

        public async Task AssignRoleAsync(int userId, string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                throw new ArgumentException($"Role {roleName} not found.");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found.");
            }

            user.Role = role;
            await _context.SaveChangesAsync();
        }

        
        internal async Task AssignCourseToStudentAsync(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Course>> IRepository<Course>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}