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
        readonly By profileTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private readonly By educationTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");
        private readonly By removeIconLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i");

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

        readonly By searchIconLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i");
        readonly By categoryProgrammingLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[7]");
        readonly By subCategoryQALocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[11]");
        readonly By userSearchBoxLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input");
        readonly By firstSearchResultLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span");
        readonly By searchedUserProfiletLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[1]");
        private readonly By educationTabResultsPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");

        private readonly By addedCountryOfCollegeOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/table/tbody[last()]/tr/td[1]");
        private readonly By addedCollegeOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/table/tbody[last()]/tr/td[2]");
        private readonly By addedTitleOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/table/tbody[last()]/tr/td[3]");
        private readonly By addedDegreeOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/table/tbody[last()]/tr/td[4]");
        private readonly By addedYearOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/table/tbody[last()]/tr/td[5]");

        private readonly By updateIconLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i");
        private readonly By updateCollegeTextBoxLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[1]/div[1]/input");
        private readonly By updateCountryOfCollegeDropdownLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[1]/div[2]/select");
        private readonly By updateTitleDropdownLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[2]/div[1]/select");
        private readonly By updateDegreeTextBoxLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[2]/div[2]/input");
        private readonly By updateYearDropdownLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[2]/div[3]/select");

        private readonly By updateEducationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[3]/input[1]");
        private readonly By updateEducationCancelButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[3]/input[2]");
        private readonly By addEducationCancelButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]");

        public static readonly Dictionary<string, string> ToastMessages = new Dictionary<string, string>
{
    { "AddEducation", "Education has been added" },
    { "UpdateEducation", "Education as been updated" },
    { "DeleteEducation", "Education entry successfully removed" },
    { "AddExistingEducation", "This information is already exist." },
    { "AddNullEducation", "Please enter all the fields" }
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

        public void Cleanup()
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


            IList<IWebElement> removeIcon;
            do
            {

                removeIcon = driver.FindElements(removeIconLocator);

                if (removeIcon.Count > 0)
                {

                    Wait.WaitToBeClickable(driver, removeIconLocator, 2);
                    try
                    {
                        removeIcon[0].Click();
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail("Remove Icon not located or couldn't be clicked: " + ex.Message);
                    }
                    driver.Navigate().Refresh();

                    Wait.WaitToBeClickable(driver, educationTabLocator, 2);

                    IWebElement educationTab = driver.FindElement(educationTabLocator);
                    educationTab.Click();
                    Thread.Sleep(2000);

                }
            } while (removeIcon.Count > 0);
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

        public void ProfileOpenActionsResultsPage(string user)
        {

            Wait.WaitToBeClickable(driver, searchIconLocator, 2);
            try
            {
                IWebElement searchIcon = driver.FindElement(searchIconLocator);
                searchIcon.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Search Icon not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, categoryProgrammingLocator, 2);
            try
            {
                IWebElement categoryProgramming = driver.FindElement(categoryProgrammingLocator);
                categoryProgramming.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Category Programming not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, subCategoryQALocator, 2);
            try
            {
                IWebElement subCategoryQA = driver.FindElement(subCategoryQALocator);
                subCategoryQA.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Sub Category QA not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, userSearchBoxLocator, 2);
            try
            {
                IWebElement userSearchBox = driver.FindElement(userSearchBoxLocator);
                userSearchBox.SendKeys(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(" User Search Box not located:" + ex.Message);
            }

            Wait.WaitToBeVisible(driver, firstSearchResultLocator, 10);
            Wait.WaitToBeClickable(driver, firstSearchResultLocator, 10);
            try
            {
                IWebElement firstSearchResult = driver.FindElement(firstSearchResultLocator);
                firstSearchResult.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" First Search Result not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, searchedUserProfiletLocator, 5);
            try
            {
                IWebElement searchedUserProfile = driver.FindElement(searchedUserProfiletLocator);
                searchedUserProfile.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Searched User Profile not located:" + ex.Message);
            }
        }
        public void ViewAddedEducationDetailsOnResultsPage()
        {

            Wait.WaitToBeClickable(driver, educationTabResultsPageLocator, 8);
            try
            {
                IWebElement educationTabResultsPage = driver.FindElement(educationTabResultsPageLocator);
                educationTabResultsPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Education Tab Results Page not located:" + ex.Message);
            }

        }

        public string GetAddedCountryOfCollegeOnResultsPage()
        {
            Wait.WaitToBeVisible(driver, addedCountryOfCollegeOnResultPageLocator, 8);
            IWebElement addedCountryOfCollegeOnResultPage = driver.FindElement(addedCountryOfCollegeOnResultPageLocator);
            return addedCountryOfCollegeOnResultPage.Text;
        }

        public string GetAddedCollegeNameOnResultsPage()
        {
            Wait.WaitToBeVisible(driver, addedCollegeOnResultPageLocator, 2);
            IWebElement addedCollegeOnResultPage = driver.FindElement(addedCollegeOnResultPageLocator);
            return addedCollegeOnResultPage.Text;

        }

        public string GetAddedTitleOnResultsPage()
        {
            Wait.WaitToBeVisible(driver, addedTitleOnResultPageLocator, 2);
            IWebElement addedTitleOnResultPage = driver.FindElement(addedTitleOnResultPageLocator);
            return addedTitleOnResultPage.Text;

        }

        public string GetAddedDegreeOnResultsPage()
        {
            Wait.WaitToBeVisible(driver, addedDegreeOnResultPageLocator, 2);
            IWebElement addedDegreeOnResultPage = driver.FindElement(addedDegreeOnResultPageLocator);
            return addedDegreeOnResultPage.Text;

        }

        public string GetAddedYearOfGraduationOnResultsPage()
        {
            Wait.WaitToBeVisible(driver, addedYearOnResultPageLocator, 2);
            IWebElement addedYearOnResultPage = driver.FindElement(addedYearOnResultPageLocator);
            return addedYearOnResultPage.Text;
        }


        public void UpdateCollegeUniversityNameActions(string college)
        {
            Wait.WaitToBeClickable(driver, updateIconLocator, 2);
            try
            {
                IWebElement updateIcon = driver.FindElement(updateIconLocator);
                updateIcon.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Update Icon not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, updateCollegeTextBoxLocator, 2);
            try
            {
                IWebElement updateCollegeTextBox = driver.FindElement(updateCollegeTextBoxLocator);
                updateCollegeTextBox.Clear();
                updateCollegeTextBox.SendKeys(college);
            }
            catch (Exception ex)
            {
                Assert.Fail(" Added College not located:" + ex.Message);
            }

        }

        public void UpdateCountyOfCollegeUniversityActions(string country)
        {
            Wait.WaitToBeClickable(driver, updateCountryOfCollegeDropdownLocator, 2);
            try
            {
                IWebElement updateCountryOfCollegeDropdown = driver.FindElement(updateCountryOfCollegeDropdownLocator);
                //countryOfCollegeDropdown.Click();
                var selectElement = new SelectElement(updateCountryOfCollegeDropdown);

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


        public void UpdateTitleActions(string title)
        {
            Wait.WaitToBeClickable(driver, updateTitleDropdownLocator, 2);
            try
            {
                IWebElement updateTitleDropdown = driver.FindElement(updateTitleDropdownLocator);

                var selectElement = new SelectElement(updateTitleDropdown);

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

        public void UpdateDegreeActions(string degree)
        {
            Wait.WaitToBeClickable(driver, updateDegreeTextBoxLocator, 2);
            try
            {
                IWebElement updateDegreeTextBox = driver.FindElement(updateDegreeTextBoxLocator);
                updateDegreeTextBox.Clear();
                updateDegreeTextBox.SendKeys(degree);
            }
            catch (Exception ex)
            {
                Assert.Fail("Degree Text Box not located:" + ex.Message);
            }
        }

        public void UpdateYearOfGraduationActions(string year)
        {
            Wait.WaitToBeClickable(driver, updateYearDropdownLocator, 2);
            try
            {
                IWebElement updateYearDropdown = driver.FindElement(updateYearDropdownLocator);

                var selectElement = new SelectElement(updateYearDropdown);

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



        public void UpdateEducationOptionActions()

        {
            Wait.WaitToBeClickable(driver, updateEducationButtonLocator, 2);
            try
            {
                IWebElement updateEducationButton = driver.FindElement(updateEducationButtonLocator);
                updateEducationButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Update Education Button not located:" + ex.Message);
            }
        }



        public void AddEducationCancelButtonActions()
        {
            Wait.WaitToBeClickable(driver, addEducationCancelButtonLocator, 2);
            try
            {
                IWebElement addEducationCancelButton = driver.FindElement(addEducationCancelButtonLocator);
                addEducationCancelButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Add Education Cancel Button not located:" + ex.Message);
            }

        }

        public void UpdateEducationCancelButtonActions()
        {
            Wait.WaitToBeClickable(driver, updateEducationCancelButtonLocator, 2);
            try
            {
                IWebElement updateEducationCancelButton = driver.FindElement(updateEducationCancelButtonLocator);
                updateEducationCancelButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Update Education Cancel Button not located:" + ex.Message);
            }

        }



    }


}
