using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.Entities
{
    public class AuthenticationLog
    {
        [Key]
        public int LogId { get; set; }

        public int UserId { get; set; }

        public DateTime LoginTime { get; set; } = DateTime.UtcNow;

        
        public string IpAddress { get; set; }

        
        public string DeviceInfo { get; set; }

        public bool LoginSuccess { get; set; }

        // Navigation properties
        
        public virtual User User { get; set; }
    }
}
