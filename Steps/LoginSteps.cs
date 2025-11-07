using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SyncplicityUIFramework.Configuration;
using SyncplicityUIFramework.Constans;
using SyncplicityUIFramework.Locators;
using SyncplicityUIFramework.Pages;
using SyncplicityUIFramework.Tests;
using SyncplicityUIFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityUIFramework.Steps
{
    public class LoginSteps : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly AuthConfig _authData;
        private LoginLocators _loginLocators;

        public LoginSteps(IWebDriver driver, AuthConfig authData) : base(driver)
        {
            _driver = driver;
            _authData = authData;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _loginLocators = new LoginLocators();
        }
        public void SuccessfulLogin()
        {
            WaitForElementToBeVisible(_loginLocators.EmailInput);
            GetElement(_loginLocators.EmailInput).SendKeys(_authData.Username);
            GetElement(_loginLocators.NextButton).Click();
            WaitForElementToBeVisible(_loginLocators.Password);
            GetElement(_loginLocators.Password).SendKeys(_authData.Password);
            GetElement(_loginLocators.LoginButton).Click();
            AssertIsVisible(_loginLocators.LogoutButton, "Logout button is displayed.");
            _wait.Until(driver => driver.Url == UrlConstants.businessUrl);
            Assert.That(_driver.Url, Is.EqualTo(UrlConstants.businessUrl), $"Expected to be redirected to {UrlConstants.businessUrl} but was not");

        }
        public void WrongLogin()
        {
            WaitForElementToBeVisible(_loginLocators.EmailInput);
            GetElement(_loginLocators.EmailInput).SendKeys(_authData.WrongUsername);
            GetElement(_loginLocators.NextButton).Click();
            AssertIsVisible(_loginLocators.WrongEmailMsg, "Wrong message is visible");
        }
        public void CreateUser()
        {
            string email = EmailGenerator.GenerateRandomEmail();
            SuccessfulLogin();
            WaitForElementToBeVisible(_loginLocators.AdminUserAccount);
            GetElement(_loginLocators.AdminUserAccount).Click();
            GetElement(_loginLocators.AddUserButton).Click();
            GetElement(_loginLocators.DropDownRole).Click();
            GetElement(_loginLocators.InputEmailUsers).SendKeys(email);
            GetElement(_loginLocators.SelectValueGlobalAdministrator).Click();
            GetElement(_loginLocators.NextButtonUser).Click();
            WaitForElementToBeVisible(_loginLocators.NextGroupAddingButton);
            GetElement(_loginLocators.NextGroupAddingButton).Click();
            GetElement(_loginLocators.CheckBoxDesktop).Click();
            GetElement(_loginLocators.NextButtonFolders).Click();
            WaitForElementToBeVisible(_loginLocators.HeadMessage);
            Assert.That(_driver.Url, Is.EqualTo(UrlConstants.congratulationsUrl),$"Expected to be redirected to {UrlConstants.congratulationsUrl} but was not");


        }
    }
}