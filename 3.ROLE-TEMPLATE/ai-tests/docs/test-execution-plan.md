# Test Execution Plan - LMS Web Forms AI Testing
## Setup & Execution Guide

**Project:** LMS (Learning Management System) - ASP.NET Web Forms
**Setup Date:** 2026-10-22
**Status:** Ready for Phase 05 (Database Verification) & Phase 06 (Execution)

---

## 1. Prerequisites

### 1.1 Environment Requirements
- **Node.js:** v18.x or higher
- **npm:** v9.x or higher
- **TypeScript:** v5.x or higher
- **Playwright:** v1.40.0 or higher

### 1.2 Application Requirements
- **IIS:** Application deployed and running
- **Database:** SQL Server with LMSCMS_DB accessible
- **Test Accounts:** 
  - student / 123456
  - teacher / 123456
  - admin / 123456

### 1.3 Network Requirements
- Base URL accessible from test machine
- Firewall allows HTTP/HTTPS traffic

---

## 2. Installation Steps

### 2.1 Install Dependencies
```bash
cd G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\3.ROLE-TEMPLATE\ai-tests\generated-tests
npm install
```

### 2.2 Install Playwright Browsers
```bash
npx playwright install
```

### 2.3 Configure Test Environment
Edit `data/test-config.json`:
```json
{
  "baseUrl": "http://your-server:port",
  "testEnvironment": "development"
}
```

---

## 3. Test Execution

### 3.1 Run All Tests
```bash
npm test
```

### 3.2 Run Specific Test File
```bash
npx playwright test tests/auth/login.spec.ts
```

### 3.3 Run with UI (Debug Mode)
```bash
npm run test:debug
```

### 3.4 Run Headed Mode
```bash
npm run test:headed
```

### 3.5 Run on Specific Browser
```bash
npx playwright test --project=chromium
npx playwright test --project=firefox
npx playwright test --project=webkit
```

---

## 4. Test Suite Structure

### 4.1 Currently Implemented Tests
| Suite | File | Test Cases | Status |
|-------|------|------------|--------|
| Authentication | tests/auth/login.spec.ts | 10 | Ready to run |
| CMS Dashboard | tests/cms/dashboard.spec.ts | 0 | Not created |
| CMS Courses | tests/cms/courses.spec.ts | 0 | Not created |
| CMS Users | tests/cms/users.spec.ts | 0 | Not created |
| LMS Dashboard | tests/lms/dashboard.spec.ts | 0 | Not created |
| Authorization | tests/authz/authorization.spec.ts | 0 | Not created |

### 4.2 Test Case Coverage
- **Total Test Cases Generated:** 67
- **Automated Tests:** 10 (15%)
- **Manual Tests:** 57 (85%)

---

## 5. Execution Order

### 5.1 Smoke Tests (Run First)
1. AUTH-001: Login as Student
2. AUTH-002: Login as Teacher
3. AUTH-003: Login as Admin
4. AUTHZ-001: Student cannot access CMS

### 5.2 Functional Tests
5. CMS-DASH-001: Load CMS Dashboard
6. CMS-CRS-001: Load Course List
7. LMS-DASH-001: Load LMS Dashboard
8. CMS-USR-001: Load User List

### 5.3 Validation Tests
9. AUTH-004: Empty username
10. AUTH-005: Empty password
11. CMS-CRS-010: Invalid passing score
12. CMS-USR-004: Missing required fields

### 5.4 CRUD Tests
13. CMS-CRS-009: Save course settings
14. CMS-CRS-014: Create course workspace
15. CMS-USR-003: Create user
16. CMS-USR-006: Edit user

### 5.5 Authorization Tests
17. AUTHZ-002: Student cannot access CMS Courses
18. AUTHZ-003: Student cannot access CMS Users
19. AUTHZ-004: Teacher can access CMS
20. AUTHZ-005: Admin can access Users
21. AUTHZ-006: Teacher cannot access Users

### 5.6 Error Handling Tests
22. ERR-001: 404 Not Found
23. ERR-002: 403 Forbidden

### 5.7 PostBack Tests
24. PB-001: Login Full PostBack
25. PB-002: Course Settings Partial PostBack

### 5.8 Session Tests
26. SESS-001: Session creation
27. SESS-002: Session clear on logout
28. SESS-003: Session persistence

---

## 6. Results & Reporting

### 6.1 HTML Report
```bash
npm run test:report
```
Report location: `ai-tests/reports/html-report/index.html`

### 6.2 JSON Report
Location: `ai-tests/reports/test-results.json`

### 6.3 JUnit Report
Location: `ai-tests/reports/junit-results.xml`

### 6.4 Screenshots
Location: `ai-tests/test-results/screenshots/`

### 6.5 Traces
Location: `ai-tests/test-results/traces/`

### 6.6 Videos
Location: `ai-tests/test-results/videos/`

---

## 7. Troubleshooting

