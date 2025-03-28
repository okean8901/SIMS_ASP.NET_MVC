using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly EnrollmentRepository _enrollmentRepository;
        private readonly StudentRepository _studentRepository;

        public TeacherController(
            CourseRepository courseRepository,
            EnrollmentRepository enrollmentRepository,
            StudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
        }

        // Hiển thị tất cả khóa học và sinh viên để chấm điểm
        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepository.GetAllAsync(); // Lấy tất cả khóa học

            // Lấy danh sách sinh viên đăng ký cho từng khóa học
            var courseEnrollments = new Dictionary<int, IEnumerable<Enrollment>>();
            foreach (var course in courses)
            {
                var enrollments = await _enrollmentRepository.GetEnrollmentsByCourseIdAsync(course.CourseId);
                courseEnrollments[course.CourseId] = enrollments;
            }

            ViewBag.CourseEnrollments = courseEnrollments;
            return View(courses);
        }

        // Xử lý việc gửi điểm từ giáo viên
        [HttpPost]
        public async Task<IActionResult> SubmitGrades(int courseId, Dictionary<int, string> grades)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }

            foreach (var grade in grades)
            {
                var enrollment = await _enrollmentRepository.GetByIdAsync(grade.Key);
                if (enrollment != null && enrollment.CourseId == courseId)
                {
                    enrollment.Grade = grade.Value; // Cập nhật điểm
                    await _enrollmentRepository.UpdateAsync(enrollment);
                }
            }

            TempData["Success"] = "Grades submitted successfully for course " + course.CourseName;
            return RedirectToAction("Index");
        }


    }
}