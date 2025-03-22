namespace StudentManagementSystem.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string CourseCode { get; set; }
        public virtual User Faculty { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
