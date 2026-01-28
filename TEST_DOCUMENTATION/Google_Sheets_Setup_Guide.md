# GOOGLE SHEETS SETUP GUIDE

## Cách tạo "Bảng quản lý test" trên Google Sheets

### **BƯỚC 1: Tạo Spreadsheet Mới**

```
1. Mở https://sheets.google.com
2. Click "Create" → "Spreadsheet"
3. Đặt tên: "SIMS Testing v1.0 - Jan 2026"
4. Share với team (click Share → Add emails)
   - @qateam.com
   - @devteam.com
   - @pm.com
```

---

## 📋 SHEET 1: TEST CASE MANAGEMENT

### **Cấu trúc bảng:**

```
┌─────┬─────────────┬──────────────┬──────────────┬────────┬────────┬────────┬─────────────┬─────────┐
│ TC  │ Chức năng   │ Mô tả Test   │ Bước thực    │ Dữ liệu│ KQ Mong│ KQ Thực│ Pass/Fail   │ Ghi chú │
│ ID  │             │              │ hiện         │ Input  │ Đợi    │ Tế     │             │         │
├─────┼─────────────┼──────────────┼──────────────┼────────┼────────┼────────┼─────────────┼─────────┤
│TC01 │ Đăng ký     │ Register...  │ 1. Access... │ User.. │ Success│ ------│ [ ] PASS    │ ------- │
│     │             │              │ 2. Input...  │        │        │        │ [ ] FAIL    │         │
│TC02 │ Đăng ký     │ Register..   │ 1. Access... │ User.. │ Error  │ ------│ [ ] PASS    │ ------- │
│     │             │              │              │        │        │        │ [ ] FAIL    │         │
│TC03 │ Đăng nhập   │ Login...     │ 1. Access... │ User.. │ Success│ ------│ [ ] PASS    │ ------- │
│     │             │              │ 2. Input...  │        │        │        │ [ ] FAIL    │         │
│...  │ ...         │ ...          │ ...          │ ...    │ ...    │ ...    │ ...         │ ...     │
└─────┴─────────────┴──────────────┴──────────────┴────────┴────────┴────────┴─────────────┴─────────┘
```

### **Column Setup:**

| Col | Header | Type | Format | Validation |
|-----|--------|------|--------|------------|
| A | TC ID | Text | TC001, TC002... | Unique |
| B | Chức năng | Text | Dropdown | Pre-defined options |
| C | Mô tả Test | Text | Long text | - |
| D | Bước thực hiện | Text | Long text | - |
| E | Dữ liệu Input | Text | Long text | - |
| F | Kết quả Mong Đợi | Text | Long text | - |
| G | Kết quả Thực Tế | Text | Long text | Fill sau test |
| H | **Pass/Fail** | **Checkbox** | ✅/❌ | **Dropdown: PASS, FAIL** |
| I | Tester | Text | Dropdown | Team member names |
| J | Ngày Test | Date | YYYY-MM-DD | Auto today |
| K | Ghi chú | Text | Long text | - |

### **Conditional Formatting:**

```
Cột H (Pass/Fail):
- PASS  → Green background
- FAIL  → Red background
- (Trống) → Gray background
```

### **Formulas:**

```
Row 26 (Summary):
=COUNTA(A2:A25)              → Total TC
=COUNTIF(H2:H25,"PASS")      → Total Pass
=COUNTIF(H2:H25,"FAIL")      → Total Fail
=COUNTIF(H2:H25,"PASS")/COUNTA(H2:H25)*100  → Pass Rate %
```

### **Validation:**

```
Column B (Chức năng) - Data Validation:
List of items:
- Đăng ký
- Đăng nhập
- Quản lý Khóa học
- Quản lý Sinh viên
- Ghi danh
- Student Dashboard
- Phân quyền
- Error Handling

Column H (Pass/Fail) - Data Validation:
List of items:
- PASS
- FAIL
```

---

