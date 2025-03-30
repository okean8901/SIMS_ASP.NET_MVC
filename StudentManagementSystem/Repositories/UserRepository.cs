using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get a user by ID, including their roles
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        // Get all users, including their roles
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        // Add a new user
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update an existing user
        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete a user by ID
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Get a user by username, including their roles
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        // Get users by role name (e.g., "Student", "Admin")
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
        {
            return await _context.Users
                .Where(u => u.UserRoles.Any(ur => ur.Role.RoleName == roleName))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        // Assign a role to a user
        public async Task AssignRoleAsync(int userId, string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                role = new Role { RoleName = roleName };
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
            }

            var existingUserRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == role.RoleId);
            if (existingUserRole == null)
            {
                var userRole = new UserRole
                {
                    UserId = userId,
                    RoleId = role.RoleId
                };
                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();
            }
        }

        // Get all students (users with the "Student" role)
        public async Task<List<User>> GetAllStudentsAsync()
        {
            return await _context.Users
                .Where(u => u.UserRoles.Any(ur => ur.Role.RoleName == "Student"))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        // Get a student by ID (assuming students are users with the "Student" role)
        public async Task<User> GetStudentByIdAsync(int studentId)
        {
            return await _context.Users
                .Where(u => u.UserId == studentId && u.UserRoles.Any(ur => ur.Role.RoleName == "Student"))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task UpdateUserRoleAsync(int userId, string roleName)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return;

            // Remove existing roles
            _context.UserRoles.RemoveRange(user.UserRoles);

            // Add new role
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role != null)
            {
                user.UserRoles.Add(new UserRole { UserId = user.UserId, RoleId = role.RoleId });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAdminsAsync()
        {
            return await _context.UserRoles
                .Where(ur => ur.Role.RoleName == "Admin")
                .Select(ur => ur.UserId)
                .Distinct()
                .CountAsync();
        }
    }
}