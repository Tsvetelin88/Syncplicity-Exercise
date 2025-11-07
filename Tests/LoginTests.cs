using OpenQA.Selenium;
using SyncplicityUIFramework.Constans;
using SyncplicityUIFramework.Pages;
using SyncplicityUIFramework.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityUIFramework.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {

        [Test(Description = "Verify successfull login")]
        public void ValidLogin()
        {
            LoginSteps loginSteps = new LoginSteps(driver, AuthData);
            loginSteps.SuccessfulLogin();

        }

        [Test(Description = "Verify successfully created global administrator role user")]
        public void CreateAnUserRoleGlobalAdministrator()
        {
            LoginSteps loginSteps = new LoginSteps(driver, AuthData);
            loginSteps.CreateUser();

        }

        [Test(Description = "Verify message for wrong login is displayed")]
        public void VerifyWrongLoginMessage()
        {
            LoginSteps loginSteps = new LoginSteps(driver, AuthData);
            loginSteps.WrongLogin();

        }

    }
}