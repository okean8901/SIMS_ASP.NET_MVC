using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Entities;

namespace StudentManagementSystem.Repositories
{
    public class EnrollmentRepository : IRepository<Enrollment>
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.EnrollmentId == id);
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).ToListAsync();
        }

        public async Task AddAsync(Enrollment entity)
        {
            await _context.Enrollments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enrollment entity)
        {
            _context.Enrollments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Enrollments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Enrollment>> GetStudentEnrollments(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();
        }

        Task<Enrollment> IRepository<Enrollment>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Enrollment>> IRepository<Enrollment>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Enrollment>.AddAsync(Enrollment entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Enrollment>.UpdateAsync(Enrollment entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Enrollment>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Enrollment> IRepository<Enrollment>.GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}