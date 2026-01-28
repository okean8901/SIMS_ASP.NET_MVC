# TEST DOCUMENTATION INDEX

## Student Management System (SIMS) - Complete Test Documentation Package

**Version:** 1.0  
**Created:** 28/01/2026  
**Status:** Ready for Testing  

---

## 🎯 START HERE

👉 **Mới làm quen?** Đọc file này trước: [QUICK_REFERENCE.md](./QUICK_REFERENCE.md)

👉 **Setup Google Sheets/Docs?** Xem: [Google_Sheets_Setup_Guide.md](./Google_Sheets_Setup_Guide.md)

👉 **Hiểu chức năng hệ thống?** Đọc: [Functional_Documentation.md](./Functional_Documentation.md)

---

## 📁 FILE GUIDE

### **📋 Planning & Strategy**

#### [Test_Plan.md](./Test_Plan.md) 📋
**Kế hoạch kiểm thử chi tiết (10 phần)**

Nội dung:
- Mục tiêu test (Quality, Reliability, Security, Performance)
- Phạm vi test (Features in/out of scope)
- Chiến lược test (Test levels, approach)
- Môi trường test (Setup, configuration)
- Timeline (Schedule, milestones)
- Công cụ & tài liệu
- Team structure & trách nhiệm
- Pass/Fail criteria
- Risk management
- 📊 Approval signatures

**Ai cần đọc:** Tất cả team members (QA, Dev, PM)  
**Thời gian:** 30 phút đọc  
**Khi nào dùng:** Trước khi bắt đầu testing  

---

### **✅ Test Cases**

#### [Test_Case_Template.md](./Test_Case_Template.md) ✅
**24 test case hoàn chỉnh cho tất cả chức năng**

Nội dung:
- 24 test cases chi tiết (bảng dạng markdown)
- TC001-TC004: User Registration (4 cases)
- TC005-TC009: User Login (5 cases)
- TC010-TC013: Course Management (4 cases)
- TC014-TC015: User Management (2 cases)
- TC016-TC017: Student Enrollment (2 cases)
- TC018-TC019: Student Dashboard (2 cases)
- TC020-TC021: Role-Based Access (2 cases)
- TC022: Logout (1 case)
- TC023-TC024: Error Handling (2 cases)
- 📊 Test summary statistics
- 4 test scenarios
- Tester notes

**Columns:**
```
TC ID | Chức năng | Mô tả | Bước | Dữ liệu | KQ Mong Đợi | KQ Thực Tế | Pass/Fail | Ghi chú
```

**Ai cần dùng:** QA Testers  
**Cách dùng:** 
1. Chọn 1 TC
2. Thực hiện theo bước
3. Ghi kết quả (Pass/Fail)
4. Tạo bug nếu fail

**Import to Google Sheets:**
- Dùng [Test_Cases.csv](./Test_Cases.csv) file
- File → Import → Upload Test_Cases.csv

---

### **🐞 Bug Management**

#### [Bug_Report_Template.md](./Bug_Report_Template.md) 🐞
**Hướng dẫn ghi bug chi tiết**

Nội dung:
- Cách ghi bug (structured format)
- 10 sample bugs (từ test thực tế)
- Bảng bug report mẫu
- Severity levels (CRITICAL, HIGH, MEDIUM, LOW)
- Bug status (Open, In Progress, Fixed, Retest, Closed)
- Ví dụ bug report hoàn chỉnh
- Bug handling process
- 📊 Bug statistics

**Ví dụ bugs:**
| ID | Severity | Category | Status |
|----|----------|----------|--------|
| BUG001 | 🔴 HIGH | Username Validation | Open |
| BUG002 | 🟡 MEDIUM | Email Validation | Open |
| BUG003 | 🔵 LOW | Error Message | Closed |
| ... | ... | ... | ... |

**Ai cần dùng:** QA Testers, Dev Team  
**Khi nào dùng:** Khi gặp lỗi  
**Import to Google Sheets:**
- Dùng [Bug_Reports.csv](./Bug_Reports.csv) file
- File → Import → Upload Bug_Reports.csv

