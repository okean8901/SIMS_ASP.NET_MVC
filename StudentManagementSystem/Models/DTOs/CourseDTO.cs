namespace StudentManagementSystem.Models.DTOs
{
    public class CourseDTO
    {
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseCode { get; set; }
    }
}
