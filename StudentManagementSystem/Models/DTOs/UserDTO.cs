namespace StudentManagementSystem.Models.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Major { get; set; }
        public int BatchYear { get; set; }
        public string Role { get; set; } // Không cần [Required], để trống sẽ là Admin
        public bool IsRegisteredSuccessfully { get; set; }
    }
}