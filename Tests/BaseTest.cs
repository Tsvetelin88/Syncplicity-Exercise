
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using SyncplicityUIFramework.Configuration;

namespace SyncplicityUIFramework.Tests;
public class BaseTest
{
    protected IWebDriver driver;

    protected AuthConfig AuthData;

    private IConfiguration Configuration;

    [SetUp]
    public void Setup()
    {

        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        AuthData = Configuration.GetSection("Auth").Get<AuthConfig>();

        string baseUrl = Configuration.GetSection("prod")["baseUrl"];

        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        driver.Navigate().GoToUrl(baseUrl);

    }

    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}