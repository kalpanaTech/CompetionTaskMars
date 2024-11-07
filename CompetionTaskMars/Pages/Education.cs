using CompetionTaskMars.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetionTaskMars.Pages
{
    public class Education
    {
        private readonly IWebDriver driver;
        private readonly By profileTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private readonly By educationTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");
        private readonly By addNewEducationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        private readonly By collegeTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'College/University Name']");
        private readonly By countryOfCollegeDropdownLocator = By.XPath("//select[@class = 'ui dropdown' and @name = 'country']");
        private readonly By titleDropdownLocator = By.XPath("//select[@class = 'ui dropdown' and @name = 'title']");
        private readonly By degreeTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'Degree']");
        private readonly By yearDropdownLocator = By.XPath("//select[@class = 'ui dropdown' and @name = 'yearOfGraduation']");
        private readonly By addEducationButtonLocator = By.XPath("//input[@type = 'button' and @value = 'Add']");
        readonly By toastMessageLocator = By.XPath("//div[@class = 'ns-box-inner']");

        private readonly By addedCountryOfCollegeLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        private readonly By addedCollegeLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]");
        private readonly By addedTitleLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]");
        private readonly By addedDegreeLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]");
        private readonly By addedYearLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]");

        public static readonly Dictionary<string, string> ToastMessages = new Dictionary<string, string>
{
    { "Add", "Education has been added" },
    { "Update", "Education has been updated" },
    { "Delete", "Education entry successfully removed" },
    { "AddExistingEducation", "This information already exists." },
    { "AddNull", "Please enter all the fields" }
};

        public Education(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToEducationTab()
        {
            Wait.WaitToBeClickable(driver, profileTabLocator, 2);
            try
            {
                IWebElement profileTab = driver.FindElement(profileTabLocator);
                profileTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Profile Tab not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, educationTabLocator, 2);
            try
            {
                IWebElement educationTab = driver.FindElement(educationTabLocator);
                educationTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Education Tab not located:" + ex.Message);
            }
        }
        public void AddNewEducationButtonActions()
        {

            Wait.WaitToBeClickable(driver, addNewEducationButtonLocator, 2);
            try
            {
                IWebElement addNewEducationButton = driver.FindElement(addNewEducationButtonLocator);
                addNewEducationButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Add New Education Button not located:" + ex.Message);
            }

        }

        public void AddCollegeUniversityNameActions(string college)
        {
            Wait.WaitToBeClickable(driver, collegeTextBoxLocator, 2);
            try
            {
                IWebElement collegeTextBox = driver.FindElement(collegeTextBoxLocator);
                collegeTextBox.SendKeys(college);
            }
            catch (Exception ex)
            {
                Assert.Fail("College Text Box not located:" + ex.Message);
            }
        }

        public void AddCountyOfCollegeUniversityActions(string country)
        {
            Wait.WaitToBeClickable(driver, countryOfCollegeDropdownLocator, 2);
            try
            {
                IWebElement countryOfCollegeDropdown = driver.FindElement(countryOfCollegeDropdownLocator);
                //countryOfCollegeDropdown.Click();
                var selectElement = new SelectElement(countryOfCollegeDropdown);

                // Select country by visible text
                selectElement.SelectByText(country);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Country '{country}' not found in the dropdown options.");
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred while selecting the country: " + ex.Message);
            }
        }


        public void AddTitleActions(string title)
        {
            Wait.WaitToBeClickable(driver, titleDropdownLocator, 2);
            try
            {
                IWebElement titleDropdown = driver.FindElement(titleDropdownLocator);

                var selectElement = new SelectElement(titleDropdown);

                selectElement.SelectByText(title);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Title '{title}' not found in the dropdown options.");
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred while selecting the title: " + ex.Message);
            }
        }


        public void AddDegreeActions(string degree)
        {
            Wait.WaitToBeClickable(driver, degreeTextBoxLocator, 2);
            try
            {
                IWebElement degreeTextBox = driver.FindElement(degreeTextBoxLocator);
                degreeTextBox.SendKeys(degree);
            }
            catch (Exception ex)
            {
                Assert.Fail("Degree Text Box not located:" + ex.Message);
            }
        }


        public void AddYearOfGraduationActions(string year)
        {
            Wait.WaitToBeClickable(driver, yearDropdownLocator, 2);
            try
            {
                IWebElement yearDropdown = driver.FindElement(yearDropdownLocator);

                var selectElement = new SelectElement(yearDropdown);

                selectElement.SelectByText(year);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Year '{year}' not found in the dropdown options.");
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred while selecting the year: " + ex.Message);
            }
        }

        public void AddEducationButtonActions()

        {
            Wait.WaitToBeClickable(driver, addEducationButtonLocator, 2);
            try
            {
                IWebElement addEducationButton = driver.FindElement(addEducationButtonLocator);
                addEducationButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Add Education Button not located:" + ex.Message);
            }
        }


        public void VerifyToastMessageActions(string action)
        {
            Wait.WaitToBeClickable(driver, toastMessageLocator, 2);
            try
            {
                IWebElement toastMessage = driver.FindElement(toastMessageLocator);
                string messageText = toastMessage.Text;

                if (ToastMessages.TryGetValue(action, out string expectedMessage))
                {
                    if (messageText == expectedMessage)
                    {
                        Console.WriteLine("Toast message text is correct: " + messageText);
                    }
                    else
                    {
                        Console.WriteLine($"Toast message text is incorrect. Expected: {expectedMessage}, but found: {messageText}");
                        Assert.Fail("Toast message text is incorrect ");
                    }
                }
                else
                {
                    Console.WriteLine("No expected message found for action: " + action);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Toast message not located: " + ex.Message);
            }
        }



        public string GetAddedCountryOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedCountryOfCollegeLocator, 2);
            IWebElement addedCountryOfCollege = driver.FindElement(addedCountryOfCollegeLocator);
            return addedCountryOfCollege.Text;

        }

        public string GetAddedCollegeUniversityNameOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedCollegeLocator, 2);
            IWebElement addedCollege = driver.FindElement(addedCollegeLocator);
            return addedCollege.Text;

        }

        public string GetAddedTitleOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedTitleLocator, 2);
            IWebElement addedTitle = driver.FindElement(addedTitleLocator);
            return addedTitle.Text;
        }
        public string GetAddedDegreeOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedDegreeLocator, 2);
            IWebElement addedDegree = driver.FindElement(addedDegreeLocator);
            return addedDegree.Text;

        }
        public string GetAddedYearOfGraduationYearOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedYearLocator, 2);
            IWebElement addedYear = driver.FindElement(addedYearLocator);
            return addedYear.Text;
        }


        /*

    public void ResultsDisplayActions()
    {

    }

    public void ViewAddedEducationDetailsOnResultsPage()
    {

    }

    public string GetAddedCollegeUniversityNameOnResultsPage()
    {

    }
    public string GetAddedCountyOfCollegeUniversityOnResultsPage()
    {

    }
    public string GetAddedTitleOnResultsPage()
    {

    }
    public string GetAddedDegreeOnResultsPage()
    {

    }
    public string GetAddedYearOfGraduationOnResultsPage()
    {

    }

    public void RemoveAddedEducationDetails() //Data clear 
    {

    }

    public void UpdateCollegeUniversityNameActions()
    {
    }

    public void UpdateCountyOfCollegeUniversityActions()
    {
    }

    public void UpdateTitleActions()
    {
    }

    public void UpdateDegreeActions()
    {
    }

    public void UpdateYearOfGraduationActions()
    {
    }

    public void UpdateEducationOptionActions() //UpdateEducationButton

    {
    }

    // public string GetAddedCollegeUniversityNameOnProfilePage() :  Use above 5

    public void AddEducationCancelButtonActions()
    {

    }

    public void UpdateEducationCancelButtonActions()
    {

    }
    public void AddEducationWithLongString()
    {

    }
    */

    }


}
