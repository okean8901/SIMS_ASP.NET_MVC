using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Entities;
namespace StudentManagementSystem.Data
{
    public class App_icationDbContext : DbContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<UserRole> UserRoles { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thiết lập khóa chính cho UserRole (bảng liên kết N-N)
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Thiết lập khóa chính cho Enrollment (bảng liên kết N-N)
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            // Cấu hình quan hệ giữa Course và User (Giảng viên)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Faculty)
                .WithMany()
                .HasForeignKey(c => c.FacultyUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình quan hệ giữa Enrollment và Student
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ giữa Enrollment và Course
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ giữa UserRole và User
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ giữa UserRole và Role
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
