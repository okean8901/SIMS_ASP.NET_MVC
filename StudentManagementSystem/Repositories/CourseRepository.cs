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

        // Example of implementing GetByUsernameAsync and AssignRoleAsync, assuming user-related functionality exists.
        public async Task<Course> GetByUsernameAsync(string username)
        {
            // First, find the user by username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            // If user is found, return the course associated with that user's UserId
            if (user != null)
            {
                return await _context.Courses
                    .FirstOrDefaultAsync(c => c.UserId == user.UserId); // Use user.UserId, which is an integer
            }

            return null; // Return null if no user or course is found
        }

        public async Task AssignRoleAsync(int userId, string roleName)
        {
            // Get the Role object from the database based on role name (e.g., "Admin")
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);

            if (role == null)
            {
                throw new ArgumentException($"Role {roleName} not found.");
            }

            // Retrieve the user by userId
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found.");
            }

            // Assign the Role to the User (assuming User entity has a Role navigation property)
            user.Role = role;  // Assign the Role object

            await _context.SaveChangesAsync();
        }

        Task<IEnumerable<Course>> IRepository<Course>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
