# BUG REPORT - Student Management System

## Hướng dẫn ghi bug

### **Cấu trúc bảng Bug Report**

| Bug ID | TC ID | Tiêu đề Bug | Mô tả Lỗi | Bước Tái Hiện | Kết quả Mong Đợi | Kết quả Thực Tế | Mức độ Nghiêm Trọng | Trạng thái | Người Xử Lý | Ghi Chú |
|--------|-------|-------------|-----------|---------------|-----------------|-----------------|-------------------|-----------|------------|---------|
| **BUG001** | TC002 | Username validation không hoạt động | Khi nhập username trùng lặp, hệ thống không hiển thị lỗi | 1. Register<br>2. Nhập username "admin"<br>3. Click Register | Hiển thị: "Username đã được đăng ký" | Tài khoản được tạo thành công (lỗi) | **HIGH** | Open | Dev Team | Cần kiểm tra logic validation |
| **BUG002** | TC003 | Email validation không chặn email không hợp lệ | Email không hợp lệ vẫn được tạo tài khoản | 1. Register<br>2. Nhập email "invalidemail"<br>3. Click Register | Hiển thị lỗi email không hợp lệ | Tài khoản được tạo với email sai | **MEDIUM** | Open | Dev Team | Thêm regex validation |
| **BUG003** | TC008 | Thông báo lỗi đăng nhập quá chung chung | Login thất bại nhưng không rõ nguyên nhân | Đăng nhập sai password | Thông báo rõ: "Password không chính xác" | Thông báo: "Username/Password sai" | **LOW** | Open | Dev Team | Cải thiện UX |
| **BUG004** | TC013 | Xóa khóa học nhưng enrollment vẫn tồn tại | Khi xóa khóa học, các enrollment không bị xóa | 1. Add course<br>2. Enroll student<br>3. Delete course | Xóa course và all enrollment | Course bị xóa nhưng enrollment vẫn tồn tại | **HIGH** | Open | Dev Team | Cần cascade delete |
| **BUG005** | TC016 | Ghi danh sinh viên thất bại ngầm lặng | Click enroll nhưng không thấy thay đổi gì | 1. Assign Course<br>2. Select student & course<br>3. Click Enroll | Thông báo success & reload danh sách | Không có thông báo gì | **MEDIUM** | Open | Dev Team | Thêm toast notification |
| **BUG006** | TC018 | Student Dashboard không hiển thị enrolled courses | Sinh viên vào Dashboard nhưng không thấy khóa học | 1. Login as Student<br>2. Navigate to Dashboard | Hiển thị danh sách khóa học đã ghi danh | Danh sách trống | **HIGH** | Open | Dev Team | Kiểm tra query database |
| **BUG007** | TC022 | Logout không xóa session/cookies | Sau khi logout, vẫn có thể access tài khoản | 1. Login<br>2. Click Logout<br>3. Truy cập Student Dashboard | Redirect about Home, không thể vào Student Dashboard | Vẫn có thể vào Student Dashboard | **HIGH** | Open | Dev Team | Session/Cookie chưa được xóa |
| **BUG008** | TC001 | Input sanitization: XSS vulnerability | Có thể nhập JavaScript code trong Username | 1. Register<br>2. Username: `<script>alert('xss')</script>`<br>3. Submit | Lỗi validation hoặc sanitize | Username được lưu với code JS | **HIGH** | Open | Security Team | Cần implement input validation |
| **BUG009** | TC010 | Không validate StartDate > EndDate | Có thể tạo course với EndDate < StartDate | 1. Add Course<br>2. StartDate: 01/02/2026<br>3. EndDate: 01/01/2026 | Lỗi validation | Course được tạo với date sai | **MEDIUM** | Open | Dev Team | Thêm validation date range |
| **BUG010** | TC020 | Status Code không đúng khi access forbidden | Truy cập unauthorized page trả về 500 thay 403 | 1. Student login<br>2. Access /Admin/Dashboard | HTTP 403 Forbidden | HTTP 500 Internal Server Error | **MEDIUM** | Open | Dev Team | Kiểm tra error handling |

---

## 📊 BUG STATISTICS

