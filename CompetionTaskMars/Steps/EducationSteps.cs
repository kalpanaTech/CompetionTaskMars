using CompetionTaskMars.Helpers;
using CompetionTaskMars.Model;
using CompetionTaskMars.Pages;
using CompetionTaskMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetionTaskMars.Steps
{
    public class EducationSteps : Driver
    {
        readonly Education educationActions;

        public EducationSteps(IWebDriver driver)
        {
            educationActions = new Education(driver);
        }

        //method for Cleanup
        public void Cleanup()
        {
            educationActions.Cleanup();
        }

        //method for Navigate To Education Tab
        public void NavigateToEducationTab()
        {
            educationActions.NavigateToEducationTab();
        }

        public void AddEducation(EducationCredentials credentials)
        {
            educationActions.AddNewEducationButtonActions();
            educationActions.AddCollegeUniversityNameActions(credentials.College);
            educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
            educationActions.AddTitleActions(credentials.Title);
            educationActions.AddDegreeActions(credentials.Degree);
            educationActions.AddYearOfGraduationActions(credentials.Year);
            educationActions.AddEducationButtonActions();
            educationActions.VerifyToastMessageActions("AddEducation");

            // Verification steps
            VerifyEducationOnProfile(credentials);
            VerifyEducationOnResultsPage(credentials);
        }

        public void UpdateEducation(EducationCredentials credentials)
        {


            if (credentials.Action == "Add")
            {
                educationActions.AddNewEducationButtonActions();
                educationActions.AddCollegeUniversityNameActions(credentials.College);
                educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
                educationActions.AddTitleActions(credentials.Title);
                educationActions.AddDegreeActions(credentials.Degree);
                educationActions.AddYearOfGraduationActions(credentials.Year);
                educationActions.AddEducationButtonActions();


            }
            else if (credentials.Action == "Update")
            {

                educationActions.NavigateToEducationTab();
                educationActions.UpdateCollegeUniversityNameActions(credentials.College);
                educationActions.UpdateCountyOfCollegeUniversityActions(credentials.Country);
                educationActions.UpdateTitleActions(credentials.Title);
                educationActions.UpdateDegreeActions(credentials.Degree);
                educationActions.UpdateYearOfGraduationActions(credentials.Year);
                educationActions.UpdateEducationOptionActions();
                educationActions.VerifyToastMessageActions("UpdateEducation");

                VerifyEducationOnProfile(credentials);
                VerifyEducationOnResultsPage(credentials);
            }
        }

        public void AddDuplicateEducation(EducationCredentials credentials)

        {
            educationActions.AddNewEducationButtonActions();
            educationActions.AddCollegeUniversityNameActions(credentials.College);
            educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
            educationActions.AddTitleActions(credentials.Title);
            educationActions.AddDegreeActions(credentials.Degree);
            educationActions.AddYearOfGraduationActions(credentials.Year);
            educationActions.AddEducationButtonActions();
            educationActions.VerifyToastMessageActions("AddEducation");

            educationActions.NavigateToEducationTab();
            educationActions.AddNewEducationButtonActions();
            educationActions.AddCollegeUniversityNameActions(credentials.College);
            educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
            educationActions.AddTitleActions(credentials.Title);
            educationActions.AddDegreeActions(credentials.Degree);
            educationActions.AddYearOfGraduationActions(credentials.Year);
            educationActions.AddEducationButtonActions();
            educationActions.VerifyToastMessageActions("AddExistingEducation");
        }
        public void AddNullEducation(EducationCredentials credentials)
        {
            educationActions.AddNewEducationButtonActions();
            educationActions.AddCollegeUniversityNameActions(credentials.College);
            educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
            educationActions.AddTitleActions(credentials.Title);
            educationActions.AddDegreeActions(credentials.Degree);
            educationActions.AddYearOfGraduationActions(credentials.Year);
            educationActions.AddEducationButtonActions();
            educationActions.VerifyToastMessageActions("AddNullEducation");

        }
        public void CancelAddEducation(EducationCredentials credentials)
        {
            if (credentials.Action == "Add")
            {
                educationActions.AddNewEducationButtonActions();
                educationActions.AddCollegeUniversityNameActions(credentials.College);
                educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
                educationActions.AddTitleActions(credentials.Title);
                educationActions.AddDegreeActions(credentials.Degree);
                educationActions.AddYearOfGraduationActions(credentials.Year);
                educationActions.AddEducationButtonActions();
                educationActions.VerifyToastMessageActions("AddEducation");
                VerifyEducationOnProfile(credentials);

            }
            else if (credentials.Action == "CancelAdd")
            {

                educationActions.NavigateToEducationTab();
                educationActions.AddNewEducationButtonActions();
                educationActions.AddCollegeUniversityNameActions(credentials.College);
                educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
                educationActions.AddTitleActions(credentials.Title);
                educationActions.AddDegreeActions(credentials.Degree);
                educationActions.AddYearOfGraduationActions(credentials.Year);
                educationActions.AddEducationCancelButtonActions();
            }
        }


        public void CancelUpdateEducation(EducationCredentials credentials)
        {
            if (credentials.Action == "Add")
            {
                educationActions.AddNewEducationButtonActions();
                educationActions.AddCollegeUniversityNameActions(credentials.College);
                educationActions.AddCountyOfCollegeUniversityActions(credentials.Country);
                educationActions.AddTitleActions(credentials.Title);
                educationActions.AddDegreeActions(credentials.Degree);
                educationActions.AddYearOfGraduationActions(credentials.Year);
                educationActions.AddEducationButtonActions();
                VerifyEducationOnProfile(credentials);

            }
            else if (credentials.Action == "Update")
            {

                educationActions.NavigateToEducationTab();
                educationActions.UpdateCollegeUniversityNameActions(credentials.College);
                educationActions.UpdateCountyOfCollegeUniversityActions(credentials.Country);
                educationActions.UpdateTitleActions(credentials.Title);
                educationActions.UpdateDegreeActions(credentials.Degree);
                educationActions.UpdateYearOfGraduationActions(credentials.Year);
                educationActions.UpdateEducationCancelButtonActions();

            }

        }

        private void VerifyEducationOnProfile(EducationCredentials credentials)
        {
            string addedCountry = educationActions.GetAddedCountryOnProfilePage();
            string addedCollege = educationActions.GetAddedCollegeUniversityNameOnProfilePage();
            string addedTitle = educationActions.GetAddedTitleOnProfilePage();
            string addedDegree = educationActions.GetAddedDegreeOnProfilePage();
            string addedYear = educationActions.GetAddedYearOfGraduationYearOnProfilePage();
            Console.WriteLine("addedCountry: " + addedCountry);

            Assert.That(addedCountry == credentials.Country, "Country has not been added correctly.");
            Assert.That(addedCollege == credentials.College, "College has not been added correctly.");
            Assert.That(addedTitle == credentials.Title, "Title has not been added correctly.");
            Assert.That(addedDegree == credentials.Degree, "Degree has not been added correctly.");
            Assert.That(addedYear == credentials.Year, "Graduation Year has not been added correctly.");
        }

        private void VerifyEducationOnResultsPage(EducationCredentials credentials)
        {
            educationActions.ProfileOpenActionsResultsPage(credentials.User);
            educationActions.ViewAddedEducationDetailsOnResultsPage();

            string addedCountry = educationActions.GetAddedCountryOfCollegeOnResultsPage();
            string addedCollege = educationActions.GetAddedCollegeNameOnResultsPage();
            string addedTitle = educationActions.GetAddedTitleOnResultsPage();
            string addedDegree = educationActions.GetAddedDegreeOnResultsPage();
            string addedYear = educationActions.GetAddedYearOfGraduationOnResultsPage();

            Assert.That(addedCountry == credentials.Country, "Country has not been added on results page.");
            Assert.That(addedCollege == credentials.College, "College has not been added on results page.");
            Assert.That(addedTitle == credentials.Title, "Title has not been added on results page.");
            Assert.That(addedDegree == credentials.Degree, "Degree has not been added on results page.");
            Assert.That(addedYear == credentials.Year, "Graduation Year has not been added on results page.");
        }
    }
}
