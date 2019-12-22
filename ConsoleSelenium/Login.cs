using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSelenium
{
    public class Login
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
        public void Login_Success()
        {
            var path = @"D:\test\test1.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            var buttonView = chromeDriver.FindElementByXPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]");
            buttonView.Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var inputEmail = chromeDriver.FindElementById("email");
            inputEmail.SendKeys(lines[0]);

            var inputPassword = chromeDriver.FindElementById("passwd");
            inputPassword.SendKeys(lines[1]);

            var buttonSubmit = chromeDriver.FindElementById("SubmitLogin");
            buttonSubmit.Click();

            Console.WriteLine("Pass");
            Console.WriteLine("Login successfull");
        }

        [Test]
        public void Login_NullEmail()
        {

        }

        [TearDown]
        public void TatWebDriver()
        {
            Console.WriteLine("Close browser");
        }
    }
}