| Chỉ số | Số lượng |
|--------|---------|
| **Tổng Bug** | 10 |
| **Open** | 10 |
| **Fixed** | 0 |
| **Retest** | 0 |
| **Closed** | 0 |
| **HIGH** | 6 |
| **MEDIUM** | 3 |
| **LOW** | 1 |

---

## 🎯 MỨC ĐỘ NGHIÊM TRỌNG (Severity Levels)

| Mức độ | Mô tả | Ví dụ |
|-------|-------|-------|
| **CRITICAL** | Hệ thống crash, không thể hoạt động | App crash khi đăng nhập |
| **HIGH** | Tính năng chính không hoạt động | Student dashboard không load, XSS vulnerability |
| **MEDIUM** | Tính năng phụ bị lỗi, có workaround | Notification không hiển thị, date validation sai |
| **LOW** | Lỗi UX, cosmetic issue | Thông báo quá chung chung, giao diện lệch |

---

## 🔄 TRẠNG THÁI BUG (Status)

| Trạng thái | Mô tả |
|-----------|-------|
| **Open** | Bug mới được báo cáo, chưa xử lý |
| **In Progress** | Dev đang sửa bug |
| **Fixed** | Dev đã fix, chờ tester kiểm tra lại |
| **Retest** | Tester đang kiểm tra lại fix |
| **Closed** | Bug đã được fix và verified |
| **Won't Fix** | Bug sẽ không được fix (quyết định từ PM) |
| **Duplicate** | Bug trùng với bug khác |

---

## 📝 HƯỚNG DẪN GHI BUG CHI TIẾT

### **Thông tin bắt buộc:**
1. **Bug ID**: BUG001, BUG002, ... (tự động tăng)
2. **TC ID**: Link tới Test Case
3. **Tiêu đề**: Ngắn gọn, rõ ràng
4. **Mô tả**: Chi tiết lỗi gặp phải
5. **Bước tái hiện**: Step-by-step để tái hiện bug
6. **Kết quả mong đợi vs Thực tế**: So sánh expected vs actual
7. **Mức độ nghiêm trọng**: CRITICAL, HIGH, MEDIUM, LOW
8. **Người xử lý**: Tên developer

### **Thông tin bổ sung:**
- **Browser**: Chrome, Firefox, Safari, Edge
- **OS**: Windows, macOS, Linux
- **Environment**: Development, Staging, Production
- **Ngày ghi**: Khi phát hiện bug
- **Attachment**: Screenshot, video, log file

---

## 📌 VÍ DỤ GHI BUG HOÀN CHỈNH

```
Bug ID: BUG001
TC ID: TC002
Tiêu đề: Username validation không hoạt động - Cho phép duplicate username

Mô tả:
Khi người dùng thử đăng ký với username đã tồn tại (admin), 
hệ thống không hiển thị lỗi mà thay vào đó tạo tài khoản thành công.

Bước tái hiện:
1. Truy cập http://localhost:5001/Account/Register
2. Nhập thông tin:
   - Username: admin (username đã tồn tại)
   - Password: Pass@123
   - Email: test@example.com
   - FullName: Test User
   - Role: Student
3. Click nút "Register"

Kết quả mong đợi:
- Thông báo lỗi: "Username đã được đăng ký, vui lòng dùng Username khác."
- Tài khoản không được tạo
- Vẫn ở trên trang Register

Kết quả thực tế:
- Không có thông báo lỗi
- Tài khoản mới được tạo thành công
- Chuyển hướng tới trang Login

Mức độ nghiêm trọng: HIGH

Người ghi bug: QA_Tester_01
Ngày ghi: 28/01/2026
Browser: Chrome 120
OS: Windows 11

Ghi chú:
- Lỗi này ảnh hưởng tới data integrity
- Cần kiểm tra AccountController.cs - Register method
- Có thể thiếu database unique constraint hoặc validation logic
```

---

## 🛠️ QUY TRÌNH XỬ LÝ BUG

```
QA Report Bug → Dev Review → Dev Fix → Staging Test → Retest by QA → Closed
     ↓
  Open status        In Progress      Fixed        Retest        Closed
```