### 7.1 Common Issues

**Issue: Dynamic ClientID selector fails**
- Solution: Use name pattern matching (already implemented in BasePage)
- Check: Ensure `findByName()` or `findTextBox()` is used

**Issue: PostBack timeout**
- Solution: Increase timeout in playwright.config.ts
- Check: Network latency, server response time

**Issue: UpdatePanel not updating**
- Solution: Use `waitForUpdatePanel()` instead of `waitForPostBack()`
- Check: ScriptManager is present on page

**Issue: Session state issues**
- Solution: Use browser context per test (already in fixtures)
- Check: Workers set to 1 in config

**Issue: Demo accounts not working**
- Solution: Verify accounts exist in database
- Check: `SYS_Users` table has demo accounts

### 7.2 Debug Mode
```bash
npm run test:debug
```
This opens Playwright Inspector for step-by-step debugging.

---

## 8. Database Verification (Phase 05)

### 8.1 Prerequisites
- SQL Server access
- Read-only test account
- Optional: Write access for isolated test data

### 8.2 Verification Steps
1. Verify demo accounts exist in `SYS_Users`
2. Verify course data exists in `Courses` / `OnlineCourses`
3. Verify user roles are correct
4. Create test database if needed

### 8.3 Test Data Cleanup
After execution:
- Delete test users created during tests
- Reset test course status
- Clean up test enrollments

---

## 9. Next Steps

### 9.1 Immediate Actions
1. **Deploy application** to test environment
2. **Configure baseUrl** in test-config.json
3. **Run smoke tests** to verify setup
4. **Implement remaining test suites**:
   - CMS Dashboard tests
   - CMS Courses tests
   - CMS Users tests
   - LMS Dashboard tests
   - Authorization tests

### 9.2 Phase 07 - Report Generation
After test execution:
1. Generate HTML report
2. Aggregate screenshots and traces
3. Analyze failed tests
4. Document root causes
5. Create remediation plan

### 9.3 Phase 08 - Regression Testing
When source changes:
1. Identify changed files via Git/SVN
2. Map changes to affected modules
3. Select relevant test cases
4. Run regression suite
5. Report new issues

---

## 10. Test Data Management

### 10.1 Test Accounts
| Role | Username | Password | Purpose |
|------|----------|----------|---------|
| Student | student | 123456 | LMS testing |
| Teacher | teacher | 123456 | CMS testing (limited) |
| Admin | admin | 123456 | Full CMS testing |

### 10.2 Test Data Isolation
- Use test-specific usernames with timestamp
- Prefix test data with "automation_"
- Clean up after each test suite

### 10.3 Rollback Strategy
- Keep list of created IDs during test
- Execute cleanup script after tests
- Use transactions where possible

---

## 11. Security Considerations

### 11.1 Test Credentials
- Never use production credentials
- Change test passwords regularly
- Store credentials in encrypted config (future)

### 11.2 Test Database
- Use separate test database if possible
- Never run destructive tests on production
- Limit test account permissions

### 11.3 Code Exposure
- Test code is in ai-tests directory (separate from source)
- No modifications to production code
- Test reports contain sensitive data (restrict access)

---

## 12. Maintenance

### 12.1 When Application Changes
1. Update source-inventory.md
2. Update business-flow-analysis.md
3. Add new test cases to test-cases.json
4. Implement new automated tests
5. Run regression suite

### 12.2 When Environment Changes
1. Update test-config.json
2. Update baseUrl
3. Update database connection string
4. Re-run smoke tests

### 12.3 When Test Data Changes
1. Update test-config.json users section
2. Update test data fixtures
3. Re-run affected tests

---

## 13. Success Criteria

### 13.1 Setup Success
- [ ] All dependencies installed
- [ ] Playwright browsers installed
- [ ] Application accessible at baseUrl
- [ ] Demo accounts verified
- [ ] Smoke tests pass

### 13.2 Execution Success
- [ ] All smoke tests pass
- [ ] 80%+ functional tests pass
- [ ] All critical tests pass
- [ ] Reports generated successfully
- [ ] No data left in inconsistent state

### 13.3 Reporting Success
- [ ] HTML report generated
- [ ] Screenshots captured for failures
- [ ] Traces available for debugging
- [ ] Test summary documented
- [ ] Issues categorized by severity

---

## 14. Contact & Support

### 14.1 Documentation
- Source Inventory: `docs/source-inventory.md`
- Business Flow Analysis: `docs/business-flow-analysis.md`
- Test Cases: `generated-tests/test-cases.json`
- This Plan: `docs/test-execution-plan.md`

### 14.2 Configuration Files
- Test Config: `data/test-config.json`
- Playwright Config: `generated-tests/playwright.config.ts`
- Package.json: `generated-tests/package.json`

---

**End of Test Execution Plan**
**Status:** Ready for execution
**Next Action:** Deploy application and run smoke tests