---

### **📊 Tracking & Reporting**

#### [Test_Progress_Tracking.md](./Test_Progress_Tracking.md) 📊
**Theo dõi tiến độ test hàng ngày**

Nội dung:
- Daily test execution log (27/01 - 31/01)
- Weekly statistics & summary
- Test progress charts
- Team allocation
- Feature-wise progress
- Bug tracking summary
- Re-test checklist
- Week 2 plan (02/02 - 08/02)

**Metrics tracked:**
- TC executed per day
- Pass/Fail ratio
- Bugs found
- Bugs fixed
- Pass rate %
- Tester productivity

**Ai cần dùng:** QA Lead, Testers  
**Update:** Hàng ngày (end of day)  

---

### **📘 User Guides**

#### [Functional_Documentation.md](./Functional_Documentation.md) 📘
**Hướng dẫn chức năng & sử dụng hệ thống**

Nội dung:
- 🎯 System overview
- 👥 User roles (Admin, Teacher, Student, Guest)
- 🏗️ System architecture
- **Chức năng chi tiết:**
  - 📝 User Registration (với validation rules)
  - 🔐 User Login (session management)
  - 🚪 Logout
  - 📚 Course Management (CRUD operations)
  - 👥 User Management
  - 📝 Student Enrollment
  - 📊 Dashboard (Admin/Student/Teacher)
- **Step-by-step guides:**
  - Step 1: New User Registration
  - Step 2: Admin Add Course
  - Step 3: Assign Student to Course
  - Step 4: Student View Courses
- **Business processes:**
  - New semester setup flow
  - User management flow
  - Enrollment flow
- **FAQ & Troubleshooting** (7 common issues + solutions)
- **Contact & Support**

**Ai cần dùng:** Testers (để hiểu hệ thống), End Users (để dùng hệ thống)  
**Khi nào dùng:** Trước test, khi testing, troubleshooting  

---

### **⚙️ Setup Guides**

#### [Google_Sheets_Setup_Guide.md](./Google_Sheets_Setup_Guide.md) ⚙️
**Hướng dẫn setup Google Sheets cho test management**

Nội dung:
- **Spreadsheet setup (5 steps)**
  - Create new spreadsheet
  - Share with team
  - Setup 4 sheets
  - Import CSV files
  - Configure validation

- **Sheet 1: Test Case Management**
  - Column structure (A-K)
  - Data types & validation
  - Conditional formatting (Green/Red)
  - Formulas (COUNTA, COUNTIF)
  - Auto-summary

- **Sheet 2: Bug Report**
  - Column structure (A-K)
  - Severity color coding
  - Status tracking
  - Auto Bug ID generation
  - Formulas for metrics

- **Sheet 3: Progress Tracking**
  - Daily update format
  - Trend charts
  - Pass rate %
  - Team productivity

- **Sheet 4: Summary Dashboard**
  - Key metrics display
  - Charts (Pie, Line, Bar)
  - Live statistics
  - Recommendations

- **Google Docs Integration**
  - Embed charts in reports
  - Share test plan document
  - Daily status updates

- **Mobile Optimization**
  - Freeze panes
  - Filter views
  - Quick access

- **Security & Sharing**
  - Permission levels
  - Data protection
  - Backup strategy

- **Pro Tips & Automation**

**Ai cần dùng:** QA Lead (setup), Testers (daily use)  
**Time:** 1-2 hours setup, 5 mins daily update  

---

#### [README.md](./README.md) 📚
**Overview of all test documentation**

Nội dung:
- File descriptions
- How to use each document
- Google Sheets & Docs integration guide
- Testing timeline
- Key metrics
- Pre-test checklist
- Support contacts
- References

**Ai cần dùng:** Everyone (overview document)  

---

#### [QUICK_REFERENCE.md](./QUICK_REFERENCE.md) ⚡
**Quick reference guide - Start here!**

