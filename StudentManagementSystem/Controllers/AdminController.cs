using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;
using System;
using System.Linq;
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

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> CourseManagement()
        {
            ViewBag.Users = await _userRepository.GetAllAsync();
            var courses = await _courseRepository.GetAllAsync();
            foreach (var course in courses)
            {
                if (course.Description == null) course.Description = string.Empty;
            }
            return View(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseDTO model)
        {
            var course = new Course
            {
                CourseName = model.CourseName,
                CourseCode = model.CourseCode,
                Credits = model.Credits,
                Description = model.Description ?? string.Empty,
                UserId = model.UserId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = model.IsActive
            };
            await _courseRepository.AddAsync(course);
            return RedirectToAction("CourseManagement");
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(CourseDTO model)
        {
            var course = await _courseRepository.GetByIdAsync(model.CourseId);
            if (course == null) return NotFound();

            course.CourseName = model.CourseName;
            course.CourseCode = model.CourseCode;
            course.Credits = model.Credits;
            course.Description = model.Description ?? string.Empty;
            course.UserId = model.UserId;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.IsActive = model.IsActive;

            await _courseRepository.UpdateAsync(course);
            return RedirectToAction("CourseManagement");
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return RedirectToAction("CourseManagement");
        }

        public async Task<IActionResult> AssignCourse()
        {
            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return View(enrollments);
        }

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

        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            await _enrollmentRepository.DeleteAsync(id);

            TempData["Success"] = "Enrollment deleted successfully!";
            ViewBag.Students = await _studentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return View("AssignCourse", enrollments);
        }

        // User Management Methods
        public async Task<IActionResult> UserManagement(int? id)
        {
            // Get all users for the table
            var users = await _userRepository.GetAllAsync();

            // If an ID is provided, get the user for editing
            if (id.HasValue)
            {
                var editUser = await _userRepository.GetByIdAsync(id.Value);
                if (editUser != null)
                {
                    ViewBag.EditUser = editUser;
                    ViewBag.Roles = await _userRepository.GetRolesAsync();
                }
            }

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(int userId, string username, string email, string fullName,
            string password, string role, bool isActive)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return NotFound();

            user.Username = username;
            user.Email = email;
            user.FullName = fullName;
            user.IsActive = isActive;

            // Only update password if a new one is provided
            if (!string.IsNullOrEmpty(password))
            {
                // In production, you should hash the password
                user.Password = password;
            }

            // Update role if provided
            if (!string.IsNullOrEmpty(role))
            {
                await _userRepository.UpdateUserRoleAsync(user.UserId, role);
            }

            await _userRepository.UpdateAsync(user);
            TempData["Success"] = "User updated successfully!";
            return RedirectToAction("UserManagement");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            // Check if this is not the last admin to prevent locking out
            if (user.UserRoles.Any(ur => ur.Role.RoleName == "Admin"))
            {
                var adminCount = await _userRepository.CountAdminsAsync();
                if (adminCount <= 1)
                {
                    TempData["Error"] = "Cannot delete the last admin user!";
                    return RedirectToAction("UserManagement");
                }
            }

            await _userRepository.DeleteAsync(id);
            TempData["Success"] = "User deleted successfully!";
            return RedirectToAction("UserManagement");
        }
    }
}