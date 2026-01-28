# README - TEST DOCUMENTATION

## Tài liệu Test cho Student Management System

Thư mục này chứa tất cả tài liệu test bao gồm test case, bug report, test plan, và hướng dẫn chức năng.

---

## 📁 CÁC FILE TRONG THƯ MỤC

### **1. Test_Plan.md** 📋
**Mục đích:** Kế hoạch kiểm thử chi tiết

**Nội dung:**
- Mục tiêu test
- Phạm vi test (in & out of scope)
- Chiến lược test
- Môi trường test
- Lịch trình test
- Công cụ & tài liệu
- Nhân sự & trách nhiệm
- Tiêu chí pass/fail
- Rủi ro & giảm thiểu

**Sử dụng:** Tất cả team members cần đọc trước khi bắt đầu test

---

### **2. Test_Case_Template.md** ✅
**Mục đích:** Chi tiết 24 test case

**Nội dung:**
- 24 test case đầy đủ cho từng chức năng
- Bảng test case với các cột: TC ID, Chức năng, Mô tả, Bước thực hiện, Dữ liệu, Kết quả mong đợi, Pass/Fail
- Các scenario test
- Thống kê test

**Sử dụng:** Testers chọn từng TC để thực thi
**Import vào Google Sheets:** Dùng file `Test_Cases.csv`

**Các chức năng test:**
- ✅ User Registration (TC001-004)
- ✅ User Login (TC005-009)
- ✅ Course Management (TC010-013)
- ✅ User Management (TC014-015)
- ✅ Student Enrollment (TC016-017)
- ✅ Student Dashboard (TC018-019)
- ✅ Role-Based Access (TC020-021)
- ✅ Logout (TC022)
- ✅ Error Handling (TC023-024)

---

### **3. Bug_Report_Template.md** 🐞
**Mục đích:** Hướng dẫn ghi bug report

**Nội dung:**
- Bảng bug report mẫu
- 10 bugs ví dụ từ test thực tế
- Hướng dẫn ghi bug chi tiết
- Mức độ nghiêm trọng (Severity Levels)
- Trạng thái bug (Status)
- Ví dụ ghi bug hoàn chỉnh
- Quy trình xử lý bug

**Sử dụng:** Khi gặp lỗi, ghi bug theo template này
**Import vào Google Sheets:** Dùng file `Bug_Reports.csv`

---

### **4. Test_Progress_Tracking.md** 📊
**Mục đích:** Theo dõi tiến độ test hàng ngày

**Nội dung:**
- Báo cáo tiến độ hàng ngày (5 ngày)
- Thống kê tuần
- Biểu đồ tiến độ
- Phân công test
- Tiến độ theo chức năng
- Bug tracking summary
- Test execution checklist

**Sử dụng:** Update hàng ngày, dashboard theo dõi tiến độ

---

### **5. Functional_Documentation.md** 📘
**Mục đích:** Hướng dẫn chức năng chi tiết

**Nội dung:**
- Giới thiệu hệ thống
- Các role người dùng
- Hướng dẫn từng chức năng:
  - Đăng ký (Registration)
  - Đăng nhập (Login)
  - Quản lý khóa học (Course Management)
  - Ghi danh (Enrollment)
  - Quản lý người dùng (User Management)
  - Dashboard
- Quy trình nghiệp vụ
- FAQ & Troubleshooting
- Hướng dẫn từng bước

**Sử dụng:** Khi cần hiểu chức năng hệ thống trước khi test

---

### **6. Test_Cases.csv** 📊
**Mục đích:** File CSV để import vào Google Sheets

**Nội dung:** 24 test case ở định dạng CSV
- TC ID
- Chức năng
- Mô tả
- Bước thực hiện
- Dữ liệu đầu vào
- Kết quả mong đợi
- Pass/Fail (trống để fill)
- Ghi chú

**Cách dùng:**
```
1. Mở Google Sheets
2. File → Import → Upload files → Test_Cases.csv
3. Tạo spreadsheet mới hoặc thêm vào sheet hiện tại
4. Testers fill vào cột Pass/Fail và Kết quả thực tế
5. Sử dụng file này để tracking hàng ngày
```

---

### **7. Bug_Reports.csv** 🐞
**Mục đích:** File CSV để import vào Google Sheets

**Nội dung:** 10 bugs ví dụ ở định dạng CSV
- Bug ID
- TC ID
- Tiêu đề
- Mô tả
- Bước tái hiện
- Kết quả mong đợi
- Kết quả thực tế
- Mức độ (Severity)
- Trạng thái (Status)
- Người xử lý
- Ghi chú

**Cách dùng:**
```
1. Mở Google Sheets
2. File → Import → Upload files → Bug_Reports.csv
3. Tạo spreadsheet mới hoặc thêm vào sheet hiện tại
4. Khi gặp bug, thêm hàng mới với thông tin chi tiết
5. Update trạng thái khi dev fix
```

---

## 🎯 CÁCH SỬ DỤNG GOOGLE SHEETS & DOCS

### **Google Sheets - Tạo Test Management Dashboard**

**Step 1: Tạo Spreadsheet mới**
```
1. Truy cập https://sheets.google.com
2. Click "Create" → "Spreadsheet"
3. Đặt tên: "SIMS Testing - Jan 2026"
```

**Step 2: Import Test Cases**
```
1. File → Import
2. Chọn "Test_Cases.csv"
3. Create new spreadsheet
4. Tạo sheet tabs:
   - Sheet 1: Test Case List
   - Sheet 2: Bug Report
   - Sheet 3: Progress Tracking
   - Sheet 4: Summary
```

