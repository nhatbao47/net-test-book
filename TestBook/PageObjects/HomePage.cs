using OpenQA.Selenium;
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

        public BookStorePage GoToBookStorePage()
        {
            NavigateTo("books");
            return new BookStorePage(WebDriver);
        }
    }
}
