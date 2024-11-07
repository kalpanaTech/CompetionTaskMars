using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompetionTaskMars.Helpers;
using CompetionTaskMars.Pages;
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
        public ExtentTest test;

        private SignIn signInObj;
        private Education educationActions;

        [OneTimeSetUp]
        public void SetupReport()
        {
            var htmlReporter = new ExtentSparkReporter("C:\\repo\\CompetionTaskMars\\Reports\\ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.Config.DocumentTitle = "Mars Competition Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
            extent.AddSystemInfo("UserName", "Kalpana Dissanayake");
        }

        [SetUp]
        public void SetUp()
        {
            // Initialize WebDriver and SignIn object
            driver = InitializeDriver("chrome");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            signInObj = new SignIn(driver);
            educationActions = new Education(driver);

            // Perform Login using credentials from JSON
            var credentials = Utilities.JsonReader.GetCredentials(); 
             signInObj.LoginActions(credentials.Email, credentials.Password);            
            
        }

        [Test]
        public void TestAddNewEducation()
        {
            var credentials = Utilities.JsonReader.GetCredentials();
            test.Info("Starting 'Add New Education' test");

            educationActions.NavigateToEducationTab();
            educationActions.AddNewEducationButtonActions();
            educationActions.AddCollegeUniversityNameActions(credentials.College);
            educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
            educationActions.AddTitleActions(credentials.Title);
            educationActions.AddDegreeActions(credentials.Degree);
            educationActions.AddYearOfGraduationActions(credentials.Year);
            educationActions.AddEducationButtonActions();
            educationActions.VerifyToastMessageActions("Add");
            educationActions.NavigateToEducationTab();

            string addedCountryOfCollege = educationActions.GetAddedCountryOnProfilePage();
            Console.WriteLine("Recorded Country: " + addedCountryOfCollege); 
            string addedCollege = educationActions.GetAddedCollegeUniversityNameOnProfilePage();
            string addedTitle = educationActions.GetAddedTitleOnProfilePage();
            string addedDegree = educationActions.GetAddedDegreeOnProfilePage();
            string addedYear = educationActions.GetAddedYearOfGraduationYearOnProfilePage();

            Assert.That(addedCountryOfCollege == credentials.Country, "Country has not been added");
            Assert.That(addedCollege == credentials.College, "College has not been added");
            Assert.That(addedTitle == credentials.Title, "Title has not been added");
            Assert.That(addedDegree == credentials.Degree, "Degree has not been added");
            Assert.That(addedYear == credentials.Year, "Grsduation Year has not been added");

            test.Pass("Add New Education Test case passed successfully.");
        }

        [TearDown]
        public void TearDown()
        {
            // Capture screenshot if the test fails
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot();

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

            QuitDriver();
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }
    }
}