## 🐞 SHEET 2: BUG REPORT

### **Cấu trúc bảng:**

```
┌────────┬────────┬──────────────┬──────────────┬────────────┬───────┬─────────┬──────────┬────────────┐
│ Bug ID │ TC ID  │ Tiêu đề Bug  │ Mô tả Lỗi    │ Bước Tái   │ Mức độ│ Trạng   │ Người xử │ Ghi chú    │
│        │        │              │              │ Hiện       │ Nghiêm│ thái    │ lý      │            │
├────────┼────────┼──────────────┼──────────────┼────────────┼───────┼─────────┼──────────┼────────────┤
│BUG001  │TC002   │ Username...  │ Khi nhập...  │ 1. Regist..│ HIGH  │ Open    │ Dev_01   │ Need fix   │
│BUG002  │TC003   │ Email...     │ Email không..│ 1. Regist..│ MEDIUM│ Open    │ Dev_02   │ Medium pri │
│BUG003  │TC008   │ Error msg... │ Thông báo... │ 1. Login.. │ LOW   │ Closed  │ Dev_01   │ Fixed ✓    │
│...     │...     │ ...          │ ...          │ ...        │ ...   │ ...     │ ...      │ ...        │
└────────┴────────┴──────────────┴──────────────┴────────────┴───────┴─────────┴──────────┴────────────┘
```

### **Column Setup:**

| Col | Header | Type | Validation |
|-----|--------|------|------------|
| A | Bug ID | Text | BUG001, BUG002... |
| B | TC ID | Text | Link to Sheet1 |
| C | Tiêu đề | Text | Bug title |
| D | Mô tả Lỗi | Text | Long description |
| E | Bước Tái Hiện | Text | Steps to reproduce |
| F | Mức độ Nghiêm Trọng | Dropdown | **CRITICAL, HIGH, MEDIUM, LOW** |
| G | Trạng thái | Dropdown | **Open, In Progress, Fixed, Retest, Closed** |
| H | Người Xử Lý | Dropdown | Dev team members |
| I | Ngày Ghi | Date | Auto today |
| J | Ngày Fix | Date | Dev fills |
| K | Ghi chú | Text | Additional notes |

### **Conditional Formatting:**

```
Column F (Mức độ):
- CRITICAL → Red background, white text
- HIGH     → Orange background
- MEDIUM   → Yellow background
- LOW      → Blue background

Column G (Trạng thái):
- Open        → Red
- In Progress → Yellow
- Fixed       → Light green
- Retest      → Blue
- Closed      → Dark green
```

### **Formulas:**

```
Summary (Row 12):
=COUNTA(A2:A11)                          → Total Bugs
=COUNTIF(G2:G11,"Open")                  → Open bugs
=COUNTIF(G2:G11,"Closed")                → Closed bugs
=COUNTIF(F2:F11,"CRITICAL")              → CRITICAL bugs
=COUNTIF(F2:F11,"HIGH")                  → HIGH bugs
=COUNTIF(G2:G11,"Closed")/COUNTA(G2:G11)*100  → Closed Rate %
```

### **Auto-numbering:**

```
Dùng formula để tự động tạo Bug ID:
Column A: ="BUG"&TEXT(ROW()-1,"000")
Kết quả: BUG001, BUG002, BUG003...
```

---

## 📊 SHEET 3: PROGRESS TRACKING

### **Cấu trúc bảng:**

