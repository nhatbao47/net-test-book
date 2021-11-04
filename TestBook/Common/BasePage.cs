using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace TestBook.Common
{
    public class BasePage
    {
        private IWebDriver _webDriver;
        private const int _timeout = 30;
        private By _mainHeader = By.ClassName("main-header");

        public BasePage(IWebDriver driver)
        {
            _webDriver = driver;
        }

        public IWebDriver WebDriver
        {
            get => _webDriver;
        }

        public void OpenUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            WaitUntilPageReady();
        }

        public void NavigateTo(string item)
        {
            var uri = new Uri(WebDriver.Url);
            var url = uri.GetLeftPart(System.UriPartial.Authority) + "/" + item;
            OpenUrl(url);
        }

        public IWebElement FindElement(By locator) => _webDriver.FindElement(locator);

        public IList<IWebElement> FindElements(By locator) => _webDriver.FindElements(locator);

        public void ClickElement(By locator) => FindElement(locator).Click();

        public void SendKeyToElement(By locator, string value) 
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(value);
        }

        public string GetMainHeaderText() => FindElement(_mainHeader).Text;

        public void WaitForElementVisible(By locator)
        {
            var driverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeout));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitUntilPageReady()
        {
            WaitForElementVisible(_mainHeader);
        }
    }
}
