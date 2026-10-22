# LMS Web Forms - AI Testing Project

**Project:** Learning Management System (LMS) - ASP.NET Web Forms
**Framework:** .NET Framework 4.0, SQL Server
**Testing Framework:** Playwright (TypeScript)
**Discovery Date:** 2026-10-22
**Status:** Phase 01-04 Complete, Ready for Phase 05-06

---

## Project Overview

This is an automated testing project for an ASP.NET Web Forms Learning Management System. The project uses AI-driven source discovery and business flow analysis to generate comprehensive test cases and automation scripts.

### Technology Stack
- **Application:** ASP.NET Web Forms (.NET Framework 4.0)
- **Database:** SQL Server (LMSCMS_DB)
- **Testing:** Playwright (TypeScript)
- **Reporting:** HTML, JSON, JUnit

---

## Project Structure

```
ai-tests/
├── docs/                          # Documentation
│   ├── source-inventory.md        # Phase 01: Source discovery
│   ├── business-flow-analysis.md  # Phase 02: Business flow analysis
│   └── test-execution-plan.md     # Phase 04: Execution guide
├── generated-tests/               # Automation code
│   ├── tests/                     # Test files
│   │   └── auth/
│   │       └── login.spec.ts      # Authentication tests
│   ├── pages/                     # Page objects
│   │   ├── base-page.ts           # Base page with Web Forms helpers
│   │   └── login-page.ts          # Login page object
│   ├── fixtures/                  # Test fixtures
│   │   └── auth.fixture.ts        # Authentication fixtures
│   ├── data/                      # Test data
│   │   └── test-config.json       # Test configuration
│   ├── playwright.config.ts       # Playwright configuration
│   └── package.json               # Dependencies
└── generated-tests/
    └── test-cases.json            # Phase 03: Test case definitions
```

---

## Phases Completed

### Phase 01: Source Discovery ✅
**File:** `docs/source-inventory.md`

**Completed Tasks:**
- Scanned 73 source files (33 ASPX, 31 ASCX, 2 Master, 7 Infrastructure)
- Analyzed Web.config configuration
- Identified authentication mechanism (Forms Authentication)
- Identified demo test accounts
- Analyzed session management
- Identified URL routing (UrlRewritingNet)
- Documented security headers and vulnerabilities

**Key Findings:**
- ClientIDMode="AutoID" → Dynamic IDs require pattern-based selectors
- UpdatePanel used for partial PostBack
- Three roles: Student, Teacher, Admin
- Demo accounts visible in UI: student/123456, teacher/123456, admin/123456

---

### Phase 02: Business Flow Analysis ✅
**File:** `docs/business-flow-analysis.md`

**Completed Tasks:**
- Analyzed Authentication flow (Login, Logout, Return URL)
- Analyzed CMS Dashboard flow
- Analyzed CMS Course Management flow (List, Filter, Settings, Create)
- Analyzed CMS User Management flow (CRUD, Search, Filter)
- Analyzed LMS Dashboard flow
- Documented authorization matrix
- Identified PostBack patterns
- Identified validation patterns

**Key Findings:**
- Login redirects based on role (Student → LMS, Admin/Teacher → CMS)
- Course management uses GridView with pagination (20/page)
- Course settings modal uses UpdatePanel (partial PostBack)
- User management restricted to admins only
- Session key: "LMS.CURRENT_USER"

---

### Phase 03: Test Case Generation ✅
**File:** `generated-tests/test-cases.json`

**Completed Tasks:**
- Generated 67 test cases across 9 modules
- Categorized by priority (Critical, High, Medium, Low)
- Categorized by type (Functional, Validation, CRUD, Authorization, etc.)
- Linked test cases to source files
- Defined test data for each case

**Test Case Distribution:**
- Authentication: 13 cases
- CMS Dashboard: 6 cases
- CMS Course Management: 16 cases
- CMS User Management: 15 cases
- LMS Dashboard: 7 cases
- Authorization: 8 cases
- Error Handling: 3 cases
- PostBack: 3 cases
- Session: 4 cases

**Priority Distribution:**
- Critical: 16 cases
- High: 34 cases
- Medium: 15 cases
- Low: 2 cases

---

### Phase 04: Automation Test Generation ✅
**Files:**
- `generated-tests/package.json`
- `generated-tests/playwright.config.ts`
- `generated-tests/pages/base-page.ts`
- `generated-tests/pages/login-page.ts`
- `generated-tests/fixtures/auth.fixture.ts`
- `generated-tests/tests/auth/login.spec.ts`
- `generated-tests/data/test-config.json`
- `docs/test-execution-plan.md`

**Completed Tasks:**
- Set up Playwright project with TypeScript
- Configured for Web Forms specific challenges (dynamic ClientIDs, PostBack)
- Created BasePage with helper methods for Web Forms
- Created LoginPage object with demo account support
- Created Auth fixture for authenticated contexts
- Implemented 10 automated tests for Authentication module
- Created test configuration file
- Created execution plan document

**Web Forms Specific Solutions:**
- `findByName(pattern)` - Bypass dynamic ClientID using name attributes
- `waitForPostBack()` - Handle full page PostBack
- `waitForUpdatePanel()` - Handle partial AJAX PostBack
- Auth fixtures with isolated browser contexts
- Session management support

