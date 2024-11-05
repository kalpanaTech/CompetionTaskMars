using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompetionTaskMars.Helpers;
using CompetionTaskMars.Pages;
using CompetionTaskMars.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetionTaskMars.Tests
{
    [TestFixture]
    public class Hooks
    {
        public static ExtentReports extent;
        public ExtentTest test;
        public SignIn signInObj;

        [OneTimeSetUp]
        public void SetupReport()
        {
            var htmlReporter = new ExtentSparkReporter("C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\Reports\\ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
            extent.AddSystemInfo("UserName", "Kalpana Dissanayake");
        }

        [SetUp]
        public void SetUp()
        {
            Driver.driver = Driver.InitializeDriver("chrome");
            signInObj = new SignIn(Driver.driver); // Pass the driver to the SignIn class
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            try
            {
                var credentials = Utilities.JsonReader.GetCredentials(); // Read credentials from JSON
                signInObj.LoginActions(credentials.Email, credentials.Password);
                Assert.That(Driver.driver.Url.Contains("http://localhost:5000/Home"), "Login was not successful.");
                test.Pass("Login test passed successfully.");
            }
            catch (Exception ex)
            {
                test.Fail("Test failed: " + ex.Message); 
                throw;
            }
            
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot();

                    // Ensure the Screenshots directory is created
                    var screenshotDirectory = "Screenshots";
                    if (!Directory.Exists(screenshotDirectory))
                    {
                        Directory.CreateDirectory(screenshotDirectory);
                    }

                    var screenshotPath = $"{screenshotDirectory}/{TestContext.CurrentContext.Test.Name}.png";
                    screenshot.SaveAsFile(screenshotPath);
                    test.AddScreenCaptureFromPath(screenshotPath);
                }
                catch (Exception ex)
                {                  
                    Console.WriteLine("Failed to save screenshot: " + ex.Message);
                }
            }

            Driver.QuitDriver();
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }
    }
}
