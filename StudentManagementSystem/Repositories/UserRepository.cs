using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;

namespace StudentManagementSystem.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
        {
            return await _context.Users
                .Where(u => u.UserRoles.Any(ur => ur.Role.RoleName == roleName))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }


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
    }
}