---

## Remaining Phases

### Phase 05: Database Verification (Pending)
**Tasks:**
- Verify demo accounts exist in SYS_Users table
- Verify course data exists
- Verify user roles are correct
- Create test database if needed
- Set up test data cleanup procedures

**Prerequisites:**
- SQL Server access
- Read-only test account

---

### Phase 06: Test Execution (Pending)
**Tasks:**
- Deploy application to test environment
- Configure baseUrl in test-config.json
- Run smoke tests
- Execute full test suite
- Generate reports
- Analyze results

**Prerequisites:**
- Application deployed and accessible
- Database verified

---

### Phase 07: Report Generation (Pending)
**Tasks:**
- Generate HTML report
- Aggregate screenshots and traces
- Analyze failed tests
- Document root causes
- Create remediation plan

---

### Phase 08: Regression Testing (Pending)
**Tasks:**
- Monitor source code changes
- Map changes to affected modules
- Select relevant test cases
- Run regression suite
- Report new issues

---

## Quick Start

### 1. Install Dependencies
```bash
cd G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\3.ROLE-TEMPLATE\ai-tests\generated-tests
npm install
npx playwright install
```

### 2. Configure Test Environment
Edit `data/test-config.json`:
```json
{
  "baseUrl": "http://your-server:port"
}
```

### 3. Run Tests
```bash
# Run all tests
npm test

# Run with UI (debug mode)
npm run test:debug

# Run specific test
npx playwright test tests/auth/login.spec.ts
```

### 4. View Report
```bash
npm run test:report
```

---

## Key Challenges & Solutions

### Challenge 1: Dynamic ClientIDs
**Problem:** ASP.NET Web Forms with `clientIDMode="AutoID"` generates dynamic IDs like `ctl00$MainContent$UsernameText`

**Solution:** Use name attribute pattern matching instead of ID selectors
```typescript
this.usernameInput = this.findTextBox('Username');
```

### Challenge 2: PostBack Mechanism
**Problem:** Web Forms uses PostBack instead of AJAX, causing full page reloads

**Solution:** Implement `waitForPostBack()` that waits for network idle
```typescript
async waitForPostBack(): Promise<void> {
  await this.page.waitForLoadState('networkidle', { timeout: 30000 });
}
```

### Challenge 3: UpdatePanel Partial PostBack
**Problem:** Some operations use UpdatePanel for partial updates

**Solution:** Implement `waitForUpdatePanel()` that waits for AJAX response
```typescript
async waitForUpdatePanel(updatePanelId?: string): Promise<void> {
  await this.page.waitForResponse(response => {
    return response.url().includes('.aspx');
  });
}
```

### Challenge 4: Session State
**Problem:** Tests may interfere with each other's session state

**Solution:** Use isolated browser contexts per test
```typescript
studentPage: async ({ browser }, use) => {
  const context = await browser.newContext();
  const page = await context.newPage();
  // ...
  await use(page);
  await context.close();
}
```

---

## Test Coverage

### Currently Automated: 10/67 (15%)
- Authentication: 10/13 (77%)
- CMS Dashboard: 0/6 (0%)
- CMS Courses: 0/16 (0%)
- CMS User Management: 0/15 (0%)
- LMS Dashboard: 0/7 (0%)
- Authorization: 0/8 (0%)
- Error Handling: 0/3 (0%)
- PostBack: 0/3 (0%)
- Session: 0/4 (0%)

### Plan: Automate remaining 57 test cases in Phase 06

---

## Security Notes

### Known Vulnerabilities (from source analysis)
1. **SSL Not Required:** `requireSSL="false"` in httpCookies
2. **Debug Mode:** `debug="true"` in compilation
3. **SQL Credentials:** Plain text in Web.config
4. **Request Validation Mode="2.0":** Allows some HTML content

### Recommendations
1. Enable SSL in production
2. Set debug="false" in production
3. Encrypt Web.config connection strings
4. Review request validation mode
5. Implement CSRF tokens (if not present)

---

## Documentation

### Source Code Analysis
- **Source Inventory:** `docs/source-inventory.md` - Complete file listing and analysis
- **Business Flow Analysis:** `docs/business-flow-analysis.md` - Detailed flow documentation

### Test Documentation
- **Test Cases:** `generated-tests/test-cases.json` - All 67 test cases
- **Execution Plan:** `docs/test-execution-plan.md` - How to run tests

### Configuration
- **Test Config:** `generated-tests/data/test-config.json` - Test data and endpoints
- **Playwright Config:** `generated-tests/playwright.config.ts` - Test runner configuration

---

## Team & Contact

### Project Roles
- **Development Team:** Maintains LMS application
- **QA Team:** Executes tests and analyzes results
- **AI Agent:** Generates test cases and automation code

### Support
- For application issues: Contact Development Team
- For test execution issues: Refer to `docs/test-execution-plan.md`
- For configuration issues: Check `generated-tests/data/test-config.json`

---

## Version History

| Version | Date | Changes |
|---------|------|---------|
| 1.0 | 2026-10-22 | Initial AI-driven test generation project |

---

## License

This test automation project is part of the LMS application and follows the same licensing terms.

---

**End of README**
**Status:** Ready for Phase 05 (Database Verification) & Phase 06 (Execution)
