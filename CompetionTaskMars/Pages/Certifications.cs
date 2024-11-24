using CompetionTaskMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompetionTaskMars.Pages
{
    public class Certifications
    {
        private readonly IWebDriver driver;
        readonly By profileTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private readonly By certificationTabLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");
        private readonly By certificationRemoveIconLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i");
        private readonly By addNewCertificationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        private readonly By certificateTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'Certificate or Award' and @name = 'certificationName']");
        private readonly By certifiedFromTextBoxLocator = By.XPath("//input[@type = 'text' and @placeholder = 'Certified From (e.g. Adobe)' and @name = 'certificationFrom']");
        private readonly By certificationYearDropdownLocator = By.XPath("//select[@class = 'ui fluid dropdown' and @name = 'certificationYear']");
        private readonly By addCertificationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        readonly By toastMessageLocator = By.XPath("//div[@class = 'ns-box-inner']");

        readonly By addedCertificateLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]");
        readonly By addedCertificateFromLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]");
        readonly By addedCertificateYearLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]");

        readonly By searchIconLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i");
        readonly By categoryProgrammingLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[7]");
        readonly By subCategoryQALocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[11]");
        readonly By userSearchBoxLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input");
        readonly By firstSearchResultLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span");
        readonly By searchedUserProfiletLocator = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[1]");
        private readonly By certificateTabResultsPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[5]");

        readonly By addedCertificateOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[6]/table/tbody/tr[last()]/td[1]");
        readonly By addedCertificateFromOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[6]/table/tbody/tr[last()]/td[2]");
        readonly By addedCertificateYearOnResultPageLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[6]/table/tbody/tr[last()]/td[3]");

        private readonly By updateCertificationIconLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i");
        private readonly By updateCertificateTextBoxLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/div/div[1]/input");
        private readonly By updateCertifiedFromTextBoxLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/div/div[2]/input");
        private readonly By updateCertificationYearDropdownLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/div/div[3]/select");
        private readonly By updateCeretificationButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");

        private readonly By addCeretificationCancelButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]");
        private readonly By updateCeretificationCancelButtonLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]");


        public static readonly Dictionary<string, string> ToastMessages = new Dictionary<string, string>
{
    { "AddCertification", " has been added to your certification" },
    { "UpdateCertification", " has been updated to your certification" },
    { "DeleteCertification", " has been deleted from your certification" },
    { "AddExistingCertification", "This information is already exist." },
    { "AddNullCertification", "Please enter Certification Name, Certification From and Certification Year" }
};

        public Certifications(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToCertificationTab()
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

            Wait.WaitToBeClickable(driver, certificationTabLocator, 2);
            try
            {
                IWebElement certificationTab = driver.FindElement(certificationTabLocator);
                certificationTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Certification Tab not located:" + ex.Message);
            }
        }

        public void CleanupCertification()
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

            Wait.WaitToBeClickable(driver, certificationTabLocator, 2);
            try
            {
                IWebElement certificationTab = driver.FindElement(certificationTabLocator);
                certificationTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Certification Tab not located:" + ex.Message);
            }


            IList<IWebElement> certificationRemoveIcon;
            do
            {

                certificationRemoveIcon = driver.FindElements(certificationRemoveIconLocator);

                if (certificationRemoveIcon.Count > 0)
                {

                    Wait.WaitToBeClickable(driver, certificationRemoveIconLocator, 2);
                    try
                    {
                        certificationRemoveIcon[0].Click();
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail("Remove Icon not located or couldn't be clicked: " + ex.Message);
                    }
                    driver.Navigate().Refresh();

                    Wait.WaitToBeClickable(driver, certificationTabLocator, 2);

                    IWebElement certificationTab = driver.FindElement(certificationTabLocator);
                    certificationTab.Click();
                    Thread.Sleep(2000);

                }
            } while (certificationRemoveIcon.Count > 0);
        }

        public void AddNewCertificationButtonActions()
        {

            Wait.WaitToBeClickable(driver, addNewCertificationButtonLocator, 2);
            try
            {
                IWebElement addNewCertificationButton = driver.FindElement(addNewCertificationButtonLocator);
                addNewCertificationButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Add New Certification Button not located:" + ex.Message);
            }

        }

        public void AddCertificateActions(string certificate)
        {
            Wait.WaitToBeClickable(driver, certificateTextBoxLocator, 2);
            try
            {
                IWebElement certificateTextBox = driver.FindElement(certificateTextBoxLocator);
                certificateTextBox.SendKeys(certificate);
            }
            catch (Exception ex)
            {
                Assert.Fail("Certificate Text Box not located:" + ex.Message);
            }
        }

        public void AddCertifiedFromeActions(string certifiedFrom)
        {
            Wait.WaitToBeClickable(driver, certifiedFromTextBoxLocator, 2);
            try
            {
                IWebElement certifiedFromTextBox = driver.FindElement(certifiedFromTextBoxLocator);
                certifiedFromTextBox.SendKeys(certifiedFrom);
            }
            catch (Exception ex)
            {
                Assert.Fail("CertifiedFrom Text Box not located:" + ex.Message);
            }
        }

        public void AddYearOfCertificationActions(string certificationYear)
        {
            Wait.WaitToBeClickable(driver, certificationYearDropdownLocator, 2);
            try
            {
                IWebElement certificationYearDropdown = driver.FindElement(certificationYearDropdownLocator);

                var selectElement = new SelectElement(certificationYearDropdown);

                selectElement.SelectByText(certificationYear);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Year '{certificationYear}' not found in the dropdown options.");
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred while selecting the certification Year: " + ex.Message);
            }
        }

        public void AddCertificationButtonActions()

        {
            Wait.WaitToBeClickable(driver, addCertificationButtonLocator, 2);
            try
            {
                IWebElement addCertificationButton = driver.FindElement(addCertificationButtonLocator);
                addCertificationButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Add Certification Button not located:" + ex.Message);
            }
        }
        public void VerifyCertificationToastMessageActions(string action, string certificate)
        {
            Wait.WaitToBeClickable(driver, toastMessageLocator, 2);
            try
            {
                IWebElement toastMessage = driver.FindElement(toastMessageLocator);
                string messageText = toastMessage.Text;

                if (ToastMessages.TryGetValue(action, out string expectedMessage))
                {
                    if (action == "AddCertification" || action == "UpdateCertification" || action == "DeleteCertification")
                    {

                        if (messageText == certificate + expectedMessage)
                        {
                            Console.WriteLine("Toast message text is correct: " + messageText);
                        }
                    }
                    else if (action == "AddExistingCertification")
                    {
                        if (messageText == expectedMessage)
                        {
                            Console.WriteLine("Toast message text is correct: " + messageText);
                        }

                    }
                    else if (action == "AddNullCertification")
                    {
                        if (messageText == expectedMessage)
                        {
                            Console.WriteLine("Toast message text is correct: " + messageText);
                        }

                    }

                    else
                    {
                        Console.WriteLine($"Toast message text is incorrect, but found: {messageText}");
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

        public string GetAddedCertificateOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedCertificateLocator, 2);
            IWebElement addedCertificate = driver.FindElement(addedCertificateLocator);
            return addedCertificate.Text;

        }
        public string GetAddedCertificateFromOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedCertificateFromLocator, 2);
            IWebElement addedCertificateFrom = driver.FindElement(addedCertificateFromLocator);
            return addedCertificateFrom.Text;

        }
        public string GetAddedCertificateYearOnProfilePage()
        {
            Wait.WaitToBeVisible(driver, addedCertificateYearLocator, 2);
            IWebElement addedCertificateYear = driver.FindElement(addedCertificateYearLocator);
            return addedCertificateYear.Text;

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

            Wait.WaitToBeVisible(driver, firstSearchResultLocator, 5);
            Wait.WaitToBeClickable(driver, firstSearchResultLocator, 5);
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
        public void ViewAddedCertificationDetailsOnResultsPage()
        {

            Wait.WaitToBeClickable(driver, certificateTabResultsPageLocator, 8);
            try
            {
                IWebElement certificateTabResultsPage = driver.FindElement(certificateTabResultsPageLocator);
                certificateTabResultsPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Certification Tab Results Page not located:" + ex.Message);
            }

        }

        public string GetAddedCertificateOnResultPage()
        {
            Wait.WaitToBeVisible(driver, addedCertificateOnResultPageLocator, 8);
            IWebElement addedCertificateOnResultPage = driver.FindElement(addedCertificateOnResultPageLocator);
            return addedCertificateOnResultPage.Text;

        }
        public string GetAddedCertificateFromOnResultPage()
        {
            Wait.WaitToBeVisible(driver, addedCertificateFromOnResultPageLocator, 2);
            IWebElement addedCertificateFromOnResultPage = driver.FindElement(addedCertificateFromOnResultPageLocator);
            return addedCertificateFromOnResultPage.Text;

        }
        public string GetAddedCertificateYearOnResultPage()
        {
            Wait.WaitToBeVisible(driver, addedCertificateYearOnResultPageLocator, 2);
            IWebElement addedCertificateYearOnResultPage = driver.FindElement(addedCertificateYearOnResultPageLocator);
            return addedCertificateYearOnResultPage.Text;

        }

        public void UpdateCertificationActions(string certificate)
        {
            Wait.WaitToBeClickable(driver, updateCertificationIconLocator, 2);
            try
            {
                IWebElement updateCertificationIcon = driver.FindElement(updateCertificationIconLocator);
                updateCertificationIcon.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Certificate update Icon not located:" + ex.Message);
            }

            Wait.WaitToBeClickable(driver, updateCertificateTextBoxLocator, 2);
            try
            {
                IWebElement updateCertificateTextBox = driver.FindElement(updateCertificateTextBoxLocator);
                updateCertificateTextBox.Clear();
                updateCertificateTextBox.SendKeys(certificate);
            }
            catch (Exception ex)
            {
                Assert.Fail(" Added Certificate not located:" + ex.Message);
            }

        }
        public void UpdateCertifiedFromeActions(string certifiedFrom)
        {
            Wait.WaitToBeClickable(driver, updateCertifiedFromTextBoxLocator, 2);
            try
            {
                IWebElement updateCertifiedFromTextBox = driver.FindElement(updateCertifiedFromTextBoxLocator);
                updateCertifiedFromTextBox.Clear();
                updateCertifiedFromTextBox.SendKeys(certifiedFrom);
            }
            catch (Exception ex)
            {
                Assert.Fail("CertifiedFrom Text Box not located:" + ex.Message);
            }
        }

        public void UpdateYearOfCertificationActions(string certificationYear)
        {
            Wait.WaitToBeClickable(driver, updateCertificationYearDropdownLocator, 2);
            try
            {
                IWebElement updateCertificationYearDropdown = driver.FindElement(updateCertificationYearDropdownLocator);

                var selectElement = new SelectElement(updateCertificationYearDropdown);

                selectElement.SelectByText(certificationYear);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Year '{certificationYear}' not found in the dropdown options.");
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred while selecting the certification Year: " + ex.Message);
            }
        }

        public void UpdateCertificationOptionActions()

        {
            Wait.WaitToBeClickable(driver, updateCeretificationButtonLocator, 2);
            try
            {
                IWebElement updateCeretificationButton = driver.FindElement(updateCeretificationButtonLocator);
                updateCeretificationButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Update Certification Button not located:" + ex.Message);
            }
        }

        public void AddCertificationCancelButtonActions()
        {
            Wait.WaitToBeClickable(driver, addCeretificationCancelButtonLocator, 2);
            try
            {
                IWebElement addCeretificationCancelButton = driver.FindElement(addCeretificationCancelButtonLocator);
                addCeretificationCancelButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Add certification Cancel Button not located:" + ex.Message);
            }

        }

        public void UpdateCertificationCancelButtonActions()
        {
            Wait.WaitToBeClickable(driver, updateCeretificationCancelButtonLocator, 2);
            try
            {
                IWebElement updateCeretificationCancelButton = driver.FindElement(updateCeretificationCancelButtonLocator);
                updateCeretificationCancelButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Update certification Cancel Button not located:" + ex.Message);
            }

        }



    }
}
