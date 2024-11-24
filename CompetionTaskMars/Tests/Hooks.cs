using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompetionTaskMars.Helpers;
using CompetionTaskMars.Pages;
using CompetionTaskMars.Steps;
using CompetionTaskMars.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace CompetionTaskMars.Tests
{
    [TestFixture]
    public class Hooks : Driver
    {
        public static ExtentReports extent;
        protected ExtentTest test;

        private SignIn signInObj;

        [OneTimeSetUp]
        public void SetupReport()
        {
            // Initialize Extent Report
            var reportPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\Reports\\ExtentReport.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            htmlReporter.Config.DocumentTitle = "Mars Competition Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            extent.AddSystemInfo("Tester", "Kalpana Dissanayake");
        }

        [SetUp]
        public void SetUp()
        {
            // Initialize WebDriver and ExtentTest for current test
            driver = InitializeDriver("chrome");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            // Initialize SignIn and perform Login
            var signInObj = new SignIn(driver);

            var credentialsList = Utilities.JsonReader.GetSignInCredentialsList("C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\LoginCredentials.json");
            var credentials = credentialsList.First();

            signInObj.LoginActions(credentials.Email, credentials.Password);

            test.Info("Login successful");

        }

        [TearDown]
        public void TearDown()
        {
            // Capture screenshot on failure
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == TestStatus.Failed)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    var screenshotDirectory = "Screenshots";

                    if (!Directory.Exists(screenshotDirectory))
                    {
                        Directory.CreateDirectory(screenshotDirectory);
                    }

                    var screenshotPath = $"{screenshotDirectory}/{TestContext.CurrentContext.Test.Name}.png";
                    screenshot.SaveAsFile(screenshotPath);

                    test.Fail("Test failed.")
                        .AddScreenCaptureFromPath(screenshotPath);
                }
                catch (Exception ex)
                {
                    test.Fail("Failed to capture screenshot: " + ex.Message);
                }
            }
            else
            {
                test.Pass("Test passed successfully.");
            }

            // Quit WebDriver
            QuitDriver();
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }
    }
}
