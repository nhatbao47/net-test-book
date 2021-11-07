using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestBook.Common
{
    public class BasePage
    {
        private IWebDriver _webDriver;
        private const int _timeout = 30;
        private By _mainHeader = By.ClassName("main-header");
        private By _searchTextBox = By.Id("searchBox");

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

        public void WaitForElementVisible(By locator)
        {
            var driverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeout));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForAlertVisible()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void WaitUntilPageReady()
        {
            WaitForElementVisible(_mainHeader);
        }

        public void SearchBook(string title) => SendKeyToElement(_searchTextBox, title);

        public bool IsLinkTextExists(string title)
        {
            try
            {
                return FindElement(By.LinkText(title)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertShown(string message)
        {
            var alertDialog = WebDriver.SwitchTo().Alert();
            var text = alertDialog.Text;
            alertDialog.Accept();
            return Equals(message, text);
        }
    }
}