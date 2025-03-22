using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly UserRepository _userRepository;

        public AdminController(CourseRepository courseRepository, UserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        // GET: List all courses and faculties
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = await _userRepository.GetAllAsync(); // Fetch all users
            var courses = await _courseRepository.GetAllAsync();

            // Convert `Course` entities to `CourseDTO`
            var courseDtos = courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                UserId = c.UserId,
                CourseName = c.CourseName,
                CourseCode = c.CourseCode,
                Credits = c.Credits,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                IsActive = c.IsActive // ✅ Include IsActive
            }).ToList();

            return View(courseDtos);
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
                IsActive = model.IsActive // ✅ Save IsActive
            };

            await _courseRepository.AddAsync(course);
            return RedirectToAction("Index");
        }

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
            course.IsActive = model.IsActive; // ✅ Update IsActive

            await _courseRepository.UpdateAsync(course);
            return RedirectToAction("Index");
        }


        // GET: Delete a course
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
