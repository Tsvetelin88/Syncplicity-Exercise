using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SyncplicityUIFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public IWebElement FindElement(By by) 
        {
            return Driver.FindElement(by);
        }
        public void SelectByText(By by, string text)
        {
            new SelectElement(FindElement(by)).SelectByText(text);
        }

        public IWebElement WaitForElementToBeVisible(By by, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));

            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException)
            {

                throw new TimeoutException($"The element located with {by} did not become visible in {timeoutInSeconds} seconds.");
            }
        }
        public void AssertIsVisible(By by, string message, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));

            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));

                Assert.That(element.Displayed, Is.True, message);
            }
            catch (WebDriverTimeoutException)
            {

                Assert.Fail($"The element did not become visible within {timeoutInSeconds} seconds. {message}");
            }
        }
        public IWebElement GetElement(By by)
        {
            return Driver.FindElement(by);
        }
    }
}