Nội dung:
- 📁 File structure overview
- 🚀 Quick start (2 steps)
- 📋 24 test cases summary
- 🐞 10 bugs summary
- 📊 Test timeline
- 🎯 Key metrics & targets
- ✅ Daily checklist
- 🚨 Escalation path
- 📞 Team contacts
- 🔗 Links to all documents
- 📚 Training guide
- 🏆 Testing best practices

**Ai cần dùng:** Mới vào team, quick reference  
**Reading time:** 5-10 phút  

---

## 📊 CSV FILES (For Import)

### [Test_Cases.csv](./Test_Cases.csv)
```
Format: Comma-separated values
Rows: 24 test cases
Columns: 9 (TC ID, Feature, Description, Steps, Data, Expected, Actual, Pass/Fail, Notes)
Use: Import vào Google Sheets Sheet 1
```

### [Bug_Reports.csv](./Bug_Reports.csv)
```
Format: Comma-separated values
Rows: 10 sample bugs
Columns: 11 (Bug ID, TC ID, Title, Description, Steps, Severity, Status, Assigned, Date, Fix Date, Notes)
Use: Import vào Google Sheets Sheet 2
```

---

## 🗂️ DOCUMENT MAP

```
📚 TEST_DOCUMENTATION/
│
├── 🎯 START HERE
│   ├── QUICK_REFERENCE.md        ← Read first!
│   └── README.md                 ← Overview
│
├── 📋 PLANNING
│   └── Test_Plan.md              ← Complete test plan
│
├── ✅ TEST CASES
│   ├── Test_Case_Template.md     ← 24 test cases
│   └── Test_Cases.csv            ← Import to Sheets
│
├── 🐞 BUG TRACKING
│   ├── Bug_Report_Template.md    ← How to report bugs
│   └── Bug_Reports.csv           ← Import to Sheets
│
├── 📊 TRACKING
│   └── Test_Progress_Tracking.md ← Daily progress
│
├── 📘 GUIDES
│   ├── Functional_Documentation.md ← System features
│   └── Google_Sheets_Setup_Guide.md ← Setup sheets
│
└── 🔗 This file (INDEX)
    └── Navigation & file descriptions
```

---

## 🎓 READING ORDER

**For QA Testers (New to project):**
1. ✅ [QUICK_REFERENCE.md](./QUICK_REFERENCE.md) - 5 min
2. ✅ [Functional_Documentation.md](./Functional_Documentation.md) - 30 min
3. ✅ [Test_Case_Template.md](./Test_Case_Template.md) - 20 min
4. ✅ [Bug_Report_Template.md](./Bug_Report_Template.md) - 10 min
5. ✅ [Google_Sheets_Setup_Guide.md](./Google_Sheets_Setup_Guide.md) - 15 min
6. **Start Testing!** 🚀

**Total onboarding time:** ~1.5 hours

---

**For QA Lead:**
1. ✅ [Test_Plan.md](./Test_Plan.md) - 30 min
2. ✅ [Google_Sheets_Setup_Guide.md](./Google_Sheets_Setup_Guide.md) - 1 hour
3. ✅ All other documents - 1 hour
4. **Setup & start testing** 🚀

**Total:** ~2.5 hours

---

**For Dev Team (reference):**
- [Functional_Documentation.md](./Functional_Documentation.md) - Understand features
- [Bug_Report_Template.md](./Bug_Report_Template.md) - Understanding bugs reported
- [Test_Progress_Tracking.md](./Test_Progress_Tracking.md) - Monitor progress

---

## 🎯 HOW TO USE

### **Scenario 1: Execute a Test Case**
```
1. Open Test_Case_Template.md
2. Find TC ID you assigned
3. Read description & steps carefully
4. Prepare test data from "Dữ liệu đầu vào" column
5. Execute steps
6. Compare your result with "Kết quả mong đợi"
7. Fill "Kết quả thực tế" in Google Sheets
8. Mark PASS or FAIL
9. If FAIL → Create Bug Report
```

