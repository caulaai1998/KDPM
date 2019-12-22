using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeDriver Driver = new ChromeDriver();

            Driver.Navigate().GoToUrl("http://www.executeautomation.com/blog");

            //Declare Webrequest
            HttpWebRequest re = null;
            var urls = Driver.FindElements(By.TagName("a")).Take(10);

            Console.WriteLine("Looking at all URLs of ExecuteAutomation site :");
            //Loop through all the urls
            foreach (var url in urls)
            {
                if (!(url.Text.Contains("Email") || url.Text == ""))
                {
                    //Get the url
                    re = (HttpWebRequest)WebRequest.Create(url.GetAttribute("href"));
                    try
                    {
                        var response = (HttpWebResponse)re.GetResponse();
                        System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.StatusCode}");
                    }
                    catch (WebException e)
                    {
                        var errorResponse = (HttpWebResponse)e.Response;
                        System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{errorResponse.StatusCode}");
                    }
                }
            }

            Console.Read();
        }
    }
}
