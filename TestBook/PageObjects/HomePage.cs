using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestBook.Common;

namespace TestBook.PageObjects
{
    public class HomePage: BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public LoginPage GoToLoginPage()
        {
            NavigateTo("login");
            return new LoginPage(WebDriver);
        }
    }
}
