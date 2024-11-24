using CompetionTaskMars.Steps;
using NUnit.Framework;
using CompetionTaskMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetionTaskMars.Model;
using CompetionTaskMars.Pages;

namespace CompetionTaskMars.Tests
{
    [TestFixture]
    public class CertificationTests : Hooks
    {
        private CertificationSteps certificationStepsObj;

        [SetUp]
        public void Init()
        {
            certificationStepsObj = new CertificationSteps(driver);
            certificationStepsObj.CleanupExistingCertification();
            certificationStepsObj.NavigateToTheCertificationTab();
        }


        [Test, Order(1), Description("Testcase : Add new certification")]
        public void TestAddNewCertification()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewCertificationTestData.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.AddCertification(credentials);

                test.Pass("Add New Certification Test case passed successfully");
            }
        }

        [Test, Order(2), Description("Testcase : Add new certification With Characters/numbers")]
        public void TestAddnewcertificationWithCharacters()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewCertificationWithCharacters.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.AddCertification(credentials);

                test.Pass(" Add new certification With Characters Test case passed successfully");
            }
        }
        [Test, Order(3), Description("Testcase : Add new certification With huge payload")]
        public void AddnewcertificationWithHugepayload()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNewCertificationWithHugePayload.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);


            var largePayloadCredentials = credentialsList.First();
            largePayloadCredentials.Certificate = new string('A', 500); // 500 characters for Certificate value

            certificationStepsObj.AddCertification(largePayloadCredentials);

            test.Pass(" Add new certification With huge payload Test case passed successfully");

        }


        [Test, Order(4), Description("Testcase : Add Duplicate certification")]
        public void TestDuplicateeCertification()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddDuplicateCertificationTestData.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.AddDuplicateCertification(credentials);

                test.Pass("Add Duplicate Certification Test case passed successfully");
            }
        }

        [Test, Order(5), Description("Testcase : Add Null certification")]
        public void TestNullCertification()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddNullCertificationTestData.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.AddNullCertification(credentials);

                test.Pass("Add Null Certification Test case passed successfully");
            }
        }

        [Test, Order(6), Description("Testcase : Cancel Add certification")]
        public void TestCancelAddCertification()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\AddCertificationCancelTestData.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.CancelAddCertification(credentials);

                test.Pass("Cancel Add Certification Test case passed successfully");
            }
        }

        [Test, Order(7), Description("Testcase :  Cancel Update Certification")]
        public void TestCancelUpdateCertification()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\CancelUpdateCertificationTestData.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.CancelUpdateCertification(credentials);

                test.Pass("Cancel Update Certification Test case passed successfully");
            }
        }

        [Test, Order(8), Description("Testcase : Update certification")]
        public void TestUpdateCertification()
        {
            string testDataPath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\UpdateCertificationTestData.json";
            List<CertificationCredentials> credentialsList = JsonReader.GetCertificationCredentialsList(testDataPath);

            foreach (var credentials in credentialsList)
            {
                certificationStepsObj.UpdateCertification(credentials);

                test.Pass("Update Certification Test case passed successfully");
            }
        }

        [TearDown]
        public void CleanupAfterCertificateTest()
        {
            certificationStepsObj.CleanupExistingCertification();
        }

    }

}
