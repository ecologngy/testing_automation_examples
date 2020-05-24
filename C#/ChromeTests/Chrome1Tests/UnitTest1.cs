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
namespace Chrome1Tests
{
    public class Tests
    {
        IWebDriver driver;
        string titleRight = "Google";
        string[] elementRight = new string[6];
        [SetUp]
        public void Setup()
        {
            elementRight[0] = "//*[@id=\"hplogo\"]";
            elementRight[1] = "//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[2]/input";
            elementRight[2] = "//*[@id=\"tsf\"]/div[2]/div[1]/div[3]/center/input[1]";
            elementRight[3] = "//*[@id=\"tsf\"]/div[2]/div[1]/div[3]/center/input[2]";
            elementRight[4] = "//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[3]/div[3]";
            elementRight[5] = "//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[3]/div[2]/span";
          
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("http://google.com/");
        }


        [Test]

        [TestCase]
        public void Title_is_Google()
        {
            string title = driver.Title;
            Assert.AreEqual(titleRight,title);
            driver.Close();
        }
        
        [TestCase]
        public void Elements_is_displayed()
        {
            int count = 0;
            Boolean displayedRight = false;

            IWebElement[] findElements = new IWebElement[6];
            for (int i = 0; i < elementRight.Length; i++)
             {
              findElements[i] = driver.FindElement(By.XPath(elementRight[i]));
            Boolean displayed = findElements[i].Displayed;
            if (displayed == true)
             {
                count++;
             }
             }

                if (count == elementRight.Length)
                {
                 displayedRight = true;
                }

            Assert.IsTrue(displayedRight);
            driver.Close();

        }

        [TestCase]
        public void Elements_is_enabled()
        {
            int count = 0;
            Boolean enabledRight = false;

            IWebElement[] findElement = new IWebElement[6];
            for (int i = 0; i < elementRight.Length; i++)
            {
                findElement[i] = driver.FindElement(By.XPath(elementRight[i]));
                Boolean enabled = findElement[i].Enabled;
                if (enabled == true)
                {
                    count++;
                }
            }

            if (count == elementRight.Length)
            {
                enabledRight = true;
            }

            Assert.IsTrue(enabledRight);
            driver.Close();

        }
    }
}