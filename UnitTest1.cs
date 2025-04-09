using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestProject12
{
    class Tests
    {
        // Create a reference for Chrome Browser
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            // Go To Facebook Page, Full Screen
            driver.Navigate().GoToUrl("https://www.facebook.com/r.php?entry_point=login");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ExecuteTest()
        {
            // FirstName
            IWebElement FirstName = driver.FindElement(By.Name("firstname"));
            FirstName.SendKeys("John");

            // LastName
            IWebElement LastName = driver.FindElement(By.Name("lastname"));
            LastName.SendKeys("Budeikin");

            // Email
            IWebElement Email = driver.FindElement(By.Name("reg_email__"));
            Email.SendKeys("johnbudeikin@gmail.com");

            // Password
            IWebElement Password = driver.FindElement(By.Name("reg_passwd__"));
            Password.SendKeys("19455815");

            // Select Mounth
            IWebElement Month = driver.FindElement(By.Name("birthday_month"));
            var SelectElementMonth = new SelectElement(Month);
            SelectElementMonth.SelectByValue("7");

            // Select Day 
            IWebElement Day = driver.FindElement(By.Name("birthday_day"));
            var SelectElementDay = new SelectElement(Day);
            SelectElementDay.SelectByValue("27");

            // Select Year
            IWebElement Year = driver.FindElement(By.Name("birthday_year"));
            var SelectElementYear = new SelectElement(Year);
            SelectElementYear.SelectByValue("2006");

            // Select Gender
            IWebElement Sex = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/form/div[1]/div[4]/span/span[2]/label/input"));
            Sex.Click();

            // Select Sing Up Button
            IWebElement SingUp = driver.FindElement(By.Name("websubmit"));
            SingUp.Click();

            Thread.Sleep(5000);

            // ErrorMessage
            IWebElement ErrorMessage = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/div[1]/div"));
            Assert.That(ErrorMessage.Text.Contains("При регистрации произошла ошибка. Попробуйте ещё раз."));
        }
        [TearDown]
        public void CloseTest()
        {
            // Close the browser
            driver.Quit();
        }
    }
}