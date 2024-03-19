# SeleniumChrome-FullPage-Screenshot-CSharp

## Description:
The SeleniumChrome-FullPage-Screenshot-CSharp is a C# application that captures full-page screenshots of web pages using Selenium WebDriver and ChromeDriver. It provides a simple yet effective way to automate the process of taking screenshots, particularly useful for testing and documentation purposes.

## Features:
- Captures full-page screenshots of web pages.
- Supports headless mode for running Chrome without opening a browser window.
- Automatically hides cookie consent banners before taking screenshots.
- Scrolls through the webpage to capture the entire content.

## Dependencies:
- Selenium WebDriver: A framework for automating web browsers.
- ChromeDriver: A standalone server that implements the WebDriver protocol for Chromium-based browsers.
- .NET Core or .NET Framework: The application is developed using C# and requires .NET runtime to execute.

## Usage:
1. Ensure that you have the necessary dependencies installed (Selenium WebDriver, ChromeDriver, .NET runtime).
2. Clone or download the WebsiteScreenshot project.
3. Open the project in your preferred IDE (e.g., Visual Studio).
4. Set the path to the ChromeDriver executable in the `chromeDriverPath` variable.
5. Customize the target URL in the `driver.Navigate().GoToUrl()` method.
6. Adjust the window size and scrolling parameters if needed.
7. Run the application.
8. The full-page screenshot will be saved to the specified file path.

## Configuration:
- `chromeDriverPath`: Path to the ChromeDriver executable on your system.
- `driver.Navigate().GoToUrl()`: URL of the webpage to capture.
- `driver.Manage().Window.Size`: Size of the browser window.
- `initialHeight`: Initial height for scrolling.
- `screenshotFilePath`: File path to save the full-page screenshot.
