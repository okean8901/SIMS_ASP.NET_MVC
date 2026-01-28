# TEST CASE - Student Management System

## Thông tin chung
- **Dự án:** Student Management System (SIMS)
- **Phiên bản:** 1.0
- **Ngày tạo:** 28/01/2026
- **Người tạo:** QA Team
- **Trạng thái:** Chưa test

---

## 📊 BẢNG TEST CASE CHI TIẾT

### **DANH SÁCH TEST CASE**

| TC ID | Chức năng | Mô tả Test | Bước thực hiện | Dữ liệu đầu vào | Kết quả mong đợi | Kết quả thực tế | Pass/Fail | Ghi chú |
|-------|-----------|-----------|-----------------|-----------------|------------------|-----------------|-----------|---------|
| **TC001** | Đăng ký | Đăng ký tài khoản với đầy đủ thông tin | 1. Truy cập trang Register<br>2. Nhập Username, Password, Email, FullName<br>3. Chọn Role (Student)<br>4. Click "Register" | Username: student01<br>Password: Pass@123<br>Email: student01@test.com<br>FullName: Nguyễn Văn A | Tài khoản được tạo thành công, chuyển hướng tới trang Login | | | |
| **TC002** | Đăng ký | Đăng ký với Username đã tồn tại | 1. Truy cập Register<br>2. Nhập Username đã tồn tại<br>3. Nhập Password, Email, FullName<br>4. Click "Register" | Username: admin (đã tồn tại)<br>Password: Pass@123<br>Email: test@test.com | Hiển thị lỗi: "Username đã được đăng ký" | | | |
| **TC003** | Đăng ký | Đăng ký với Email không hợp lệ | 1. Truy cập Register<br>2. Nhập Username mới<br>3. Nhập Email không hợp lệ<br>4. Click "Register" | Username: student02<br>Email: invalidemail<br>Password: Pass@123 | Hiển thị lỗi validation Email | | | |
| **TC004** | Đăng ký | Đăng ký với Password rỗng | 1. Truy cập Register<br>2. Nhập Username, Email<br>3. Bỏ trống Password<br>4. Click "Register" | Username: student03<br>Email: student03@test.com<br>Password: (trống) | Hiển thị lỗi: "Password không được để trống" | | | |
| **TC005** | Đăng nhập | Đăng nhập với tài khoản hợp lệ (Student) | 1. Truy cập trang Login<br>2. Nhập Username đúng<br>3. Nhập Password đúng<br>4. Click "Login" | Username: student01<br>Password: Pass@123 | Đăng nhập thành công, chuyển tới Student Dashboard | | | |
| **TC006** | Đăng nhập | Đăng nhập với tài khoản hợp lệ (Admin) | 1. Truy cập trang Login<br>2. Nhập Username Admin<br>3. Nhập Password đúng<br>4. Click "Login" | Username: admin<br>Password: Admin@123 | Đăng nhập thành công, chuyển tới Admin Dashboard | | | |
| **TC007** | Đăng nhập | Đăng nhập với Username sai | 1. Truy cập Login<br>2. Nhập Username không tồn tại<br>3. Nhập Password<br>4. Click "Login" | Username: notexist<br>Password: Pass@123 | Hiển thị lỗi: "Username hoặc Password không chính xác" | | | |
| **TC008** | Đăng nhập | Đăng nhập với Password sai | 1. Truy cập Login<br>2. Nhập Username đúng<br>3. Nhập Password sai<br>4. Click "Login" | Username: student01<br>Password: WrongPass | Hiển thị lỗi: "Username hoặc Password không chính xác" | | | |
| **TC009** | Đăng nhập | Đăng nhập với cả Username và Password trống | 1. Truy cập Login<br>2. Bỏ trống Username và Password<br>3. Click "Login" | Username: (trống)<br>Password: (trống) | Hiển thị lỗi validation | | | |
| **TC010** | Quản lý Khóa học | Admin thêm khóa học mới | 1. Login as Admin<br>2. Truy cập Course Management<br>3. Nhập thông tin khóa học<br>4. Click "Add Course" | CourseName: Mathematics 101<br>CourseCode: MATH101<br>Credits: 3<br>Faculty: Teacher01 | Khóa học được tạo thành công, hiển thị trong danh sách | | | |
| **TC011** | Quản lý Khóa học | Admin thêm khóa học với CourseCode trùng lặp | 1. Login as Admin<br>2. Truy cập Course Management<br>3. Nhập CourseCode đã tồn tại<br>4. Click "Add Course" | CourseCode: MATH101 (đã tồn tại) | Hiển thị lỗi: "CourseCode đã tồn tại" | | | |
| **TC012** | Quản lý Khóa học | Admin chỉnh sửa khóa học | 1. Login as Admin<br>2. Truy cập Course Management<br>3. Chọn khóa học<br>4. Chỉnh sửa thông tin<br>5. Click "Update" | CourseName: Math 101 Advanced<br>Credits: 4 | Khóa học được cập nhật thành công | | | |
| **TC013** | Quản lý Khóa học | Admin xóa khóa học | 1. Login as Admin<br>2. Truy cập Course Management<br>3. Chọn khóa học<br>4. Click "Delete" | CourseId: 1 | Khóa học bị xóa, không hiển thị trong danh sách | | | |
| **TC014** | Quản lý Sinh viên | Admin xem danh sách sinh viên | 1. Login as Admin<br>2. Truy cập User Management<br>3. Xem danh sách | Role filter: Student | Hiển thị danh sách tất cả sinh viên | | | |
| **TC015** | Quản lý Sinh viên | Admin tìm kiếm sinh viên theo Username | 1. Login as Admin<br>2. Truy cập User Management<br>3. Nhập Username vào ô tìm kiếm<br>4. Click "Search" | SearchTerm: student01 | Hiển thị sinh viên phù hợp | | | |
| **TC016** | Ghi danh | Admin ghi danh sinh viên vào khóa học | 1. Login as Admin<br>2. Truy cập Assign Course<br>3. Chọn sinh viên<br>4. Chọn khóa học<br>5. Click "Enroll" | StudentId: 1<br>CourseId: 1 | Ghi danh thành công, sinh viên được thêm vào khóa học | | | |
| **TC017** | Ghi danh | Ghi danh sinh viên vào khóa học đã có | 1. Login as Admin<br>2. Truy cập Assign Course<br>3. Chọn sinh viên đã ghi danh<br>4. Chọn khóa học giống lần trước<br>5. Click "Enroll" | StudentId: 1<br>CourseId: 1 | Hiển thị lỗi: "Sinh viên đã ghi danh khóa học này" | | | |
| **TC018** | Student Dashboard | Sinh viên xem danh sách khóa học đã ghi danh | 1. Login as Student<br>2. Truy cập Student Dashboard | UserId: Student được login | Hiển thị danh sách khóa học đã ghi danh | | | |
| **TC019** | Student Dashboard | Sinh viên xem chi tiết khóa học | 1. Login as Student<br>2. Truy cập Student Dashboard<br>3. Click vào một khóa học | EnrollmentId: 1 | Hiển thị chi tiết khóa học: Tên, Mô tả, Thời gian, Giáo viên | | | |
| **TC020** | Phân quyền | Student không thể truy cập Admin Dashboard | 1. Login as Student<br>2. Cố gắng truy cập Admin Dashboard bằng URL | URL: /Admin/Dashboard | Chuyển hướng tới trang 403 (Forbidden) | | | |
| **TC021** | Phân quyền | Teacher không thể truy cập Admin Dashboard | 1. Login as Teacher<br>2. Cố gắng truy cập Admin Dashboard bằng URL | URL: /Admin/Dashboard | Chuyển hướng tới trang 403 (Forbidden) | | | |
| **TC022** | Đăng xuất | User đăng xuất thành công | 1. Login as bất kỳ role nào<br>2. Click "Logout" | Logged in User | Đăng xuất thành công, chuyển hướng tới Home | | | |
| **TC023** | Home Page | Truy cập Home Page không đăng nhập | 1. Truy cập http://localhost:5001<br>2. Không đăng nhập | - | Hiển thị Home Page với nút Login/Register | | | |
| **TC024** | Error Handling | Truy cập URL không tồn tại | 1. Truy cập URL bất kỳ không tồn tại | URL: /notexist | Hiển thị Error Page 404 | | | |

