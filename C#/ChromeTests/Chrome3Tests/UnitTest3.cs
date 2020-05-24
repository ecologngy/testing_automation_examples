using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
namespace Chrome3Tests
{
    public class Tests
    {

        IWebDriver driver;
        string expectedWord = "Test";
        string titleNotRight = "Google";
        string searchPath = "//input[@name='q']";
        string transitElement = "//*[@id=\"rso\"]/div[10]/div/div[1]/a/h3";
        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("http://google.com/");
        }

        [Test]

        [TestCase]
        public void Search_input()
        {
            IWebElement searchInput = driver.FindElement(By.XPath(searchPath));
            searchInput.SendKeys(expectedWord);          
            string innerText = searchInput.GetAttribute("value");

            Assert.AreEqual(expectedWord, innerText);
            
            driver.Close();
        }

        [TestCase]
        public void Transition()
        {
            IWebElement searchInput = driver.FindElement(By.XPath(searchPath));
            searchInput.SendKeys(expectedWord + Keys.Enter);
            string searchUrl = driver.Url;

            IWebElement transit = driver.FindElement(By.XPath(transitElement));
            transit.Click();
            string transitUrl = driver.Url;
            string titleRight = driver.Title;
            Assert.AreNotEqual(searchUrl, transitUrl);
            Assert.AreNotEqual(titleNotRight,titleRight);
            driver.Close();
        }
    }
}