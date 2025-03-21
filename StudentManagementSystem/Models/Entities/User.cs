namespace StudentManagementSystem.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int? RoleId { get; set; } // Cho phép NULL
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public virtual Role Role { get; set; } // Quan hệ navigation tới Role
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual Student Student { get; set; }
        public ICollection<AuthenticationLog> AuthenticationLog { get; set; }
    }
}