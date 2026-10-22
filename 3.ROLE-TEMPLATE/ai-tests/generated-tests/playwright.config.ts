import { defineConfig, devices } from '@playwright/test';

/**
 * Playwright Configuration for LMS Web Forms Testing
 *
 * Configuration handles:
 * - ASP.NET Web Forms specific challenges (dynamic ClientIDs)
 * - PostBack and UpdatePanel handling
 * - Session management
 * - Test data isolation
 * - Screenshot and trace capture on failure
 */
export default defineConfig({
  testDir: './tests',
  fullyParallel: false, // Web Forms tests may have session dependencies
  forbidOnly: !!process.env.CI,
  retries: process.env.CI ? 2 : 1,
  workers: process.env.CI ? 2 : 1, // Limit workers for Web Forms session stability
  reporter: [
    ['html', {
      outputFolder: '../reports/html-report',
      open: 'never'
    }],
    ['json', { outputFile: '../reports/test-results.json' }],
    ['junit', { outputFile: '../reports/junit-results.xml' }]
  ],
  timeout: 60000, // 60s timeout for Web Forms PostBack
  expect: {
    timeout: 10000
  },
  use: {
    baseURL: process.env.BASE_URL || 'http://localhost:8080',
    trace: 'retain-on-failure',
    screenshot: 'only-on-failure',
    video: 'retain-on-failure',
    actionTimeout: 15000,
    navigationTimeout: 30000,

    // Context options for Web Forms
    ignoreHTTPSErrors: true, // Development environment may use self-signed certs

    // Viewport for responsive testing
    viewport: { width: 1280, height: 720 },

    // Storage state for session persistence
    storageState: 'data/storage-state.json',
  },

  projects: [
    {
      name: 'chromium',
      use: { ...devices['Desktop Chrome'] },
    },
    {
      name: 'firefox',
      use: { ...devices['Desktop Firefox'] },
    },
    {
      name: 'webkit',
      use: { ...devices['Desktop Safari'] },
    },
  ],

  // Web Server for local development (optional)
  webServer: process.env.START_SERVER ? {
    command: 'node server.js',
    port: 8080,
    timeout: 120000,
    reuseExistingServer: !process.env.CI,
  } : undefined,
});
