using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebsiteScreenshot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the path to the ChromeDriver executable
            string chromeDriverPath = @"C:\Downloads\chromedriver-win64\chromedriver-win64";

            // Create a new instance of the ChromeDriver
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Run Chrome in headless mode (without opening browser window)
            IWebDriver driver = new ChromeDriver(chromeDriverPath, options);

            try
            {
                driver.Navigate().GoToUrl("https://www.example.com");

                driver.Manage().Window.Size = new Size(1920, 1080);

                // Wait for the cookie consent banner to be visible
                // Wait for the cookie consent banner to be visible (max 10 seconds)
                IWebElement cookieBanner = null;
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        cookieBanner = driver.FindElement(By.XPath("//*[@id=\"gdprbanner\"]"));
                        if (cookieBanner.Displayed)
                            break;
                    }
                    catch (NoSuchElementException)
                    {
                        // Cookie banner not found yet, wait for a short duration
                        System.Threading.Thread.Sleep(1000); // Wait for 1 second
                    }
                }

                // If the cookie banner is found, hide it using JavaScript
                if (cookieBanner != null && cookieBanner.Displayed)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.display = 'none';", cookieBanner);
                }

                // Hide the cookie consent banner using JavaScript
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.display = 'none';", cookieBanner);

                long totalHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight");

                int initialHeight = 0;

                Bitmap fullPageBitmap = new Bitmap(1920, (int)totalHeight);
                

                // Loop through the webpage and take screenshots while scrolling
                while (initialHeight < totalHeight)
                {
                    // Take a screenshot of the current view
                    Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                    // Convert the screenshot to a Bitmap
                    Bitmap screenshotBitmap = new Bitmap(new System.IO.MemoryStream(screenshot.AsByteArray));

                    // Paste the current screenshot into the full-page Bitmap
                    using (Graphics graphics = Graphics.FromImage(fullPageBitmap))
                    {
                        graphics.DrawImage(screenshotBitmap, new Point(0, initialHeight));
                    }

                    // Scroll down by window height
                    initialHeight += 1080; // Adjust height as needed
                    if (initialHeight > totalHeight)
                        initialHeight = (int)totalHeight;

                    // Scroll the webpage
                    ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollTo(0, {initialHeight})");

                    // Wait for a short time to allow page to settle
                    System.Threading.Thread.Sleep(1000); // Adjust delay as needed
                }

                // Save the full-page screenshot to a file
                string screenshotFilePath = @"C:\images\Screenshot.png";
                fullPageBitmap.Save(screenshotFilePath);

                Console.WriteLine("Full-page screenshot saved successfully at: " + screenshotFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            finally
            {
                // Quit the WebDriver
                driver.Quit();
            }
        }
    }
}
