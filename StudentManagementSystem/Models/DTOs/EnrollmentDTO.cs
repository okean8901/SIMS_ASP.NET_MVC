namespace StudentManagementSystem.Models.DTOs
{
    public class EnrollmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Semester { get; set; }
        public int AcademicYear { get; set; }
    }
}