### **Scenario 2: Report a Bug**
```
1. Open Bug_Report_Template.md
2. Find next Bug ID (BUG011 if BUG010 is last)
3. Fill in all required fields:
   - Bug ID
   - TC ID (link to test case)
   - Tiêu đề (short title)
   - Mô tả (what went wrong)
   - Bước Tái Hiện (how to reproduce)
   - Severity (CRITICAL/HIGH/MEDIUM/LOW)
   - Người Xử Lý (assign to dev)
4. Add to Google Sheets Bug Report
5. Update status as dev works on it
6. Retest when dev marks as Fixed
```

### **Scenario 3: Daily Status Report**
```
1. Open Test_Progress_Tracking.md
2. Add today's row:
   - Ngày: Today's date
   - Tester: Your name
   - TC Completed: How many you tested
   - Pass: How many passed
   - Fail: How many failed
   - Bugs: How many found
3. Update Google Sheets progress sheet
4. Alert QA Lead to any HIGH/CRITICAL bugs
5. End of day: send summary email
```

### **Scenario 4: Track Overall Progress**
```
1. Open Google Sheets Dashboard (Sheet 4)
2. Check:
   - Pass Rate % (target ≥ 90%)
   - Open Bugs (target = 0)
   - HIGH Severity bugs (should close ASAP)
   - Test coverage (should be 100%)
3. Make decisions:
   - Ready for UAT?
   - Need more testing?
   - Major blockers?
```

---

## 📞 KEY CONTACTS

| Role | Email | Phone | Slack |
|------|-------|-------|-------|
| QA Lead | qa.lead@sims.com | +84 XXX | @qa-lead |
| QA Tester 1 | qa1@sims.com | +84 XXX | @qa-1 |
| QA Tester 2 | qa2@sims.com | +84 XXX | @qa-2 |
| Dev Lead | dev.lead@sims.com | +84 XXX | @dev-lead |
| PM | pm@sims.com | +84 XXX | @pm |

---

## ✅ DOCUMENT CHECKLIST

- ✅ Test_Plan.md - Complete test strategy
- ✅ Test_Case_Template.md - 24 test cases
- ✅ Bug_Report_Template.md - Bug reporting guide
- ✅ Test_Progress_Tracking.md - Daily tracking
- ✅ Functional_Documentation.md - Feature guide
- ✅ Google_Sheets_Setup_Guide.md - Setup guide
- ✅ Test_Cases.csv - Importable test cases
- ✅ Bug_Reports.csv - Importable bugs
- ✅ README.md - Overview document
- ✅ QUICK_REFERENCE.md - Quick start guide
- ✅ INDEX.md (this file) - Navigation guide

---

## 🚀 NEXT STEPS

1. **Share this folder** with your QA Team
2. **Setup Google Sheets** using the setup guide
3. **Import CSV files** into Sheets
4. **Hold team kickoff** to review test plan
5. **Start testing!** 🎯

---

## 📈 SUCCESS METRICS

Track these during testing:
```
✅ Pass Rate Target: ≥ 90%
✅ Critical Bugs: 0
✅ High Bugs: Fixed within 1 day
✅ Test Coverage: 100% (all 24 TCs)
✅ Documentation: Complete & updated
```

---

## 📝 VERSION HISTORY

| Version | Date | Changes | Author |
|---------|------|---------|--------|
| 1.0 | 28/01/2026 | Initial release | QA Team |
| 1.1 | TBD | Updates after first test run | QA Lead |
| 2.0 | TBD | Post-release updates | QA Lead |

---

## 🎓 RESOURCES

- [Google Sheets Help](https://support.google.com/docs/answer/183965)
- [Google Docs Help](https://support.google.com/docs)
- [ASP.NET Core Docs](https://docs.microsoft.com/en-us/aspnet/core/)
- [Testing Best Practices](https://en.wikipedia.org/wiki/Software_testing)

---

**Questions?** Check [README.md](./README.md) or contact your QA Lead.

**Ready to test?** Start with [QUICK_REFERENCE.md](./QUICK_REFERENCE.md)

---

*Last Updated: 28/01/2026*  
*Document Version: 1.0*  
*Status: ✅ Ready for Testing*
