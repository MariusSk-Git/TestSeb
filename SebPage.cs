using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.NamuDarbai
{
    class SebPage
    {
        private static IWebDriver _driver;

        private IWebElement _incomeInput => _driver.FindElement(By.CssSelector("#income"));
        private SelectElement _cityDropDown => new SelectElement(_driver.FindElement(By.Id("city")));
        private IWebElement _button => _driver.FindElement(By.Id("calculate"));
        private IWebElement _actualResult => _driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 > div.row > div > div:nth-child(5) > div > span > strong"));

        public SebPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void InsertIncome(string income)
        {
            _incomeInput.Clear();
            _incomeInput.SendKeys(income);
        }

        public void SelectDropDownValue(string city)
        {
            _cityDropDown.SelectByText(city);
        }
        public void ClickButton()
        {
            _button.Click();
        }

        public void CheckResult()
        {
            Assert.IsTrue(CompareResult(), "Suma mazesne nei 75000");
        }

        private bool CompareResult()
        {
            string actualResult = _actualResult.Text;
            actualResult = actualResult.Replace(" ", "");

            int result = Convert.ToInt32(actualResult);
            
            if (result > 75000)
            {
                return true;
            }
            return false;
        }
    }
}
