# QUICK REFERENCE - Test Documentation Summary

## TÓM TẮT CÁC TÀI LIỆU TEST

Dựa vào **Student Management System (SIMS)**, đây là bộ tài liệu test hoàn chỉnh:

---

## 📁 FILE STRUCTURE

```
TEST_DOCUMENTATION/
│
├── 📋 README.md                          ← START HERE! Hướng dẫn sử dụng
├── 📘 Test_Plan.md                       ← Kế hoạch test chi tiết
├── ✅ Test_Case_Template.md               ← 24 test case
├── 🐞 Bug_Report_Template.md              ← Hướng dẫn ghi bug
├── 📊 Test_Progress_Tracking.md           ← Theo dõi tiến độ
├── 📈 Google_Sheets_Setup_Guide.md        ← Hướng dẫn Google Sheets
├── 📘 Functional_Documentation.md         ← Hướng dẫn chức năng
│
├── 📊 Test_Cases.csv                     ← Import vào Google Sheets
└── 🐞 Bug_Reports.csv                    ← Import vào Google Sheets
```

---

## 🚀 BƯỚC 1: TẠO GOOGLE SHEETS

### **Tạo Spreadsheet:**

```
1. Truy cập https://sheets.google.com
2. Create → Spreadsheet
3. Đặt tên: "SIMS Testing - Jan 2026"
4. Share với team
```

### **Tạo Sheets:**

```
Sheet 1: Test Cases
Sheet 2: Bug Reports
Sheet 3: Progress Tracking
Sheet 4: Summary Dashboard
```

### **Import CSV:**

```
Cách 1 - Dùng File → Import:
  1. File → Import → Upload files
  2. Chọn Test_Cases.csv
  3. Create new spreadsheet
  4. Repeat cho Bug_Reports.csv

Cách 2 - Dùng Formula:
  =IMPORTCSV("url-to-csv-file")
```

---

## 🚀 BƯỚC 2: TẠO GOOGLE DOCS

### **Test Plan Document:**

```
1. Truy cập https://docs.google.com
2. Create → Document
3. Đặt tên: "SIMS Testing - Test Plan"
4. Copy content từ Test_Plan.md
5. Share với team
```

### **Test Report Document:**

```
1. Create → Document
2. Đặt tên: "SIMS Testing - Daily Report"
3. Update hàng ngày với:
   - Status
   - TC Executed
   - Pass/Fail count
   - Bugs found
   - Blockers
   - Next steps
```

---

## 📋 QUICK GUIDE - 24 TEST CASES

### **Chia theo chức năng:**

| Chức năng | Test Cases | Số TC |
|-----------|-----------|-------|
| 📝 **User Registration** | TC001-TC004 | 4 |
| 🔐 **User Login** | TC005-TC009 | 5 |
| 📚 **Course Management** | TC010-TC013 | 4 |
| 👥 **User Management** | TC014-TC015 | 2 |
| 📝 **Student Enrollment** | TC016-TC017 | 2 |
| 📊 **Student Dashboard** | TC018-TC019 | 2 |
| 🔒 **Role-Based Access** | TC020-TC021 | 2 |
| 🚪 **Logout** | TC022 | 1 |
| ⚠️ **Error Handling** | TC023-TC024 | 2 |
| | **TOTAL** | **24** |

---

## 🐞 QUICK GUIDE - BUG TRACKING

### **10 Sample Bugs:**

| Bug ID | Severity | Status | Category |
|--------|----------|--------|----------|
| BUG001 | 🔴 HIGH | Open | Username Validation |
| BUG002 | 🟡 MEDIUM | Open | Email Validation |
| BUG003 | 🔵 LOW | Closed | Error Message UX |
| BUG004 | 🔴 HIGH | Open | Course Deletion |
| BUG005 | 🟡 MEDIUM | Open | Notification |
| BUG006 | 🔴 HIGH | Open | Dashboard Query |
| BUG007 | 🔴 HIGH | Open | Session Management |
| BUG008 | 🔴 HIGH | Open | XSS Vulnerability |
| BUG009 | 🟡 MEDIUM | Open | Date Validation |
| BUG010 | 🟡 MEDIUM | Open | Error Status Code |

