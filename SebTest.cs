using AutoTestLeson1.NamuDarbai;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Test
{
    class SebTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1");
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement popUp = _driver.FindElement(By.CssSelector("body > div.seb-cookie-consent.seb-cookiemessage > div > div:nth-child(4) > ul > li:nth-child(1) > a > span"));
            wait.Until(d => d.FindElement(By.CssSelector("body > div.seb-cookie-consent.seb-cookiemessage > div > div:nth-child(4) > ul > li:nth-child(1) > a > span")).Displayed);
            wait.Until(d => popUp.Displayed);
            popUp.Click();
            _driver.SwitchTo().Frame(0);
        }

        [Test]

        public static void TestSeb()
        {
            SebPage page = new SebPage(_driver);
            page.InsertIncome("1000");
            page.SelectDropDownValue("Klaipėda");
            page.ClickButton();
            page.CheckResult();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

    }
}
