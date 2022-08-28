using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    public class BrowserOps
    {
        IWebDriver webDriver;

        public void InitBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        public string Title()
        {
            return webDriver.Title;
        }

        public void Goto(string url)
        {
            webDriver.Url = url;
        }

        public void Close()
        {
            webDriver.Quit();
        }

        public IWebDriver GetWebDriver()
        {
            return webDriver;
        }
    }

    public class Tests
    {
        BrowserOps browser = new BrowserOps();
        String test_url = "http://demowebshop.tricentis.com/";
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            browser.InitBrowser();
        }

        [Test]
        // Test Search Functionality Works
        // By searching for 'Belt' and checking correct
        // item is returned - data-productid = 40
        public void Test_Search()
        {
            browser.Goto(test_url);
            Thread.Sleep(4000);

            driver = browser.GetWebDriver();

            // Find Search Box, enter 'Belt' and press 'Enter'
            // //*[@id="small-searchterms"]
            IWebElement element = driver.FindElement(By.XPath("//*[@id='small-searchterms']"));

            element.SendKeys("Belt");
            element.Submit();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);

            // Check if correct Product is Displayed - ID = 40
            // //*[@data-productid='40']
            IWebElement searchRes = fluentWait.Until(x => x.FindElement(By.XPath("//*[@data-productid='40']")));
        }

        [Test]
        // Test Adding To Cart Functionality Works
        // By searching for 'Belt' and adding returned
        // item to the cart
        // Then Check Cart contains correct Item
        // item is 'Casual Golf Belt'
        public void Test_Add_To_Cart()
        {
            browser.Goto(test_url);
            Thread.Sleep(4000);

            driver = browser.GetWebDriver();

            // Find Search Box, enter 'Belt' and press 'Enter'
            // //*[@id="small-searchterms"]
            IWebElement element = driver.FindElement(By.XPath("//*[@id='small-searchterms']"));

            element.SendKeys("Belt");
            element.Submit();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);

            // Get 'Add to cart' Button for Product
            // Catalog ID = /addproducttocart/catalog/40/1/1
            // //input[@onclick=\"AjaxCart.addproducttocart_catalog('/addproducttocart/catalog/40/1/1    ');return false;\"]
            IWebElement addToCartButton = driver.FindElement(By.XPath("//input[@onclick=\"AjaxCart.addproducttocart_catalog('/addproducttocart/catalog/40/1/1    ');return false;\"]"));
            addToCartButton.Click();

            Thread.Sleep(2000);

            // Find Shopping Cart Link and Click it
            // //*[@id='topcartlink']
            IWebElement cartLink = driver.FindElement(By.XPath("//*[@id='topcartlink']"));
            cartLink.Click();

            // Wait for Shopping Cart to display
            // and check it contains 'Casual Golf Belt'
            // //*[text() = 'Casual Golf Belt']
            IWebElement checkBelt = fluentWait.Until(x => x.FindElement(By.XPath("//*[text() = 'Casual Golf Belt']")));
        }

        [Test]
        // Test Login Fails using:
        // ID = User@sample.test
        // PWD = Password
        public void Test_Invalid_Login()
        {
            browser.Goto(test_url);
            Thread.Sleep(4000);

            driver = browser.GetWebDriver();

            // Find Login Link and Click it
            // Link Text = 'Log in'
            IWebElement element = driver.FindElement(By.LinkText("Log in"));
            element.Click();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);

            // Find Email Input Box and enter 'User@Sample.test'
            // //*[@id='Email']
            IWebElement loginEmail = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='Email']")));
            loginEmail.SendKeys("User@sample.test");

            // Find Password Input Box and enter 'Password'
            // //*[@id='Password']
            IWebElement loginPwd = driver.FindElement(By.XPath("//*[@id='Password']"));
            loginPwd.SendKeys("Password");


            // Find Log in Button and Click it
            // //input[contains(@class, 'button-1.login-button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[contains(@class, 'login-button')]"));
            loginButton.Click();

            Thread.Sleep(2000);

            // Check Error Message is displayed
            // //*[text() = 'No customer account found']
            IWebElement errorMsg = driver.FindElement(By.XPath("//*[text() = 'No customer account found']"));
        }

        [Test]
        // Test Login Works using:
        // ID = User1@sample.test
        // PWD = Password1
        public void Test_Valid_Login()
        {
            browser.Goto(test_url);
            Thread.Sleep(4000);

            driver = browser.GetWebDriver();

            // Find Login Link and Click it
            // Link Text = 'Log in'
            IWebElement element = driver.FindElement(By.LinkText("Log in"));
            element.Click();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);

            // Find Email Input Box and enter 'User1@Sample.test'
            // //*[@id='Email']
            IWebElement loginEmail = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='Email']")));
            loginEmail.SendKeys("User1@sample.test");

            // Find Password Input Box and enter 'Password1'
            // //*[@id='Password']
            IWebElement loginPwd = driver.FindElement(By.XPath("//*[@id='Password']"));
            loginPwd.SendKeys("Password1");


            // Find Log in Button and Click it
            // //input[contains(@class, 'button-1.login-button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[contains(@class, 'login-button')]"));
            loginButton.Click();

            Thread.Sleep(2000);

            fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);

            // Check Displays 'User1@sample.test' in Header Links Section
            // Link Text = 'User1@sample.test'
            IWebElement userLink = driver.FindElement(By.LinkText("User1@sample.test"));
        }

        [TearDown]
        public void closeBrowser()
        {
            browser.Close();
        }
    }
}