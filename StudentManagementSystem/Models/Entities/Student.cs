namespace StudentManagementSystem.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Major { get; set; }
        public int BatchYear { get; set; }
        public string Status { get; set; }
        public string Class { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
