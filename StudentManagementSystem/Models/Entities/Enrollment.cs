using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.Entities
{
    public class Enrollment
    {
        [Key]

        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public string Status { get; set; }
        public string Semester { get; set; }
        public int AcademicYear { get; set; }
        public string Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}
