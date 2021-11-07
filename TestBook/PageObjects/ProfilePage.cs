using OpenQA.Selenium;
using TestBook.Common;

namespace TestBook.PageObjects
{
    public class ProfilePage: BasePage
    {
        public ProfilePage(IWebDriver driver): base(driver) { }

        private By _userNameLabel = By.Id("userName-value");
        private By _deleteBookButton = By.CssSelector("span[title='Delete']");
        private By _okButtonModal = By.Id("closeSmallModal-ok");

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

        public void ClickDeleteBookButton() => ClickElement(_deleteBookButton);

        public void AcceptConfirmationOnModal()
        {
            WaitForElementVisible(_okButtonModal);
            ClickElement(_okButtonModal);
        }
    }
}