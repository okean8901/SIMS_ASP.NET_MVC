# HƯỚNG DẪN CHỨC NĂNG - Student Management System

**Version:** 1.0  
**Last Updated:** 28/01/2026  
**Audience:** QA Testers, End Users  

---

## 📑 MỤC LỤC

1. [Giới thiệu hệ thống](#1-giới-thiệu-hệ-thống)
2. [Các chức năng chính](#2-các-chức-năng-chính)
3. [Hướng dẫn sử dụng từng chức năng](#3-hướng-dẫn-sử-dụng-từng-chức-năng)
4. [Quy trình nghiệp vụ](#4-quy-trình-nghiệp-vụ)
5. [FAQ & Troubleshooting](#5-faq--troubleshooting)

---

## 1️⃣ GIỚI THIỆU HỆ THỐNG

### **1.1 Tổng quan**

**Student Management System (SIMS)** là ứng dụng web quản lý sinh viên, khóa học, và ghi danh được xây dựng bằng:
- **Framework:** ASP.NET Core MVC
- **Database:** SQL Server
- **Frontend:** HTML, CSS, JavaScript
- **Authentication:** Cookies-based

### **1.2 Các role người dùng**

| Role | Quyền hạn | Chức năng |
|------|----------|---------|
| **Admin** | Toàn quyền | Quản lý tất cả khía cạnh hệ thống |
| **Teacher** | Giáo viên | Xem thông tin sinh viên, khóa học |
| **Student** | Sinh viên | Xem khóa học đã ghi danh |
| **Guest** | Không đăng nhập | Chỉ xem Home page, Login, Register |

### **1.3 Sơ đồ kiến trúc**

```
┌─────────────────────────────────────────────────┐
│              Web Browser                        │
│   (Chrome, Firefox, Safari, Edge)              │
└────────────────────┬────────────────────────────┘
                     │
                     │ HTTP/HTTPS
                     │
┌────────────────────▼────────────────────────────┐
│      ASP.NET Core MVC Application              │
│                                                │
│  ┌─────────────┐  ┌──────────────┐             │
│  │ Controllers │  │    Views     │             │
│  └──────┬──────┘  └──────────────┘             │
│         │                                      │
│  ┌──────▼──────────────┐                       │
│  │   Repositories      │                       │
│  │  (Data Access)      │                       │
│  └──────┬──────────────┘                       │
└────────┼──────────────────────────────────────┘
         │
         │ ADO.NET
         │
    ┌────▼─────┐
    │ SQL Server│
    │ Database  │
    └───────────┘
```

---

## 2️⃣ CÁC CHỨC NĂNG CHÍNH

### **2.1 Module User Management (Quản lý Người Dùng)**

#### **2.1.1 Đăng ký (Registration)**

**Mục đích:** Tạo tài khoản người dùng mới

**Dữ liệu cần nhập:**
- Username (2-50 ký tự, không trùng lặp)
- Password (tối thiểu 6 ký tự)
- Email (định dạng email hợp lệ)
- FullName (tên đầy đủ)
- Role (Admin, Teacher, hoặc Student)

**Quy trình:**
```
1. Click "Register" trên Home page
2. Nhập tất cả thông tin bắt buộc
3. Click "Register" button
4. Nếu hợp lệ → Tài khoản được tạo → Chuyển tới Login
   Nếu lỗi → Hiển thị error message
```

**Validation Rules:**
- ✅ Username phải unique trong hệ thống
- ✅ Password phải ≥ 6 ký tự
- ✅ Email phải đúng format: username@domain.com
- ✅ FullName không để trống
- ✅ Role phải chọn

**Database:**
```sql
INSERT INTO Users (Username, Password, Email, FullName, RoleId, CreatedAt, IsActive)
VALUES ('student01', 'hashed_password', 'student01@test.com', 'Nguyễn Văn A', 3, GETDATE(), 1)
```

#### **2.1.2 Đăng nhập (Login)**

**Mục đích:** Xác thực người dùng và truy cập hệ thống

**Dữ liệu cần nhập:**
- Username (tài khoản đã đăng ký)
- Password (mật khẩu đúng)

**Quy trình:**
```
1. Truy cập Login page
2. Nhập Username
3. Nhập Password
4. Click "Login" button
5. Nếu đúng → Chuyển tới Dashboard
   Nếu sai → Hiển thị error "Username/Password sai"
```

**Session Management:**
- Lưu UserId trong Claim (ClaimTypes.NameIdentifier)
- Lưu Role trong Claim (ClaimTypes.Role)
- Timeout: 30 phút không hoạt động

**Database Query:**
```sql
SELECT * FROM Users 
WHERE Username = 'student01' AND Password = 'hashed_password'
```

#### **2.1.3 Đăng xuất (Logout)**

**Mục đích:** Kết thúc phiên làm việc

**Quy trình:**
```
1. Click "Logout" trên top menu
2. System xóa session/cookies
3. Chuyển hướng tới Home page
4. Người dùng không thể access private pages
```

**Security:**
- ✅ Xóa Authentication cookies
- ✅ Xóa session data
- ✅ Redirect về Home page
- ✅ Không cache trang private

### **2.2 Module Course Management (Quản lý Khóa Học)**

#### **2.2.1 Xem danh sách khóa học**

**Ai có quyền:** Admin, Teacher, Student

**Thông tin hiển thị:**
- Course Name (Tên khóa học)
- Course Code (Mã khóa học)
- Credits (Số tín chỉ)
- Faculty (Giáo viên phụ trách)
- Start Date - End Date (Thời gian học)
- Trạng thái (Active/Inactive)

**Quy trình:**
```
Admin:
  1. Login as Admin
  2. Click "Course Management" menu
  3. Xem danh sách tất cả khóa học
  4. Có thể Add, Edit, Delete

Teacher:
  1. Login as Teacher
  2. Xem khóa học mình phụ trách
  3. Xem danh sách sinh viên đã ghi danh

Student:
  1. Login as Student
  2. Xem chỉ các khóa học đã ghi danh
```

#### **2.2.2 Thêm khóa học (Add Course)**

**Quyền:** Admin

**Dữ liệu cần nhập:**
| Field | Type | Yêu cầu | Ví dụ |
|-------|------|--------|-------|
| Course Name | Text | Bắt buộc | Mathematics 101 |
| Course Code | Text | Bắt buộc, Unique | MATH101 |
| Credits | Number | Bắt buộc | 3 |
| Description | TextArea | Tuỳ chọn | Toán học cấp cơ sở |
| Faculty | Dropdown | Bắt buộc | Teacher01 |
| Start Date | Date | Bắt buộc | 2026-02-01 |
| End Date | Date | Bắt buộc | 2026-05-31 |

**Validation:**
- ✅ Course Code không được trùng lặp
- ✅ Credits phải > 0
- ✅ Start Date < End Date
- ✅ Faculty phải tồn tại

**Quy trình:**
```
1. Admin login → Course Management → "Add Course" button
2. Nhập tất cả thông tin
3. Click "Save" button
4. ✅ Success: Khóa học được thêm, hiển thị trong danh sách
   ❌ Error: Hiển thị error message, quay lại form
```

**Database:**
```sql
INSERT INTO Courses (UserId, CourseName, CourseCode, Credits, Description, 
                     StartDate, EndDate, IsActive, CreatedAt)
VALUES (1, 'Mathematics 101', 'MATH101', 3, '...', '2026-02-01', 
        '2026-05-31', 1, GETDATE())
```

#### **2.2.3 Chỉnh sửa khóa học (Edit Course)**

**Quyền:** Admin

**Quy trình:**
```
1. Course Management → Select a course
2. Click "Edit" button
3. Thay đổi thông tin cần sửa
4. Click "Update" button
5. ✅ Success: Update thành công, quay lại danh sách
```

#### **2.2.4 Xóa khóa học (Delete Course)**

**Quyền:** Admin

**Cảnh báo:**
⚠️ Xóa khóa học sẽ xóa tất cả enrollment liên quan

**Quy trình:**
```
1. Course Management → Select a course
2. Click "Delete" button
3. Xác nhận xóa
4. ✅ Success: Khóa học bị xóa khỏi danh sách
```

**Database (Cascade Delete):**
```sql
DELETE FROM Enrollments WHERE CourseId = 1
DELETE FROM Courses WHERE CourseId = 1
```

### **2.3 Module Student Enrollment (Ghi Danh Sinh Viên)**

#### **2.3.1 Ghi danh sinh viên vào khóa học**

**Quyền:** Admin

**Dữ liệu cần chọn:**
- Student (Dropdown danh sách sinh viên)
- Course (Dropdown danh sách khóa học)

**Validation:**
- ✅ Student phải active
- ✅ Course phải active
- ✅ Student chưa ghi danh khóa học này

**Quy trình:**
```
1. Admin login → "Assign Course" menu
2. Select Student từ dropdown
3. Select Course từ dropdown
4. Click "Enroll" button
5. ✅ Success: Ghi danh thành công
   ❌ Error: Hiển thị error (VD: đã ghi danh, inactive)
```

**Database:**
```sql
INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate, IsActive)
VALUES (1, 1, GETDATE(), 1)
```

#### **2.3.2 Xem các khóa học đã ghi danh**

**Quyền:** Student

**Thông tin hiển thị:**
- Course Name
- Faculty (Giáo viên)
- Start Date - End Date
- Enrollment Date (Ngày ghi danh)

**Quy trình:**
```
1. Student login
2. Dashboard → Xem danh sách khóa học đã ghi danh
3. Click vào course để xem chi tiết
```

### **2.4 Module User Management (Quản lý Người Dùng - Admin)**

#### **2.4.1 Xem danh sách người dùng**

**Quyền:** Admin

**Thông tin hiển thị:**
| Cột | Dữ liệu |
|-----|--------|
| Username | Tên đăng nhập |
| Email | Email người dùng |
| FullName | Tên đầy đủ |
| Role | Quyền hạn |
| Status | Active/Inactive |
| Last Login | Lần cuối đăng nhập |

**Tính năng:**
- ✅ Sắp xếp theo cột
- ✅ Tìm kiếm theo Username
- ✅ Filter theo Role
- ✅ Phân trang

**Quy trình:**
```
1. Admin login → "User Management" menu
2. Xem danh sách người dùng
3. Có thể tìm kiếm, filter, sort
4. Click vào user để xem chi tiết hoặc edit
```

#### **2.4.2 Tìm kiếm người dùng**

**Quy trình:**
```
1. User Management page
2. Nhập Username vào search box
3. Click "Search" hoặc press Enter
4. Hiển thị kết quả phù hợp
```

**Database Query:**
```sql
SELECT * FROM Users 
WHERE Username LIKE '%student%' OR Email LIKE '%student%'
ORDER BY Username
```

### **2.5 Module Dashboard**

#### **2.5.1 Admin Dashboard**

**Quyền:** Admin only

**Thông tin hiển thị:**
- 📊 Thống kê: Tổng sinh viên, giáo viên, khóa học
- 📈 Biểu đồ: Số sinh viên theo khóa học
- 🔔 Thông báo: Hoạt động gần đây
- 🎯 Quick links: Quản lý khóa học, sinh viên, ghi danh

**Quy trình:**
```
1. Admin login
2. Chuyển hướng tự động tới Admin Dashboard
3. Xem thống kê và quản lý từ đây
```

#### **2.5.2 Student Dashboard**

**Quyền:** Student

**Thông tin hiển thị:**
- Danh sách khóa học đã ghi danh
- Thông tin khóa học (tên, giáo viên, thời gian)
- Ngày ghi danh

**Quy trình:**
```
1. Student login
2. Chuyển hướng tới Student Dashboard
3. Xem các khóa học đã ghi danh
```

#### **2.5.3 Teacher Dashboard**

**Quyền:** Teacher

**Thông tin hiển thị:**
- Danh sách khóa học phụ trách
- Số sinh viên trong mỗi khóa học
- Danh sách sinh viên

**Quy trình:**
```
1. Teacher login
2. Chuyển hướng tới Teacher Dashboard
3. Xem khóa học phụ trách
```

---

## 3️⃣ HƯỚNG DẪN SỬ DỤNG TỪNG CHỨC NĂNG

### **3.1 Từng bước: New User Registration**

```
Step 1: Truy cập hệ thống
  → Mở browser
  → Nhập URL: http://localhost:5001
  → Click "Register" button trên Home page

Step 2: Điền thông tin
  Username    : student01
  Password    : Pass@123
  Email       : student01@example.com
  FullName    : Nguyễn Văn A
  Role        : Student (select từ dropdown)

Step 3: Submit
  → Click "Register" button
  → Đợi hệ thống xử lý (2-3 giây)

Result:
  ✅ Tài khoản được tạo
  ✅ Chuyển hướng tới Login page
  ✅ Hiển thị thông báo success (nếu có)
  
Next Step:
  → Đăng nhập với tài khoản vừa tạo
```

### **3.2 Từng bước: Admin Add Course**

```
Step 1: Đăng nhập
  → Username: admin
  → Password: Admin@123
  → Click "Login"

Step 2: Truy cập Course Management
  → Trên menu, click "Course Management"
  → Xem danh sách khóa học hiện tại

Step 3: Thêm khóa học mới
  → Click nút "Add Course"
  → Form mở ra với các field

Step 4: Điền thông tin
  Course Name : Mathematics 101
  Course Code : MATH101
  Credits     : 3
  Description : Toán cấp cơ sở
  Faculty     : Teacher01 (select từ dropdown)
  Start Date  : 2026-02-01
  End Date    : 2026-05-31

Step 5: Lưu
  → Click "Save" button
  → Hệ thống validate thông tin
  → Nếu hợp lệ, khóa học được lưu
  → Hiển thị thông báo success
  → Quay lại danh sách course

Step 6: Xác minh
  → Khóa học mới xuất hiện trong danh sách
  → Có thể edit hoặc xóa
```

### **3.3 Từng bước: Assign Student to Course**

```
Step 1: Đăng nhập Admin
  → Username: admin
  → Password: Admin@123

Step 2: Truy cập Assign Course
  → Click menu "Assign Course"

Step 3: Chọn sinh viên
  → Click dropdown "Select Student"
  → Chọn "student01" từ danh sách

Step 4: Chọn khóa học
  → Click dropdown "Select Course"
  → Chọn "Mathematics 101" từ danh sách

Step 5: Ghi danh
  → Click "Enroll" button
  → Hệ thống kiểm tra:
    - Student có tồn tại không?
    - Course có tồn tại không?
    - Student đã ghi danh chưa?
  → Nếu OK → Enrollment được lưu
  → Hiển thị success message

Step 6: Xác minh
  → Enrollment được thêm vào database
  → Student có thể xem khóa học trên Dashboard
```

### **3.4 Từng bước: Student View Enrolled Courses**

```
Step 1: Đăng nhập
  → Username: student01
  → Password: Pass@123

Step 2: Chuyển hướng
  → Tự động chuyển tới Student Dashboard
  → Hoặc click menu "Student"

Step 3: Xem danh sách khóa học
  → Dashboard hiển thị bảng "Enrolled Courses"
  → Xem thông tin:
    - Course Name
    - Faculty
    - Start Date - End Date
    - Enrollment Date

Step 4: Chi tiết khóa học
  → Click vào tên khóa học
  → Xem mô tả, thời gian, giáo viên
  → Quay lại danh sách (back button)
```

---

## 4️⃣ QUY TRÌNH NGHIỆP VỤ

### **4.1 Quy trình New Semester Setup**

```
┌─────────────────────────────────────────┐
│ Admin tạo các khóa học mới cho semester │
└────────────┬────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────┐
│ Admin ghi danh sinh viên vào khóa học  │
└────────────┬────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────┐
│ Teacher xem danh sách sinh viên        │
│ Student xem khóa học đã ghi danh       │
└────────────┬────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────┐
│ Semester bắt đầu                        │
└─────────────────────────────────────────┘
```

### **4.2 Quy trình User Management**

**Đăng ký → Xác nhận → Phân quyền → Hoạt động**

```
New User Registration
  ↓
 Username validation
  ↓
 Email validation
  ↓
 Password hashing
  ↓
 Account Created (IsActive = true)
  ↓
 First Login
  ↓
 Role assignment (Admin/Teacher/Student)
  ↓
 Dashboard access based on role
```

### **4.3 Quy trình Ghi Danh**

```
Admin Select Student
  ↓
Admin Select Course
  ↓
System Check:
  - Student exists?
  - Course exists?
  - Student not enrolled yet?
  ↓
If All OK:
  CREATE Enrollment Record
  ↓
Student Can View Course in Dashboard
  ↓
If Fail:
  Show Error Message
  ↓
Admin Retry or Skip
```

---

## 5️⃣ FAQ & TROUBLESHOOTING

### **5.1 FAQ (Câu Hỏi Thường Gặp)**

#### **Q1: Tôi quên mật khẩu phải làm sao?**

**A:** Hiện tại hệ thống không có tính năng "Forgot Password".  
**Giải pháp:** Liên hệ Admin để reset mật khẩu.  
*(Tính năng này sẽ được thêm trong v1.1)*

#### **Q2: Tôi có thể ghi danh vào 2 khóa học cùng một lúc không?**

**A:** Có, bạn có thể ghi danh vào bao nhiêu khóa học tuỳ ý.  
Chỉ không thể ghi danh khóa học giống nhau 2 lần.

#### **Q3: Thời gian hết hạn session là bao lâu?**

**A:** Nếu không hoạt động trong 30 phút, session sẽ hết hạn.  
Bạn sẽ cần đăng nhập lại.

#### **Q4: Có thể xóa khóa học sau khi sinh viên đã ghi danh không?**

**A:** Có thể, nhưng hệ thống sẽ xóa tất cả enrollment liên quan.  
**Khuyên:** Hãy vô hiệu hóa khóa học (Inactive) thay vì xóa.

#### **Q5: Sinh viên có thể xóa khóa học đã ghi danh không?**

**A:** Không, sinh viên không có quyền xóa ghi danh.  
Cần liên hệ Admin để hủy ghi danh.

### **5.2 Troubleshooting Guide**

#### **Problem: "Username đã được đăng ký"**

**Nguyên nhân:**
- Username đã tồn tại trong hệ thống

**Giải pháp:**
1. Sử dụng username khác
2. Nếu quên username cũ, liên hệ Admin
3. Check lại xem có typo không (case-sensitive)

#### **Problem: Login thất bại - "Username/Password sai"**

**Nguyên nhân:**
- Username hoặc password không chính xác
- Account bị vô hiệu hóa (IsActive = false)

**Giải pháp:**
1. Kiểm tra lại username
2. Kiểm tra lại password (lưu ý: case-sensitive)
3. Kiểm tra CapsLock
4. Liên hệ Admin nếu account bị lock

#### **Problem: Không thấy khóa học trên Student Dashboard**

**Nguyên nhân:**
- Chưa được ghi danh
- Khóa học đã bị xóa
- Browser cache cũ

**Giải pháp:**
1. Refresh page (Ctrl+F5)
2. Clear browser cache
3. Admin kiểm tra enrollment record trong database
4. Liên hệ Admin để ghi danh lại

#### **Problem: "Access Denied" hoặc 403 error**

**Nguyên nhân:**
- Bạn không có quyền truy cập chức năng này
- Role không phù hợp

**Giải pháp:**
1. Kiểm tra bạn đang login với role nào
2. Student không thể vào Admin pages
3. Teacher không thể quản lý user
4. Liên hệ Admin nếu cần quyền khác

#### **Problem: Page bị blank hoặc error 500**

**Nguyên nhân:**
- Server error
- Database connection issue
- Code bug

**Giải pháp:**
1. Refresh page (F5)
2. Clear browser cache (Ctrl+Shift+Delete)
3. Logout + Login lại
4. Thử browser khác
5. Liên hệ Admin/Dev team nếu lỗi còn tồn tại

#### **Problem: Ghi danh không thành công**

**Nguyên nhân:**
- Sinh viên đã ghi danh khóa học này
- Khóa học không active
- Sinh viên không active

**Giải pháp:**
1. Kiểm tra sinh viên đã ghi danh chưa
2. Kiểm tra trạng thái course (Active/Inactive)
3. Kiểm tra trạng thái student (Active/Inactive)
4. Reload page và thử lại
5. Kiểm tra error message chi tiết

### **5.3 Contact Support**

**Khi gặp vấn đề:**

| Loại vấn đề | Contact | Time |
|------------|---------|------|
| Functional bug | QA Lead | 2-4 hours |
| Technical issue | Dev Lead | 1-2 hours |
| Account issue | Admin | Immediately |
| System down | Infrastructure Team | Immediately |

**Email:** support@sims.com  
**Phone:** +84 XXX XXX XXX  
**Hours:** 8:00 AM - 5:00 PM (Mon-Fri)

---

## 📋 SUMMARY

| Chức năng | Quyền | Trạng thái |
|-----------|--------|-----------|
| User Registration | Public | ✅ Active |
| User Login | Public | ✅ Active |
| Course Management | Admin | ✅ Active |
| Student Enrollment | Admin | ✅ Active |
| Dashboard | All | ✅ Active |
| Logout | All | ✅ Active |

---

**Document Version:** 1.0  
**Last Updated:** 28/01/2026  
**Next Review:** 15/02/2026  

*Tài liệu này sẽ được cập nhật khi có thay đổi chức năng.*
