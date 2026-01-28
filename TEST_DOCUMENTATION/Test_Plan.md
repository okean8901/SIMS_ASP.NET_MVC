# TEST PLAN - Student Management System v1.0

**Document Version:** 1.0  
**Last Updated:** 28/01/2026  
**Prepared by:** QA Team  
**Approved by:** Project Manager  

---

## 📑 MỤC LỤC

1. [Giới thiệu](#1-giới-thiệu)
2. [Mục tiêu Test](#2-mục-tiêu-test)
3. [Phạm vi Test](#3-phạm-vi-test)
4. [Chiến lược Test](#4-chiến-lược-test)
5. [Môi trường Test](#5-môi-trường-test)
6. [Khoá Test](#6-khoá-test)
7. [Công cụ & Tài liệu](#7-công-cụ--tài-liệu)
8. [Nhân sự & Trách nhiệm](#8-nhân-sự--trách-nhiệm)
9. [Tiêu chí Pass/Fail](#9-tiêu-chí-passfail)
10. [Rủi ro & Kế hoạch giảm thiểu](#10-rủi-ro--kế-hoạch-giảm-thiểu)

---

## 1️⃣ GIỚI THIỆU

### **1.1 Tổng quan hệ thống**

**Student Management System (SIMS)** là một ứng dụng web xây dựng bằng ASP.NET Core MVC cho phép:
- Quản lý thông tin sinh viên, giáo viên, khóa học
- Ghi danh sinh viên vào khóa học
- Phân quyền người dùng (Admin, Teacher, Student)
- Xác thực & cấp phép người dùng

### **1.2 Phiên bản được test**
- **Version:** 1.0
- **Build:** Release
- **Release Date:** 31/01/2026

### **1.3 Tài liệu tham khảo**
- Yêu cầu chức năng (FRD)
- Thiết kế hệ thống (SDD)
- Hướng dẫn sử dụng

---

## 2️⃣ MỤC TIÊU TEST

### **2.1 Mục tiêu chính**

| Mục tiêu | Mô tả | KPI |
|----------|--------|-----|
| **Chất lượng** | Đảm bảo hệ thống hoạt động đúng theo yêu cầu | Pass rate ≥ 90% |
| **Độ tin cậy** | Hệ thống ổn định, không crash | 0 CRITICAL bugs |
| **Bảo mật** | Không có lỗ hổng bảo mật nghiêm trọng | 0 HIGH security bugs |
| **Hiệu năng** | Response time < 2 giây | Load time < 1s |
| **Tương thích** | Hoạt động trên các browser chính | Chrome, Firefox, Safari, Edge |

### **2.2 Tiêu chí success**

✅ Tất cả test case PASS  
✅ Không có bug HIGH hoặc CRITICAL còn open  
✅ Tỷ lệ code coverage ≥ 80%  
✅ Performance test passed  
✅ Security audit passed  

---

## 3️⃣ PHẠM VI TEST

### **3.1 Tính năng được test**

#### **✅ TRONG PHẠM VI:**

| Module | Chi tiết |
|--------|---------|
| **User Management** | Đăng ký, Đăng nhập, Đăng xuất, Quản lý tài khoản |
| **Course Management** | Thêm, Sửa, Xóa khóa học, Xem danh sách |
| **Student Enrollment** | Ghi danh sinh viên, Xem khóa học đã ghi danh |
| **Authorization** | Phân quyền Role-based (Admin, Teacher, Student) |
| **Dashboard** | Admin Dashboard, Student Dashboard, Teacher Dashboard |
| **Error Handling** | 404, 403, 500, Validation errors |

#### **❌ NGOÀI PHẠM VI:**

- Email sending (nếu không implement)
- SMS notifications
- Payment gateway
- Mobile app
- API testing (nếu API tách rời)
- Load testing (ngoài scope)
- Database migration testing

### **3.2 Test levels**

| Level | Phạm vi | Owner |
|-------|--------|-------|
| **Unit Test** | Hàm/Method riêng lẻ | Dev Team (Đã xong) |
| **Integration Test** | Controller + Repository + Database | Dev Team (Đang làm) |
| **System Test** | Toàn bộ ứng dụng | QA Team |
| **UAT** | User acceptance test | End Users |

---

## 4️⃣ CHIẾN LƯỢC TEST

### **4.1 Loại test cần thực hiện**

| Loại Test | Mô tả | Effort |
|-----------|-------|--------|
| **Functional Testing** | Kiểm tra tính năng hoạt động đúng | 70% |
| **Regression Testing** | Kiểm tra khi có fix bug | 15% |
| **Performance Testing** | Kiểm tra tốc độ, load | 10% |
| **Security Testing** | Kiểm tra lỗ hổng bảo mật | 5% |

### **4.2 Test case coverage**

- **Total Test Cases:** 24 cases
- **Regression TC:** 5 cases
- **Smoke TC:** 8 cases (chạy hàng ngày)
- **Sanity TC:** 4 cases (sanity check)

### **4.3 Test approach**

```
1. Smoke Testing (Ngày 1)
   → Kiểm tra các chức năng cơ bản
   
2. Functional Testing (Ngày 2-4)
   → Test tất cả 24 test cases
   
3. Regression Testing (Ngày 5)
   → Re-test các bug đã fix
   
4. Exploratory Testing (Ngày 5)
   → Test thêm các edge cases
   
5. UAT Preparation (Ngày 6-7)
   → Chuẩn bị cho user acceptance test
```

---

## 5️⃣ MÔI TRƯỜNG TEST

### **5.1 Thông tin môi trường**

| Yếu tố | Chi tiết |
|--------|---------|
| **Tên môi trường** | Development/Staging |
| **URL** | http://localhost:5001 (Dev)<br>https://staging.sims.com (Staging) |
| **Database** | SQL Server 2019 (Dev)<br>SQL Server 2022 (Staging) |
| **Web Server** | IIS Express (Dev)<br>IIS 10 (Staging) |
| **OS** | Windows 11 Pro (Dev)<br>Windows Server 2019 (Staging) |

### **5.2 Cấu hình máy tester**

| Thông số | Yêu cầu |
|----------|--------|
| **Processor** | Intel i5 trở lên |
| **RAM** | 8GB tối thiểu |
| **Browser** | Chrome 120+, Firefox 121+, Safari 17+, Edge 120+ |
| **Internet** | Kết nối ổn định |

### **5.3 Chuẩn bị test data**

```sql
-- Tài khoản test
Admin:
  Username: admin
  Password: Admin@123
  Email: admin@sims.com

Teacher:
  Username: teacher01
  Password: Teacher@123
  Email: teacher@sims.com

Students:
  Username: student01-10
  Password: Student@123
  Email: studentXX@sims.com

Test Courses:
  - Mathematics 101 (MATH101)
  - Physics 102 (PHYS102)
  - English 103 (ENG103)
```

---

## 6️⃣ KHOÁ TEST

### **6.1 Lịch trình test**

```
                    Jan 2026
    Su Mo Tu We Th Fr Sa
              1  2  3  4
     5  6  7  8  9 10 11
    12 13 14 15 16 17 18
    19 20 21 22 23 24 25
    26 27[28]29 30 31

    [28] = Ngày start testing (27/01/2026)
```

### **6.2 Timeline chi tiết**

| Tuần | Ngày | Giai đoạn | Mục tiêu | Status |
|-----|------|----------|---------|--------|
| **W1** | 27/01 | Smoke Test | Kiểm tra chức năng cơ bản | ⏳ In Progress |
| | 28-29/01 | Functional Test | Test tất cả 24 TC | ⏳ In Progress |
| | 30-31/01 | Bug Investigation | Tái hiện & ghi bug | ⏳ In Progress |
| | 01/02 | Regression Test | Re-test các fix | ⏳ Planned |
| **W2** | 03-04/02 | Bug Fixing | Dev xử lý bugs | 📋 Planned |
| | 05/02 | Retest | QA verify fix | 📋 Planned |
| | 06/02 | UAT Prep | Chuẩn bị cho users | 📋 Planned |
| | 07-09/02 | UAT | User acceptance test | 📋 Planned |
| | 10/02 | Release | Deploy to production | 📋 Planned |

### **6.3 Milestone**

- **M1:** Smoke test pass (27/01)
- **M2:** All TC executed (31/01)
- **M3:** All HIGH bugs fixed (05/02)
- **M4:** UAT ready (06/02)
- **M5:** Go live (10/02)

---

## 7️⃣ CÔNG CỤ & TÀI LIỆU

### **7.1 Công cụ testing**

| Công cụ | Mục đích | Version |
|--------|---------|--------|
| **Google Sheets** | Test Case Management | Online |
| **Google Docs** | Bug Report, Test Plan | Online |
| **Chrome DevTools** | Debugging, Network inspection | Latest |
| **Visual Studio Code** | Source code review | 1.96 |
| **SQL Server Management Studio** | Database query | 19 |
| **Postman** | API testing (nếu cần) | 11 |

### **7.2 Tài liệu cần chuẩn bị**

- ✅ Test Case Document
- ✅ Test Plan (tài liệu này)
- ✅ Bug Report Template
- ✅ Test Execution Report
- ✅ Requirements Traceability Matrix (RTM)

### **7.3 Test artifacts**

```
📁 TEST_DOCUMENTATION/
├── 📄 Test_Plan.md (tài liệu này)
├── 📄 Test_Case_Template.md (24 test cases)
├── 📄 Bug_Report_Template.md
├── 📄 Test_Progress_Tracking.md
├── 📄 Test_Report.md
├── 📁 Screenshots/
│   ├── 🖼️ TC001_Pass.png
│   ├── 🖼️ BUG001_Screenshot.png
│   └── ...
└── 📁 Logs/
    ├── 📋 test_execution_27jan.log
    └── ...
```

---

## 8️⃣ NHÂN SỰ & TRÁCH NHIỆM

### **8.1 Team structure**

| Role | Name | Responsibility | Contact |
|------|------|-----------------|---------|
| **QA Lead** | Lê Trường | Giám sát, báo cáo | letruong@test.com |
| **Dev Lead** | Dev Team | Fix bugs, code review | dev@company.com |
| **Product Owner** | PM Team | Approval, scope change | pm@company.com |

### **8.2 Phân công test**

| Tester | Chức năng | Test Cases | Effort |
|--------|-----------|-----------|--------|
| Tester 1 | User Registration & Login | TC001-TC009 | 8 hours |
| Tester 2 | Course Management | TC010-TC017 | 8 hours |
| Tester 3 | Student Module | TC018-TC024 | 8 hours |
| QA Lead | Regression, Reporting | All TC + bugs | 16 hours |

### **8.3 Trách nhiệm**

**QA Tester:**
- Thực thi test cases
- Ghi lại kết quả
- Báo cáo bugs
- Retest fixes

**Dev Team:**
- Fix bugs trong thời gian quy định
- Code review
- Cung cấp fix notes
- Tham gia bug investigation meeting

**QA Lead:**
- Giám sát tiến độ
- Báo cáo hàng ngày
- Escalate blockers
- Quyết định go-live

---

## 9️⃣ TIÊU CHÍ PASS/FAIL

### **9.1 Test Case Pass Criteria**

✅ **TC PASS khi:**
- Expected result = Actual result
- Không có unexpected error messages
- Data được lưu chính xác vào database
- UI responsive, không bị hang/crash
- Navigation hoạt động đúng

### **9.2 Test Case Fail Criteria**

❌ **TC FAIL khi:**
- Actual result ≠ Expected result
- Hiển thị error messages
- Data không được lưu hoặc bị lưu sai
- UI hang, crash, hoặc error
- Navigation không hoạt động

### **9.3 Exit Criteria (Điều kiện kết thúc test)**

**PASS (Cho phép release):**
- ✅ 100% Test cases executed
- ✅ ≥ 90% Test cases passed
- ✅ 0 CRITICAL bugs open
- ✅ 0 HIGH bugs open (tối đa 2 can fix later)
- ✅ Không có data loss risk
- ✅ Performance acceptable

**FAIL (Không cho phép release):**
- ❌ Pass rate < 80%
- ❌ Có CRITICAL/HIGH bugs
- ❌ Data loss risk
- ❌ Security vulnerability
- ❌ Performance issue (response time > 5s)

---

## 🔟 RỦI RO & KẾ HOẠCH GIẢM THIỂU

### **10.1 Rủi ro chính**

| Rủi ro | Mô tả | Ảnh hưởng | Xác suất | Kế hoạch giảm thiểu |
|--------|-------|-----------|----------|-------------------|
| **R1** | Database không sẵn sàng | Block test | Medium | Reset DB hàng ngày, backup dữ liệu |
| **R2** | Dev không fix bug kịp | Delay release | High | Daily standup, prioritize bugs |
| **R3** | Tester không có đủ TC | Test không đầy đủ | Low | Chuẩn bị TC sớm, review RTM |
| **R4** | Environment issue | Test không thể chạy | Medium | Test environment monitoring, fallback env |
| **R5** | Scope creep | Test time tăng | High | Lock scope, change request process |

### **10.2 Contingency plan**

```
Nếu database down:
  → Switch sang backup environment
  → Notify team, adjust timeline

Nếu dev không fix bug kịp:
  → Escalate to PM
  → Quyết định: accept risk hoặc delay release

Nếu environment crash:
  → Revert last stable version
  → Continue testing trên backup env

Nếu scope change:
  → Stop current test
  → Review scope changes
  → Update test plan
  → Restart testing
```

### **10.3 Assumptions**

- ✅ Database accessible 24/7
- ✅ Dev team available để fix bugs
- ✅ No major infrastructure changes
- ✅ Test team có đủ resource
- ✅ Scope không thay đổi

---

## 📊 TEST SUMMARY

| Thông số | Con số | Chi tiết |
|----------|--------|---------|
| **Test Duration** | 10 days | 27/01 - 05/02/2026 |
| **Total Test Cases** | 24 | Functional tests |
| **Expected Bugs** | 8-12 | Ước tính |
| **Resource Needed** | 3 QA + 1 Lead | 40 hours/person |
| **Budget** | ~$2000 | Testing resource cost |
| **Success Criteria** | 90% pass rate | + 0 CRITICAL bugs |

---

## ✅ APPROVAL

| Role | Name | Signature | Date |
|------|------|-----------|------|
| **QA Lead** | Lê Trường | ________________ | 28/01/2026 |
| **PM** | PM Team | ________________ | 28/01/2026 |
| **Dev Lead** | Dev Team | ________________ | 28/01/2026 |

---

## 📚 APPENDIX

### **A. Test Case Template**
[Link to Test Case Document]

### **B. Bug Report Template**
[Link to Bug Report Document]

### **C. RTM (Requirements Traceability Matrix)**
| REQ ID | Description | TC ID | Status |
|--------|-------------|-------|--------|
| REQ001 | User can register | TC001-TC004 | ✅ |
| REQ002 | User can login | TC005-TC009 | ✅ |
| ... | ... | ... | ... |

### **D. Glossary**

- **TC:** Test Case
- **RTM:** Requirements Traceability Matrix
- **UAT:** User Acceptance Test
- **SDD:** System Design Document
- **FRD:** Functional Requirements Document

---

**Document End**  
*Phiên bản: 1.0 | Ngày cập nhật: 28/01/2026*