---

## 📊 TEST EXECUTION TIMELINE

```
27/01/2026 (Thứ 3)
├── Setup environment & test data
├── Smoke Test: Registration & Login (TC001-TC009)
└── Find 2-3 initial bugs

28/01/2026 (Thứ 4)
├── Functional Test: Course Management (TC010-TC013)
├── User Management & Enrollment (TC014-TC017)
└── Find 3-4 more bugs

29/01/2026 (Thứ 5)
├── Student features & Dashboard (TC018-TC019)
├── Authorization & Error Handling (TC020-TC024)
└── Find 2-3 remaining bugs

30-31/01/2026 (Thứ 6-7)
├── Regression Test
├── Retest found bugs
└── Consolidate findings

01-05/02/2026 (Tuần 2)
├── Dev fixes bugs
├── QA retests fixes
└── Prepare release
```

---

## ✅ GOOGLE SHEETS STRUCTURE

### **Sheet 1: Test Cases**

```
Columns:
A: TC ID          (TC001, TC002...)
B: Feature        (Registration, Login...)
C: Description    (What to test)
D: Steps          (How to test)
E: Test Data      (Input values)
F: Expected       (What should happen)
G: Actual         (What happened) ← Fill during test
H: PASS/FAIL      (Result) ← Dropdown validation
I: Tester Name    (Who tested)
J: Test Date      (Auto today)
K: Notes          (Any issues)

Validation:
- Column B: Dropdown (Features)
- Column H: Dropdown (PASS, FAIL)
- Column I: Dropdown (Tester names)
```

### **Sheet 2: Bug Reports**

```
Columns:
A: Bug ID         (BUG001, BUG002...)
B: TC ID          (Link to test case)
C: Title          (Short bug title)
D: Description    (Detailed description)
E: Steps          (How to reproduce)
F: Severity       (CRITICAL, HIGH, MEDIUM, LOW)
G: Status         (Open, In Progress, Fixed, Retest, Closed)
H: Assigned To    (Dev name)
I: Found Date     (Auto today)
J: Fixed Date     (Dev fills)
K: Notes          (Additional info)

Conditional Formatting:
- Severity: Color code (Red=CRITICAL, Orange=HIGH, Yellow=MEDIUM, Blue=LOW)
- Status: Color code per status
```

### **Sheet 3: Progress Tracking**

```
Columns:
A: Date           (27/01, 28/01...)
B: Tester         (QA_Tester_01...)
C: TC Completed   (Number)
D: Pass           (Count)
E: Fail           (Count)
F: Bugs Found     (Count)
G: Pass Rate %    (Formula: D/C*100)
H: Notes          (Issues/Blockers)

Charts:
- Line chart: Daily progress
- Pie chart: Pass/Fail rate
- Bar chart: Bugs by severity
```

### **Sheet 4: Summary Dashboard**

```
Key Metrics:
📊 TEST STATS          🐞 BUG STATS
Total TC: 24           Total Bugs: 10
Executed: 20           Open: 8
Pass: 11 (55%)         Closed: 2 (20%)
Fail: 9 (45%)          HIGH: 6 (60%)

STATUS: 🟡 IN PROGRESS
RECOMMENDATION: Fix bugs → Retest → UAT Ready
```

---

## 🔑 KEY SUCCESS FACTORS

| Factor | Target | Status |
|--------|--------|--------|
| **Pass Rate** | ≥ 90% | 🟡 Current 55% |
| **No CRITICAL bugs** | 0 | ✅ OK |
| **HIGH bugs fixed** | ≥ 80% | 🟡 Pending |
| **Test Coverage** | 100% | ✅ 24/24 cases |
| **Blockers** | 0 | 🟡 2 blockers |

---

## 🎯 DAILY CHECKLIST

### **Trước khi test:**
- [ ] Database reset
- [ ] Test accounts ready
- [ ] Google Sheets updated
- [ ] Test data prepared
- [ ] Environment stable
- [ ] Browser cleaned

