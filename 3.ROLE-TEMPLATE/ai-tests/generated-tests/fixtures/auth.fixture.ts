import { test as base } from '@playwright/test';
import { LoginPage } from '../pages/login-page';
import testConfig from '../data/test-config.json';

/**
 * Authentication Fixture
 *
 * Provides authenticated page contexts for different roles
 * Handles session management and login state
 */
export type AuthFixtures = {
  loginPage: LoginPage;
  studentPage: any; // Authenticated page as student
  teacherPage: any; // Authenticated page as teacher
  adminPage: any; // Authenticated page as admin
};

export const test = base.extend<AuthFixtures>({
  // Shared login page
  loginPage: async ({ page }, use) => {
    const loginPage = new LoginPage(page);
    await use(loginPage);
  },

  // Authenticated student page
  studentPage: async ({ browser }, use) => {
    const context = await browser.newContext();
    const page = await context.newPage();
    const loginPage = new LoginPage(page);

    await loginPage.goto();
    await loginPage.login(
      testConfig.users.student.username,
      testConfig.users.student.password
    );

    await use(page);
    await context.close();
  },

  // Authenticated teacher page
  teacherPage: async ({ browser }, use) => {
    const context = await browser.newContext();
    const page = await context.newPage();
    const loginPage = new LoginPage(page);

    await loginPage.goto();
    await loginPage.login(
      testConfig.users.teacher.username,
      testConfig.users.teacher.password
    );

    await use(page);
    await context.close();
  },

  // Authenticated admin page
  adminPage: async ({ browser }, use) => {
    const context = await browser.newContext();
    const page = await context.newPage();
    const loginPage = new LoginPage(page);

    await loginPage.goto();
    await loginPage.login(
      testConfig.users.admin.username,
      testConfig.users.admin.password
    );

    await use(page);
    await context.close();
  },
});

export { expect } from '@playwright/test';
