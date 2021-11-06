using OpenQA.Selenium;
using TestBook.Common;

namespace TestBook.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private By userNameTextBox = By.Id("userName");
        private By passwordTextBox = By.Id("password");
        private By loginButton = By.Id("login");

        public ProfilePage Login(string userName, string password)
        {
            SendKeyToElement(userNameTextBox, userName);
            SendKeyToElement(passwordTextBox, password);
            ClickElement(loginButton);
            return new ProfilePage(WebDriver);
        }
    }
}
