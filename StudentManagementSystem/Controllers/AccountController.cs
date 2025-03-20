using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.DTOs;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Repositories;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public AccountController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra Username duy nhất
            var existingUser = await _userRepository.GetByUsernameAsync(model.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "Username đã được đăng ký, vui lòng dùng Username khác.");
                return View(model);
            }

            var user = new User
            {
                Username = model.Username,
                Password = model.Password, // Nên mã hóa mật khẩu
                Email = model.Email,
                FullName = model.FullName,
            };

            await _userRepository.AddAsync(user);

            var student = new Student
            {
                UserId = user.UserId,
                FullName = model.FullName,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                Major = model.Major,
                BatchYear = model.BatchYear,
                Status = "Active",
                Class = "Unknown"
            };

            // Đánh dấu đăng ký thành công
            model.IsRegisteredSuccessfully = true;

            return View(model); // Trả về view hiện tại với model đã cập nhật
        }

        // GET: Đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Đăng nhập
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Vui lòng nhập tên đăng nhập và mật khẩu.";
                return View();
            }

            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || user.Password != password) // Nên dùng BCrypt.Net.BCrypt.Verify(password, user.Password) nếu đã mã hóa
            {
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View();
            }

            TempData["Username"] = user.Username;
            TempData["SuccessMessage"] = "Login Successfull!";
            return RedirectToAction("Index", "Home");
        }

        // Đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}