**Step 3: Setup columns (Test Case Sheet)**
```
Cột A: TC ID (VD: TC001, TC002, ...)
Cột B: Chức năng
Cột C: Mô tả Test
Cột D: Bước thực hiện
Cột E: Dữ liệu
Cột F: Kết quả mong đợi
Cột G: Kết quả thực tế
Cột H: Pass/Fail (Dropdown: PASS, FAIL)
Cột I: Ghi chú
Cột J: Tester (Tên người test)
Cột K: Ngày test (Auto date)
```

**Step 4: Setup Bug Report Sheet**
```
Cột A: Bug ID
Cột B: TC ID (Link tới test case)
Cột C: Tiêu đề
Cột D: Mô tả
Cột E: Mức độ (Dropdown: CRITICAL, HIGH, MEDIUM, LOW)
Cột F: Trạng thái (Dropdown: Open, In Progress, Fixed, Retest, Closed)
Cột G: Người xử lý (Dev name)
Cột H: Priority
```

**Step 5: Setup Progress Tracking**
```
Cột A: Ngày
Cột B: Tester
Cột C: TC Hoàn thành
Cột D: Pass
Cột E: Fail
Cột F: Bugs phát hiện
Cột G: Ghi chú

Dùng COUNTIF để tính:
=COUNTIF(Sheet1!H:H,"PASS")
=COUNTIF(Sheet1!H:H,"FAIL")
```

**Step 6: Setup Summary Dashboard**
```
Các công thức:
- Total TC: =COUNTA(Sheet1!A:A)-1
- Total Pass: =COUNTIF(Sheet1!H:H,"PASS")
- Total Fail: =COUNTIF(Sheet1!H:H,"FAIL")
- Pass Rate: =TOTAL_PASS/TOTAL_TC
- Open Bugs: =COUNTIF(Sheet2!F:F,"Open")
- High Bugs: =COUNTIF(Sheet2!E:E,"HIGH")
```

### **Google Docs - Tạo Test Report**

**Step 1: Tạo Document**
```
1. Truy cập https://docs.google.com
2. Click "Create" → "Document"
3. Đặt tên: "SIMS Testing - Test Report"
```

**Step 2: Cấu trúc Document**
```
📋 TEST REPORT
├── 📝 Executive Summary
│   ├── Status (PASS/FAIL/IN PROGRESS)
│   ├── Pass Rate
│   ├── Total Bugs
│   └── Recommendation
├── 📊 Test Statistics
│   ├── Test Cases Executed: 24
│   ├── Pass: X
│   ├── Fail: Y
│   └── Blockers: N
├── 🐞 Critical Issues
│   └── List HIGH/CRITICAL bugs
├── 📈 Test Execution Summary
│   ├── By Feature (Course Mgmt, Login, etc)
│   └── By Tester
├── 📌 Recommendations
│   ├── Ready for UAT?
│   └── Go Live?
└── 📎 Appendix
    ├── Test Cases Link
    └── Bug Report Link
```

**Step 3: Embed Sheets dalam Docs**
```
1. Dalam Google Docs
2. Click "+" → "Chart"
3. Pilih Google Sheets data
4. Nhúng chart hiển thị Pass/Fail rate
```

---

## 📅 LỊCH TRÌNH TEST

```
27/01/2026 (Thứ 3)
├── Morning: Prepare test data & environment
├── Afternoon: Smoke test (TC001-009: Registration & Login)
└── Evening: Report blockers

28/01/2026 (Thứ 4)
├── Morning: Continue Functional Test
├── Afternoon: Test Course Management & Admin features
└── Evening: Log bugs

29/01/2026 (Thứ 5)
├── Morning: Test Student features
├── Afternoon: Test Authorization & Error handling
└── Evening: Consolidate bugs

30-31/01/2026 (Thứ 6-7)
├── Regression test
├── Re-test bugs
└── Prepare report

01/02/2026 (Thứ 2)
├── Final testing
├── Dev review
└── Release decision
```

---

## 🔑 KEY METRICS

| Metric | Target | Formula |
|--------|--------|---------|
| **Pass Rate** | ≥ 90% | PASS / TOTAL * 100 |
| **Bug Escape** | 0 CRITICAL | CRITICAL bugs in prod |
| **Test Coverage** | 100% | TC executed / Total TC |
| **Defect Density** | ≤ 5 bugs | Total bugs / KLOC |
| **Test Efficiency** | ≥ 80% | Bugs found / Test hours |

---

## ✅ CHECKLIST TRƯỚC KHI TEST

- [ ] Database đã reset
- [ ] Test data đã chuẩn bị
- [ ] Tất cả tester đã có tài khoản
- [ ] Google Sheets & Docs setup sẵn sàng
- [ ] Test Plan đã reviewed
- [ ] Environment stable
- [ ] VPN/Network ổn định
- [ ] Browser tools installed (DevTools, extensions)

---

## 🆘 SUPPORT & CONTACT

| Role | Name | Contact |
|------|------|---------|
| **QA Lead** | Lê Trường | letruong@test.com |
| **Dev Lead** | Dev Team | dev@company.com |
| **PM** | PM Team | pm@company.com |

**Quick Links:**
- 📊 [Test Cases Google Sheets](link)
- 🐞 [Bug Report Google Sheets](link)
- 📈 [Dashboard](link)

---

## 📚 THAM KHẢO THÊM

- [Student Management System - README](../README.md)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Test Case Best Practices](https://testautomationresources.com/)
- [Bug Report Template](./Bug_Report_Template.md)

---

**Document Version:** 1.0  
**Last Updated:** 28/01/2026  
**Next Review:** 05/02/2026

*Tất cả team members cần đọc tài liệu này trước khi bắt đầu testing.*