---

## 📈 TÓMLƯỢC THỐNG KÊ TEST

| Chỉ số | Số lượng |
|--------|---------|
| **Tổng Test Case** | 24 |
| **Chưa test** | 24 |
| **Pass** | 0 |
| **Fail** | 0 |
| **Tỷ lệ Pass** | 0% |

---

## 🔄 KỊCH BẢN TEST (Test Scenarios)

### **Scenario 1: User Registration & Login Flow**
```
1. New User → Register → Verify account created → Login → Dashboard
2. Check Username validation
3. Check Email validation
4. Check Password strength
```

### **Scenario 2: Admin Course Management**
```
1. Admin login → Course Management → Add Course
2. View all courses
3. Edit course details
4. Delete course
5. Verify courses in database
```

### **Scenario 3: Student Enrollment**
```
1. Admin login → Assign Course → Select Student & Course
2. Verify enrollment created
3. Student login → Check enrolled courses
4. Verify student can view course details
```

### **Scenario 4: Role-Based Access Control**
```
1. Student login → Cannot access Admin pages (403)
2. Teacher login → Cannot access Admin pages (403)
3. Admin login → Access all pages
```

---

## 📝 GHI CHÚ TESTER

- Tất cả test case cần được thực hiện trên môi trường Test
- Database cần reset trước mỗi test run
- Ghi lại thời gian test, browser, OS sử dụng
- Nếu có lỗi, tạo Bug Report với link đến TC ID
- Ưu tiên test các tính năng quan trọng trước (Đăng nhập, Đăng ký, Ghi danh)
