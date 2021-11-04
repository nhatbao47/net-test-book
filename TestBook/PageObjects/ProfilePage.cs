using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestBook.Common;

namespace TestBook.PageObjects
{
    public class ProfilePage: BasePage
    {
        public ProfilePage(IWebDriver driver): base(driver) { }

        private By _userNameLabel = By.Id("userName-value");

        public void WaitForLoading() => WaitForElementVisible(_userNameLabel);

        public string GetLoggedUserName()
        {
            var userName = FindElement(_userNameLabel);
            return userName.Displayed ? userName.Text : string.Empty;
        }

        public BookStorePage GotoBookStore()
        {
            NavigateTo("books");
            return new BookStorePage(WebDriver);
        }

        public bool IsBookExists(string title)
        {
            var book = FindElement(By.LinkText(title));
            return book.Displayed;
        }
    }
}
