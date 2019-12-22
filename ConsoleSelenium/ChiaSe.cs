using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSelenium
{
   public class ChiaSe
    {
        ChromeDriver chromeDriver = new ChromeDriver();
        string Url = "http://automationpractice.com/index.php";
     


        [SetUp]
        public void KhoiTaoWeb()
        {
            chromeDriver.Url = Url;
            chromeDriver.Navigate();

            Console.WriteLine("Open Web");
        }
        
        [Test]
        public void ChiaSe_Test()
        {
            var buttonView = chromeDriver.FindElementByXPath("//*[@id=\"homefeatured\"]/li[1]/div/div[1]/div/a[1]/img");
            buttonView.Click();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var buttonChiaSe = chromeDriver.FindElementById("send_friend_button");
            buttonChiaSe.Click();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            var inputName = chromeDriver.FindElementById("friend_name");
            inputName.SendKeys("Tuan");

            var inputEmail = chromeDriver.FindElementById("friend_email");
            inputEmail.SendKeys("tuancbdoan@gmail.com");

            var buttonSendMail = chromeDriver.FindElementById("sendEmail");
            buttonSendMail.Click();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var buttonOki = chromeDriver.FindElementByXPath("//*[@id=\"product\"]/div[2]/div/div/div/p[2]/input");
            buttonOki.Click();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Console.WriteLine("Execute test");
            Console.WriteLine("Share successful");

        }

        [TearDown]
        public void TatWebDriver()
        {
            Console.WriteLine("Close browser");
        }

    }
}
