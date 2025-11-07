using OpenQA.Selenium;
using SyncplicityUIFramework.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityUIFramework.Locators
{
    public class LoginLocators
    {
        //login locators
        public By EmailInput = By.Id("MainContent_login_UserName");
        public By Password = By.Id("MainContent_login_txtPassword");
        public By LoginButton = By.Id("MainContent_login_btnLogin");
        public By NextButton = By.Id("MainContent_login_btnNext");

        public By LogoutButton = By.Id("loginView1_ahrefLogout");
        public By WrongEmailMsg = By.Id("MainContent_login_UserName-error");
        public By HeadMessage = By.XPath("//h2[contains(text(), 'User accounts successfully created')]");

        public By AdminUserAccount = By.XPath("//a[@href='/Business/UserSearch.aspx']");
        public By AddUserButton = By.XPath("//a[@href='AddUser.aspx#users']");
        public By DropDownRole = By.Id("roleselect");
        public By SelectValueGlobalAdministrator = By.XPath("//li[@roleid ='2']");
        public By NextButtonUser = By.Id("nextButtonUserEmails");
        public By InputEmailUsers = By.Id("txtUserEmails");
        public By NextGroupAddingButton = By.Id("nextButtonGroupMembership");
        public By CheckBoxDesktop = By.Id("chkDesktop");
        public By NextButtonFolders= By.Id("nextButtonUserFolders");
    }
}
