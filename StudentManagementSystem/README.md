# Student Management System

## Giới thiệu

**Student Management System** là một hệ thống quản lý sinh viên được phát triển bằng ngôn ngữ C# trên nền tảng ASP.NET Core MVC. Dự án này hỗ trợ các chức năng quản lý sinh viên, khóa học, ghi danh, phân quyền người dùng (Admin, Giáo viên, Sinh viên), và các tính năng xác thực, đăng nhập, đăng ký tài khoản.

## Tính năng chính
- Quản lý thông tin sinh viên, giáo viên, khóa học
- Ghi danh sinh viên vào các khóa học
- Phân quyền người dùng: Admin, Giáo viên, Sinh viên
- Đăng nhập, đăng ký, xác thực tài khoản
- Giao diện web thân thiện, dễ sử dụng

## Yêu cầu hệ thống
- .NET 8.0 SDK trở lên
- SQL Server (hoặc SQLite tuỳ cấu hình)
- Visual Studio 2022 hoặc IDE hỗ trợ .NET 8

## Hướng dẫn cài đặt và chạy dự án

### 1. Clone dự án
```bash
git clone <link-repo-cua-ban>
cd APDP_SIMS_GR2_SE06304/StudentManagementSystem
```

### 2. Cài đặt các package/phụ thuộc
```bash
dotnet restore
```

### 3. Cấu hình chuỗi kết nối cơ sở dữ liệu
- Mở file `appsettings.json` và chỉnh sửa chuỗi kết nối trong mục `ConnectionStrings` cho phù hợp với môi trường của bạn.

### 4. Thực hiện migration và tạo database
```bash
dotnet ef database update
```

### 5. Chạy dự án
```bash
dotnet run
```
- Sau khi chạy thành công, truy cập trình duyệt tại địa chỉ: `https://localhost:5001` hoặc `http://localhost:5000`

## Thông tin liên hệ
- Nhóm phát triển: APDP_ASM_GR2
- Email: <email-nhom>

---
Bạn có thể tuỳ chỉnh, mở rộng thêm các tính năng theo nhu cầu thực tế. 