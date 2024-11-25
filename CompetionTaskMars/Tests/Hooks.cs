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
using System.Runtime.InteropServices;

namespace CompetionTaskMars.Tests
{
    [TestFixture]
    public class Hooks : Driver
    {
        public static ExtentReports extent;
        protected ExtentTest test;

        private SignIn signInObj;
        private EducationSteps educationStepsObj;
        private CertificationSteps certificationStepsObj;


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

            // Initialize WebDriver
            driver = InitializeDriver("chrome");

            // Perform SignIn
            signInObj = new SignIn(driver);
            var credentialsList = Utilities.JsonReader.GetSignInCredentialsList("C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\LoginCredentials.json");
            var credentials = credentialsList.First();
            signInObj.LoginActions(credentials.Email, credentials.Password);

            test = extent.CreateTest("Login Setup");
            test.Info("Login successful");

            // Initialize Steps for Education and Certification
            educationStepsObj = new EducationSteps(driver);
            certificationStepsObj = new CertificationSteps(driver);

            // Perform Cleanup Before Starting
            PerformFeatureCleanup();

        }
        private void PerformFeatureCleanup()
        {
            // Cleanup for Education
            educationStepsObj.Cleanup();

            // Cleanup for Certification
            certificationStepsObj.CleanupExistingCertification();

        }

        [SetUp]
        public void SetUp()
        {
            // Initialize ExtentTest for the current test
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

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

           
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            // Perform Cleanup Before Closing
            PerformFeatureCleanup();

            // Quit WebDriver
            QuitDriver();

            // Flush Extent Report
            extent.Flush();
        }
    }
}