```
┌──────────────┬──────────────┬───────┬──────┬──────┬────────────┬────────────┐
│ Ngày Test    │ Tester       │ TC    │ Pass │ Fail │ Bugs       │ %Pass Rate │
│              │              │Complete       │ Phát │            │
├──────────────┼──────────────┼───────┼──────┼──────┼────────────┼────────────┤
│ 27/01/2026   │ QA_Tester_01 │   4   │  2   │  2   │     2      │    50%     │
│ 28/01/2026   │ QA_Tester_02 │   5   │  3   │  2   │     2      │    60%     │
│ 29/01/2026   │ QA_Tester_03 │   4   │  2   │  2   │     2      │    50%     │
│ 30/01/2026   │ QA_Tester_01 │   4   │  2   │  2   │     2      │    50%     │
│ 31/01/2026   │ QA_Tester_02 │   3   │  2   │  1   │     0      │    67%     │
├──────────────┼──────────────┼───────┼──────┼──────┼────────────┼────────────┤
│ CUMULATIVE   │ ALL          │  20   │  11  │  9   │     8      │    55%     │
└──────────────┴──────────────┴───────┴──────┴──────┴────────────┴────────────┘
```

### **Column Setup:**

| Col | Header | Type | Notes |
|-----|--------|------|-------|
| A | Ngày Test | Date | YYYY-MM-DD |
| B | Tester | Dropdown | Team names |
| C | TC Hoàn Thành | Number | Manual input |
| D | Pass | Number | =COUNTIF(Sheet1!H:H,"PASS") for date |
| E | Fail | Number | =COUNTIF(Sheet1!H:H,"FAIL") for date |
| F | Bugs Phát Hiện | Number | =COUNTIF(Sheet2!G:G,"Open") for date |
| G | % Pass Rate | % | =D/C*100 |
| H | Ghi chú | Text | Blockers, issues |

### **Chart (Line Chart):**

```
Data range: A2:A10, D2:D10, E2:E10
- X-axis: Ngày Test
- Y-axis: Pass/Fail count
- Trend line để thấy progress
- Title: "Test Execution Progress"
```

---

## 📈 SHEET 4: SUMMARY DASHBOARD

### **Layout:**

```
╔═════════════════════════════════════════════════════════════╗
║           🎯 SIMS TESTING - SUMMARY DASHBOARD              ║
╚═════════════════════════════════════════════════════════════╝

┌─────────────────────────┬─────────────────────────┐
│  📊 TEST STATISTICS     │  🐞 BUG STATISTICS      │
├─────────────────────────┼─────────────────────────┤
│ Total TC        : 24    │ Total Bugs      : 10    │
│ Executed        : 20    │ Open            : 8     │
│ Pass            : 11    │ Closed          : 2     │
│ Fail            :  9    │ CRITICAL        : 0     │
│ Pass Rate       : 55%   │ HIGH            : 6     │
│ Not Executed    :  4    │ MEDIUM          : 3     │
│                         │ LOW             : 1     │
└─────────────────────────┴─────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📈 CHARTS                                           │
├─────────────────────────────────────────────────────┤
│ [Pie Chart: Pass/Fail Rate]  [Line: Daily Progress]│
│ [Bar Chart: Bugs by Severity] [By Feature Status]  │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ ✅ RECOMMENDATIONS                                   │
├─────────────────────────────────────────────────────┤
│ ⚠️  Pass Rate 55% < Target 90% - Need more testing │
│ 🔴 6 HIGH bugs open - Blocking release             │
│ ✓  Database & Queries stable                       │
│ ✓  UI/UX reasonable                                │
│ 📝 Recommend: Fix HIGH bugs, Retest, Then UAT      │
└─────────────────────────────────────────────────────┘
```

### **Key Metrics (Formulas):**

```
Row 2 - Statistics:
Total TC:      =COUNTA(Sheet1!A2:A25)
Executed:      =COUNTIF(Sheet1!H2:H25,"PASS")+COUNTIF(Sheet1!H2:H25,"FAIL")
Pass:          =COUNTIF(Sheet1!H2:H25,"PASS")
Fail:          =COUNTIF(Sheet1!H2:H25,"FAIL")
Pass Rate:     =COUNTIF(Sheet1!H2:H25,"PASS")/COUNTIF(Sheet1!H2:H25,"<>","")*100
Not Executed:  =COUNTA(Sheet1!A2:A25)-Executed

Row 3 - Bug Stats:
Total Bugs:    =COUNTA(Sheet2!A2:A11)
Open:          =COUNTIF(Sheet2!G2:G11,"Open")
Closed:        =COUNTIF(Sheet2!G2:G11,"Closed")
CRITICAL:      =COUNTIF(Sheet2!F2:F11,"CRITICAL")
HIGH:          =COUNTIF(Sheet2!F2:F11,"HIGH")
MEDIUM:        =COUNTIF(Sheet2!F2:F11,"MEDIUM")
LOW:           =COUNTIF(Sheet2!F2:F11,"LOW")
```

