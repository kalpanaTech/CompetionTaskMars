using CompetionTaskMars.Steps;
using NUnit.Framework;
using CompetionTaskMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetionTaskMars.Model;
using AventStack.ExtentReports;

namespace CompetionTaskMars.Tests
{
    [TestFixture]
    public class EducationTests : Hooks
    {
        private EducationSteps educationStepsObj;

        [SetUp]
        public void Init()
        {
            educationStepsObj = new EducationSteps(driver);
            educationStepsObj.NavigateToEducationTab();
        }


        [Test, Order(1), Description("Testcase : Add new education")]
        public void TestAddNewEducation()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewEducationTestData.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.AddEducation(credentials);

            }

            test.Pass("Add New Education Test case passed successfully.");
        }

        [Test, Order(2), Description("Testcase : Add New Education With Characters/numbers")]
        public void TestAddNewEducationWithCharacters()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewEducationWithCharacters.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.AddEducation(credentials);

            }

            test.Pass("Add New Education With Characters Test case passed successfully.");
        }

        [Test, Order(3), Description("Testcase : Add New Education With huge payload")]
        public void TestAddNewEducationWithHugePayLoad()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewEducationWithHugePayLoad.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            var largePayloadCredentials = credentialsList.First();
            largePayloadCredentials.College = new string('A', 500); // 500 characters for College value

            educationStepsObj.AddEducation(largePayloadCredentials);

            test.Pass("Add New Education With huge payload Test case passed successfully");
        }


        [Test, Order(4), Description("Testcase : Update Education")]

        public void TestUpdateEducation()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\UpdateEducationTestData.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.UpdateEducation(credentials);

                test.Pass("Update Education Test case passed successfully.");
            }
        }

        [Test, Order(5), Description("Testcase : Add New Education With Duplicate Data")]

        public void TestAddNewEducationWithDuplicateData()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewEducationWithDuplicateValues.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.AddDuplicateEducation(credentials);

                test.Pass("Add New Education With Duplicate Data Test case passed successfully.");
            }
        }

        [Test, Order(5), Description("Testcase : Add New Education With Null Values")]

        public void TestAddNewEducationWithNullValues()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewEducationTestDataWithNullValues.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.AddNullEducation(credentials);

                test.Pass("Add New Education With Null Values Test case passed successfully.");
            }
        }

        [Test, Order(6), Description("Testcase : Cancel Add Education")]

        public void TestCancelAddEducation()
        {

            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\CancelAddEducationTestData.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.CancelAddEducation(credentials);

                test.Pass("Cancel Add Education Test case passed successfully.");
            }
        }

        [Test, Order(7), Description("Testcase : Cancel Update Education")]

        public void TestCancelUpdateEducation()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\CancelUpdateEducationTestData.json";
            List<EducationCredentials> credentialsList = JsonReader.GetCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                educationStepsObj.CancelUpdateEducation(credentials);

                test.Pass("Cancel Update Education Test case passed successfully.");
            }
        }
        [TearDown]
        public void CleanupAfterTest()
        {
            educationStepsObj.Cleanup();
        }

    }
}
