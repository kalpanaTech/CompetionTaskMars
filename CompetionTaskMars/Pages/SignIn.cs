using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetionTaskMars.Helpers;
using CompetionTaskMars.Utilities;

namespace CompetionTaskMars.Pages
{
    public class SignIn
    {
        private readonly IWebDriver driver;
        private readonly By signInButtonLocator = By.XPath("//A[@class='item'][text()='Sign In']");
        private readonly By emailTextBoxLocator = By.XPath("//input[@placeholder='Email address' and @name='email']");
        private readonly By passwordTextBoxLocator = By.XPath("//input[@placeholder='Password' and @name='password']");
        private readonly By loginButtonLocator = By.XPath("//button[@class = 'fluid ui teal button'][text() = 'Login']");


        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoginActions(string email, string password)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();

            try
            {
                var signInButton = driver.FindElement(signInButtonLocator);
                signInButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Sign In Button not located: " + ex.Message);
            }

            try
            {
                var emailTextBox = driver.FindElement(emailTextBoxLocator);
                emailTextBox.SendKeys(email);
            }
            catch (Exception ex)
            {
                Assert.Fail("Email Text Box not located: " + ex.Message);
            }

            try
            {
                var passwordTextBox = driver.FindElement(passwordTextBoxLocator);
                passwordTextBox.SendKeys(password);
            }
            catch (Exception ex)
            {
                Assert.Fail("Password Text Box not located: " + ex.Message);
            }

            try
            {
                var loginButton = driver.FindElement(loginButtonLocator);
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Login Button not located: " + ex.Message);
            }

        }
    }
}
