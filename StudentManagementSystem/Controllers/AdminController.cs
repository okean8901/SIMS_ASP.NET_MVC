using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly UserRepository _userRepository;
        private readonly StudentRepository _studentRepository;
        private readonly EnrollmentRepository _enrollmentRepository;

        public AdminController(
            CourseRepository courseRepository,
            UserRepository userRepository,
            StudentRepository studentRepository,
            EnrollmentRepository enrollmentRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        // GET: Admin Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: List all courses for management
        public async Task<IActionResult> CourseManagement()
        {
            ViewBag.Users = await _userRepository.GetAllAsync();
            var courses = await _courseRepository.GetAllAsync();
            return View(courses);
        }

        // POST: Add a new course
        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseDTO model)
        {
            var course = new Course
            {
                CourseName = model.CourseName,
                CourseCode = model.CourseCode,
                Credits = model.Credits,
                Description = model.Description,
                UserId = model.UserId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = model.IsActive
            };
            await _courseRepository.AddAsync(course);
            return RedirectToAction("Dashboard");
        }

        // POST: Edit an existing course
        [HttpPost]
        public async Task<IActionResult> EditCourse(CourseDTO model)
        {
            var course = await _courseRepository.GetByIdAsync(model.CourseId);
            if (course == null) return NotFound();

            course.CourseName = model.CourseName;
            course.CourseCode = model.CourseCode;
            course.Credits = model.Credits;
            course.Description = model.Description;
            course.UserId = model.UserId;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.IsActive = model.IsActive;

            await _courseRepository.UpdateAsync(course);
            return RedirectToAction("Dashboard");
        }

        // GET: Delete a course
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return RedirectToAction("Dashboard");
        }

        // GET: Hiển thị form gắn khóa học và danh sách enrollment
        public async Task<IActionResult> AssignCourse()
        {
            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return View(enrollments);
        }

        // POST: Gắn khóa học cho sinh viên và hiển thị lại danh sách
        [HttpPost]
        public async Task<IActionResult> AssignCourse(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollDate = DateTime.Now,
                Status = "Enrolled",
                Semester = "Spring",
                AcademicYear = DateTime.Now.Year,
                Grade = "N/A"
            };

            await _enrollmentRepository.AddAsync(enrollment);

            TempData["Success"] = "Course assigned successfully!";
            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return View(enrollments);
        }

        // GET: Hiển thị form sửa enrollment
        public async Task<IActionResult> EditEnrollment(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return NotFound();

            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            ViewBag.EditEnrollment = enrollment;
            return View("AssignCourse", enrollments);
        }

        // POST: Sửa enrollment và hiển thị lại danh sách
        [HttpPost]
        public async Task<IActionResult> EditEnrollment(int EnrollmentId, int StudentId, int CourseId, string Status, string Semester, int AcademicYear, string Grade, DateTime EnrollDate)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                TempData["Error"] = "Invalid data. Please check your input. Errors: " + string.Join(", ", errors);

                ViewBag.Students = await _studentRepository.GetAllAsync();
                ViewBag.Courses = await _courseRepository.GetAllAsync();
                var allEnrollments = await _enrollmentRepository.GetAllAsync();
                ViewBag.EditEnrollment = new Enrollment
                {
                    EnrollmentId = EnrollmentId,
                    StudentId = StudentId,
                    CourseId = CourseId,
                    Status = Status,
                    Semester = Semester,
                    AcademicYear = AcademicYear,
                    Grade = Grade,
                    EnrollDate = EnrollDate
                };
                return View("AssignCourse", allEnrollments);
            }

            var enrollment = await _enrollmentRepository.GetByIdAsync(EnrollmentId);
            if (enrollment == null) return NotFound();

            enrollment.StudentId = StudentId;
            enrollment.CourseId = CourseId;
            enrollment.Status = Status;
            enrollment.Semester = Semester;
            enrollment.AcademicYear = AcademicYear;
            enrollment.Grade = Grade;
            enrollment.EnrollDate = EnrollDate;

            await _enrollmentRepository.UpdateAsync(enrollment);

            TempData["Success"] = "Enrollment updated successfully!";
            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return View("AssignCourse", enrollments);
        }

        // GET: Xóa enrollment và hiển thị lại danh sách
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            await _enrollmentRepository.DeleteAsync(id);

            TempData["Success"] = "Enrollment deleted successfully!";
            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return View("AssignCourse", enrollments);
        }
    }
}