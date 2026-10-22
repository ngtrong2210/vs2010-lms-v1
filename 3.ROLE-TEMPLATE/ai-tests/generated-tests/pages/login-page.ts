import { Page, expect } from '@playwright/test';
import { BasePage } from './base-page';

/**
 * Login Page Object for LMS
 *
 * Handles login form interactions including:
 * - Username/password entry
 * - Demo account buttons
 * - Remember me checkbox
 * - Password toggle
 * - Error message handling
 */
export class LoginPage extends BasePage {
  readonly page: Page;

  // Locators using name pattern matching (dynamic ClientID-safe)
  readonly usernameInput: Locator;
  readonly passwordInput: Locator;
  readonly rememberMeCheckbox: Locator;
  readonly loginButton: Locator;
  readonly errorMessage: Locator;
  readonly demoStudentButton: Locator;
  readonly demoTeacherButton: Locator;
  readonly demoAdminButton: Locator;
  readonly passwordToggleButtons: Locator;

  constructor(page: Page) {
    super(page);
    this.page = page;

    // Use name pattern matching to handle dynamic ClientIDs
    this.usernameInput = this.findTextBox('Username');
    this.passwordInput = this.findPasswordField('Password');
    this.rememberMeCheckbox = this.findCheckBox('Remember');
    this.loginButton = this.findButtonByText('Đăng nhập');

    // Error message locators
    this.errorMessage = this.page.locator('[id*="MessageText"], .validation-summary-errors, [class*="error"]');

    // Demo account buttons (data attributes)
    this.demoStudentButton = this.findByDataAttr('demo-login', 'student');
    this.demoTeacherButton = this.findByDataAttr('demo-login', 'teacher');
    this.demoAdminButton = this.findByDataAttr('demo-login', 'admin');

    // Password toggle buttons
    this.passwordToggleButtons = this.page.locator('[data-password-toggle]');
  }

  /**
   * Navigate to login page
   */
  async goto(): Promise<void> {
    await this.navigate('/login');
    await this.waitForVisible(this.usernameInput);
  }

  /**
   * Login with username and password
   */
  async login(username: string, password: string, rememberMe = false): Promise<void> {
    await this.usernameInput.fill(username);
    await this.passwordInput.fill(password);

    if (rememberMe) {
      await this.rememberMeCheckbox.check();
    }

    await this.loginButton.click();
    await this.waitForPostBack();
  }

  /**
   * Login using demo account button
   */
  async loginWithDemo(role: 'student' | 'teacher' | 'admin'): Promise<void> {
    const buttonMap = {
      student: this.demoStudentButton,
      teacher: this.demoTeacherButton,
      admin: this.demoAdminButton
    };

    await buttonMap[role].click();
    // Wait for fields to be filled
    await this.page.waitForTimeout(500);
    await this.loginButton.click();
    await this.waitForPostBack();
  }

  /**
   * Toggle password visibility
   */
  async togglePassword(): Promise<void> {
    await this.passwordToggleButtons.first().click();
    await this.page.waitForTimeout(200);
  }

  /**
   * Get error message if present
   */
  async getErrorMessage(): Promise<string | null> {
    if (await this.exists(this.errorMessage) && await this.errorMessage.isVisible()) {
      return await this.getText(this.errorMessage);
    }
    return null;
  }

  /**
   * Assert that error message is displayed
   */
  async assertErrorMessage(expectedMessage: string): Promise<void> {
    const actualMessage = await this.getErrorMessage();
    expect(actualMessage).toContain(expectedMessage);
  }

  /**
   * Assert that login was successful by checking redirect
   */
  async assertLoginSuccess(expectedPath: string): Promise<void> {
    await expect(this.page).toHaveURL(new RegExp(expectedPath));
  }

  /**
   * Assert that login failed (stayed on login page)
   */
  async assertLoginFailed(): Promise<void> {
    await expect(this.page).toHaveURL(/\/login/);
  }

  /**
   * Assert that username field has validation error
   */
  async assertUsernameRequired(): Promise<void> {
    const validator = this.page.locator('[id*="Username"][class*="error"]');
    await expect(validator).toBeVisible();
  }

  /**
   * Assert that password field has validation error
   */
  async assertPasswordRequired(): Promise<void> {
    const validator = this.page.locator('[id*="Password"][class*="error"]');
    await expect(validator).toBeVisible();
  }
}
