import { Page, Locator, expect } from '@playwright/test';

/**
 * Base Page Class for ASP.NET Web Forms
 *
 * Handles common Web Forms challenges:
 * - Dynamic ClientID selection
 * - PostBack waiting
 * - UpdatePanel handling
 * - ViewState considerations
 */
export class BasePage {
  readonly page: Page;

  constructor(page: Page) {
    this.page = page;
  }

  /**
   * Wait for full page PostBack to complete
   * Web Forms PostBack causes full page reload or network activity
   */
  async waitForPostBack(): Promise<void> {
    // Wait for network idle to catch PostBack completion
    await this.page.waitForLoadState('networkidle', { timeout: 30000 });
    // Additional wait for JavaScript execution
    await this.page.waitForTimeout(500);
  }

  /**
   * Wait for UpdatePanel partial PostBack
   * Used for AJAX-based updates in Web Forms
   */
  async waitForUpdatePanel(updatePanelId?: string): Promise<void> {
    // Wait for any network activity (AJAX response)
    await this.page.waitForResponse(response => {
      return response.url().includes('.aspx') || response.url().includes('ScriptResource');
    }, { timeout: 15000 }).catch(() => {
      // If no network response, just wait a bit for JS to process
    });
    // Wait for DOM update
    await this.page.waitForTimeout(500);
  }

  /**
   * Find element by name attribute with pattern matching
   * Bypasses dynamic ClientID issue by using name attribute
   */
  findByName(pattern: string): Locator {
    return this.page.locator(`[name*="${pattern}"]`).first();
  }

  /**
   * Find textbox by name pattern
   */
  findTextBox(namePattern: string): Locator {
    return this.page.locator(`input[type="text"][name*="${namePattern}"], input:not([type])[name*="${namePattern}"]`).first();
  }

  /**
   * Find password field by name pattern
   */
  findPasswordField(namePattern: string): Locator {
    return this.page.locator(`input[type="password"][name*="${namePattern}"]`).first();
  }

  /**
   * Find checkbox by name pattern
   */
  findCheckBox(namePattern: string): Locator {
    return this.page.locator(`input[type="checkbox"][name*="${namePattern}"]`).first();
  }

  /**
   * Find button by text content
   */
  findButtonByText(text: string): Locator {
    return this.page.getByRole('button', { name: text }).or(
      this.page.locator(`input[type="submit"][value="${text}"]`)
    ).or(
      this.page.locator(`button:has-text("${text}")`)
    ).first();
  }

  /**
   * Find dropdown by name pattern
   */
  findDropDown(namePattern: string): Locator {
    return this.page.locator(`select[name*="${namePattern}"]`).first();
  }

  /**
   * Find label by text content
   */
  findLabel(text: string): Locator {
    return this.page.getByText(text, { exact: false });
  }

  /**
   * Find element by CSS class
   */
  findByClass(className: string): Locator {
    return this.page.locator(`.${className}`).first();
  }

  /**
   * Find element by data attribute
   */
  findByDataAttr(attr: string, value: string): Locator {
    return this.page.locator(`[data-${attr}="${value}"]`).first();
  }

  /**
   * Wait for element to be visible
   */
  async waitForVisible(locator: Locator, timeout = 10000): Promise<void> {
    await expect(locator).toBeVisible({ timeout });
  }

  /**
   * Wait for element to be hidden
   */
  async waitForHidden(locator: Locator, timeout = 10000): Promise<void> {
    await expect(locator).toBeHidden({ timeout });
  }

  /**
   * Check if element exists
   */
  async exists(locator: Locator): Promise<boolean> {
    return await locator.count() > 0;
  }

  /**
   * Get text content of element
   */
  async getText(locator: Locator): Promise<string> {
    return await locator.textContent() || '';
  }

  /**
   * Check for error messages in ValidationSummary or error labels
   */
  async getErrorMessage(): Promise<string | null> {
    const errorSelectors = [
      '.validation-summary-errors',
      '[class*="error"]',
      '[id*="MessageText"]',
      '[id*="ErrorText"]'
    ];

    for (const selector of errorSelectors) {
      const locator = this.page.locator(selector).first();
      if (await this.exists(locator) && await locator.isVisible()) {
        return await this.getText(locator);
      }
    }
    return null;
  }

  /**
   * Take screenshot with custom name
   */
  async screenshot(name: string): Promise<void> {
    await this.page.screenshot({
      path: `../test-results/screenshots/${name}-${Date.now()}.png`,
      fullPage: true
    });
  }

  /**
   * Navigate to URL with error handling
   */
  async navigate(url: string): Promise<void> {
    try {
      await this.page.goto(url, { waitUntil: 'networkidle' });
    } catch (error) {
      console.error(`Navigation failed for ${url}:`, error);
      throw error;
    }
  }

  /**
   * Check if currently on login page
   */
  async isOnLoginPage(): Promise<boolean> {
    return await this.page.url().includes('/login') ||
           await this.exists(this.findTextBox('Username'));
  }

  /**
   * Check if currently on CMS dashboard
   */
  async isOnCmsDashboard(): Promise<boolean> {
    return await this.page.url().includes('/cms/dashboard');
  }

  /**
   * Check if currently on LMS dashboard
   */
  async isOnLmsDashboard(): Promise<boolean> {
    return await this.page.url().includes('/lms/dashboard');
  }
}
