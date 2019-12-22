using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSelenium
{
    class Register
    {
        ChromeDriver chromeDriver = new ChromeDriver();
        string Url = "http://automationpractice.com/index.php";
        [SetUp]
        public void OpenWeb()
        {
            chromeDriver.Url = Url;
            chromeDriver.Navigate();
            Console.WriteLine("Open Web");
        }

        [Test]
        public void InputEmail()
        {
            var path = @"D:\user.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            var buttonView = chromeDriver.FindElementByXPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]");
            buttonView.Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var inputEmail = chromeDriver.FindElementById("email_create");
            inputEmail.SendKeys(lines[0]);
            var buttonSubmit = chromeDriver.FindElementById("SubmitCreate");
            buttonSubmit.Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("Execute test");
            Console.WriteLine("Create successful");
        }

        [Test]
        public void CreateNewAccount()
        {
            var path = @"D:\user.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            var buttonView = chromeDriver.FindElementByXPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]");
            buttonView.Click();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var inputEmail = chromeDriver.FindElementById("email_create");

            inputEmail.SendKeys(lines[0]);
            var buttonSubmit = chromeDriver.FindElementById("SubmitCreate");

            buttonSubmit.Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            RadioButtons categories = new RadioButtons(chromeDriver, chromeDriver.FindElements(By.Id("id_gender1")));

            categories.SelectValue(lines[1]);

            var firstName = chromeDriver.FindElementById("customer_firstname");
            firstName.SendKeys(lines[2]);

            var lasttName = chromeDriver.FindElementById("customer_lastname");
            lasttName.SendKeys(lines[3]);

            var password = chromeDriver.FindElementById("passwd");
            password.SendKeys(lines[4]);

            var cboDay = chromeDriver.FindElement(By.Name("days"));

            new SelectElement(cboDay).SelectByValue(lines[5]);

            var cboThang = chromeDriver.FindElement(By.Name("months"));

            new SelectElement(cboThang).SelectByValue(lines[6]);

            var cboNam = chromeDriver.FindElement(By.Name("years"));

            new SelectElement(cboNam).SelectByValue(lines[7]);

            var cboState = chromeDriver.FindElement(By.Name("id_state"));

            new SelectElement(cboState).SelectByValue(lines[8]);

            var rd1 = chromeDriver.FindElement(By.XPath("//*[@id=\"newsletter\"]"));
            rd1.Click();

            var rd2 = chromeDriver.FindElement(By.XPath("//*[@id=\"optin\"]"));
            rd2.Click();

            var inputCompany = chromeDriver.FindElementById("company");

            inputCompany.SendKeys(lines[9]);

            var address = chromeDriver.FindElementById("address1");

            address.SendKeys(lines[10]);

            var address2 = chromeDriver.FindElementById("address2");

            address2.SendKeys(lines[11]);

            var city = chromeDriver.FindElementById("city");

            city.SendKeys(lines[12]);

            var code = chromeDriver.FindElementById("postcode");

            code.SendKeys(lines[13]);

            var phone = chromeDriver.FindElementById("phone");

            phone.SendKeys(lines[14]);

            var phoneMobile = chromeDriver.FindElementById("phone_mobile");

            phoneMobile.SendKeys(lines[15]);

            var buttonAccount = chromeDriver.FindElementById("submitAccount");

            buttonAccount.Click();

            Console.WriteLine("Execute test");
            Console.WriteLine("Create Account Successfull");
        }

        [TearDown]
        public void CloseWeb()
        {
            Console.WriteLine("Close browser");
        }

        public class RadioButtons
        {
            public RadioButtons(IWebDriver driver, ReadOnlyCollection<IWebElement> webElements)
            {
                Driver = driver;
                WebElements = webElements;
            }

            protected IWebDriver Driver { get; }

            protected ReadOnlyCollection<IWebElement> WebElements { get; }

            public void SelectValue(String value)
            {
                WebElements.Single(we => we.GetAttribute("value") == value).Click();
            }
        }
    }
}
