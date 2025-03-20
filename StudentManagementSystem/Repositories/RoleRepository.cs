using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;

namespace StudentManagementSystem.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AddAsync(Role entity)
        {
            await _context.Roles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role entity)
        {
            _context.Roles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Roles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        Task<Role> IRepository<Role>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Role>> IRepository<Role>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Role>.AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Role>.UpdateAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Role>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Role> IRepository<Role>.GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}