### **Trong lúc test:**
- [ ] Follow test case steps strictly
- [ ] Fill actual results in column G
- [ ] Mark PASS or FAIL in column H
- [ ] Note any issues
- [ ] Take screenshots of failures
- [ ] Ghi bugs immediately

### **Sau khi test:**
- [ ] Update Google Sheets
- [ ] Create bug reports
- [ ] Notify team of blockers
- [ ] Plan next day tasks
- [ ] Archive evidence

---

## 🚨 ESCALATION PATH

```
🟡 MEDIUM Issue
  ↓
Mention in daily standup
  ↓
QA Lead reviews
  ↓
Dev Team scheduled

🔴 HIGH Issue
  ↓
Alert QA Lead + Dev Lead immediately
  ↓
Team meeting within 2 hours
  ↓
Dev starts fixing same day

🔴 CRITICAL Issue
  ↓
STOP all testing
  ↓
Alert all stakeholders
  ↓
Emergency team call
  ↓
Fix immediately
```

---

## 📞 CONTACTS

| Role | Name | Email | Phone |
|------|------|-------|-------|
| QA Lead | Lê Trường | letruong@company.com | +84 XXX XXX |
| Dev Lead | Dev Team | dev.lead@company.com | +84 XXX XXX |
| PM | PM Team | pm@company.com | +84 XXX XXX |

---

## 🔗 USEFUL LINKS

- [Google Sheets Setup Guide](./Google_Sheets_Setup_Guide.md)
- [Test Plan Document](./Test_Plan.md)
- [Test Cases Detail](./Test_Case_Template.md)
- [Bug Report Guide](./Bug_Report_Template.md)
- [Functional Documentation](./Functional_Documentation.md)
- [Progress Tracking](./Test_Progress_Tracking.md)

---

## 📚 DOCUMENTATION VERSIONS

| Document | Version | Updated | Owner |
|----------|---------|---------|-------|
| Test Plan | 1.0 | 28/01/2026 | QA Lead |
| Test Cases | 1.0 | 28/01/2026 | QA Team |
| Bug Report | 1.0 | 28/01/2026 | QA Team |
| Functional Docs | 1.0 | 28/01/2026 | QA Team |
| Google Sheets | 1.0 | 28/01/2026 | QA Lead |

---

## ⚡ QUICK COMMANDS

```
📊 View Test Summary:
Sheet 4 (Dashboard) → See overall stats

🔍 Find Failed Tests:
Sheet 1 → Filter H=FAIL

🐞 Track Bugs:
Sheet 2 → Filter G=Open, Sort F=HIGH

📈 Track Progress:
Sheet 3 → Look at G (Pass Rate %)

📝 Update Report:
Google Doc → Add today's section
```

---

## 🎓 TRAINING

**New testers:** Read in this order:

1. ✅ Functional_Documentation.md - Hiểu hệ thống
2. ✅ Test_Plan.md - Biết kế hoạch
3. ✅ Test_Case_Template.md - Xem 24 TC
4. ✅ Google_Sheets_Setup_Guide.md - Setup sheets
5. ✅ Start testing!

**Time needed:** ~2 hours to get up to speed

---

## 🏆 TESTING BEST PRACTICES

```
✅ DO:
- Follow test cases exactly
- Document everything
- Test on multiple browsers
- Clear cache before testing
- Verify database changes
- Report bugs immediately
- Communicate blockers

❌ DON'T:
- Skip test case steps
- Assume expected behavior
- Test only on Chrome
- Reuse test data
- Modify test cases mid-testing
- Delay bug reporting
- Panic on failures (it's normal!)
```

---

**Ready to test? Let's go! 🚀**

**Next Steps:**
1. ✅ Create Google Sheets & Docs
2. ✅ Import CSV files
3. ✅ Share with team
4. ✅ Hold kickoff meeting
5. ✅ Start executing test cases!

---

*Last Updated: 28/01/2026*  
*Version: 1.0*  
*Team: SIMS QA*