---

## 🔧 GOOGLE DOCS SETUP

### **Document 1: TEST PLAN**

File: `Test_Plan.md` → Copy vào Google Docs

**Nội dung:**
```
1️⃣ Giới thiệu
2️⃣ Mục tiêu Test
3️⃣ Phạm vi Test
4️⃣ Chiến lược Test
5️⃣ Môi trường Test
6️⃣ Timeline
7️⃣ Công cụ & Tài liệu
8️⃣ Team & Responsibility
9️⃣ Pass/Fail Criteria
🔟 Risk & Mitigation
```

**Share settings:**
- Comment: @qateam.com
- Edit: QA Lead
- View: PM, Dev Lead

---

### **Document 2: TEST REPORT**

**Update hàng ngày:**

```
📋 SIMS Testing - Daily Report
Date: 28/01/2026

Status: 🟡 IN PROGRESS

✅ Completed Today:
   - TC001-TC009 (Registration & Login)
   - Identified 4 bugs

📊 Cumulative:
   - Total TC executed: 9
   - Pass: 5 (56%)
   - Fail: 4 (44%)

🐞 Blockers:
   - BUG001: Username validation failing
   - BUG007: Session not clearing on logout

⏭️ Next Steps:
   - Continue with Course Management
   - Dev team to review HIGH bugs
   - Escalate session issue to Dev Lead
```

---

## 📱 MOBILE/VIEW OPTIMIZATION

### **Freeze Panes:**

```
Freeze Row 1 (Headers) để dễ scroll:
View → Freeze → 1 row

Freeze Column A (TC ID) để dễ xem:
View → Freeze → 1 column
```

### **Filter Views:**

```
Sheet 1 (Test Cases):
- Filter 1: "Not Executed" → H = blank
- Filter 2: "Failed Tests" → H = FAIL
- Filter 3: "By Feature" → B = specific feature

Sheet 2 (Bugs):
- Filter 1: "Open Bugs" → G = Open
- Filter 2: "HIGH Priority" → F = HIGH
- Filter 3: "By Assignee" → H = specific dev
```

---

## 🔐 SECURITY & SHARING

```
1. Spreadsheet Sharing:
   - QA Team: Edit
   - Dev Team: Comment
   - PM: View only
   - Executives: View only

2. Data Protection:
   - Enable version history
   - Protect Sheet 1 (test cases)
   - Allow only summary edits

3. Backup:
   - Download as Excel weekly
   - Store in company drive
   - Archive after testing done
```

---

## 📲 QUICK TIPS

```
✨ Pro Tips:
1. Use keyboard shortcuts: Ctrl+Space to select column
2. Use conditional formatting để spot FAIL/CRITICAL nhanh
3. Set up email notifications cho HIGH bugs
4. Use pivot tables để analyze data
5. Export weekly reports as PDF
6. Create chart images for presentations

⚡ Automation:
- Set up script để auto-email summary mỗi cuối ngày
- Webhook to Slack khi bug status thay đổi
- Auto-backup to Drive mỗi 24 giờ
```

---

**✅ SETUP HOÀN THÀNH!**

Bây giờ team bạn có thể bắt đầu testing với:
- 📋 Test Case Sheet
- 🐞 Bug Report Sheet  
- 📊 Progress Tracking Sheet
- 📈 Summary Dashboard
- 📘 Test Plan & Report in Google Docs

**Chúc testing vui vẻ! 🚀**
