import { test, expect } from '@playwright/test';
import { LoginPage } from '../../pages/login-page';
import testConfig from '../../data/test-config.json';

/**
 * Authentication Test Suite
 *
 * Tests for login functionality including:
 * - Valid credentials for each role
 * - Empty field validation
 * - Invalid credentials
 * - Remember me functionality
 * - Demo account buttons
 * - Return URL handling
 */

test.describe('Authentication - Login', () => {
  let loginPage: LoginPage;

  test.beforeEach(async ({ page }) => {
    loginPage = new LoginPage(page);
    await loginPage.goto();
  });

  test('AUTH-001: Login with valid credentials - Student', async ({ page }) => {
    // Arrange
    const { username, password, expectedRedirect } = testConfig.users.student;

    // Act
    await loginPage.login(username, password);

    // Assert
    await loginPage.assertLoginSuccess(expectedRedirect);
  });

  test('AUTH-002: Login with valid credentials - Teacher', async ({ page }) => {
    // Arrange
    const { username, password, expectedRedirect } = testConfig.users.teacher;

    // Act
    await loginPage.login(username, password);

    // Assert
    await loginPage.assertLoginSuccess(expectedRedirect);
  });

  test('AUTH-003: Login with valid credentials - Admin', async ({ page }) => {
    // Arrange
    const { username, password, expectedRedirect } = testConfig.users.admin;

    // Act
    await loginPage.login(username, password);

    // Assert
    await loginPage.assertLoginSuccess(expectedRedirect);
  });

  test('AUTH-004: Login with empty username', async ({ page }) => {
    // Act
    await loginPage.login('', '123456');

    // Assert
    await loginPage.assertLoginFailed();
    await loginPage.assertUsernameRequired();
  });

  test('AUTH-005: Login with empty password', async ({ page }) => {
    // Act
    await loginPage.login('student', '');

    // Assert
    await loginPage.assertLoginFailed();
    await loginPage.assertPasswordRequired();
  });

  test('AUTH-006: Login with invalid credentials', async ({ page }) => {
    // Act
    await loginPage.login('invaliduser', 'wrongpassword');

    // Assert
    await loginPage.assertLoginFailed();
    const errorMessage = await loginPage.getErrorMessage();
    expect(errorMessage).toBeTruthy();
  });

  test('AUTH-007: Remember Me functionality', async ({ page }) => {
    // Arrange
    const { username, password } = testConfig.users.student;

    // Act
    await loginPage.login(username, password, true);

    // Assert - Check if persistent cookie is set
    const cookies = await page.context().cookies();
    const authCookie = cookies.find(c => c.name.includes('AUTH'));
    expect(authCookie).toBeDefined();
    // In real scenario, check expiration time
  });

  test('AUTH-012: Demo account auto-fill - Student', async ({ page }) => {
    // Act
    await loginPage.loginWithDemo('student');

    // Assert
    await loginPage.assertLoginSuccess(testConfig.users.student.expectedRedirect);
  });

  test('AUTH-013: Password toggle visibility', async ({ page }) => {
    // Arrange
    await loginPage.usernameInput.fill('student');
    await loginPage.passwordInput.fill('123456');

    // Act - Toggle to show
    await loginPage.togglePassword();
    const passwordFieldType1 = await loginPage.passwordInput.getAttribute('type');

    // Act - Toggle to hide
    await loginPage.togglePassword();
    const passwordFieldType2 = await loginPage.passwordInput.getAttribute('type');

    // Assert
    expect(passwordFieldType1).toBe('text');
    expect(passwordFieldType2).toBe('password');
  });
});

test.describe('Authentication - Return URL', () => {
  test('AUTH-009: Return URL after login - Valid URL', async ({ page }) => {
    // Arrange
    const { username, password } = testConfig.users.student;
    const returnUrl = '/lms/dashboard';

    // Act - Navigate to protected page (should redirect to login with returnUrl)
    await page.goto(returnUrl);
    await page.waitForURL(/\/login\?returnUrl/);

    // Login
    const loginPage = new LoginPage(page);
    await loginPage.login(username, password);

    // Assert
    await expect(page).toHaveURL(new RegExp(returnUrl));
  });

  test('AUTH-010: Return URL validation - Block physical paths', async ({ page }) => {
    // Arrange
    const { username, password } = testConfig.users.admin;
    const returnUrl = '/Pages/Cms/Dashboard.aspx';

    // Act
    await page.goto(`/login?returnUrl=${encodeURIComponent(returnUrl)}`);
    const loginPage = new LoginPage(page);
    await loginPage.login(username, password);

    // Assert - Should redirect to default dashboard, not the physical path
    await expect(page).toHaveURL(/\/cms\/dashboard/);
  });

  test('AUTH-011: Return URL validation - Student cannot access CMS', async ({ page }) => {
    // Arrange
    const { username, password } = testConfig.users.student;
    const returnUrl = '/cms/dashboard';

    // Act
    await page.goto(`/login?returnUrl=${encodeURIComponent(returnUrl)}`);
    const loginPage = new LoginPage(page);
    await loginPage.login(username, password);

    // Assert - Should redirect to LMS dashboard, not CMS
    await expect(page).toHaveURL(/\/lms\/dashboard/);
  });
});
