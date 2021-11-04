using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestBook.Common;

namespace TestBook.PageObjects
{
    public class BookStorePage: BasePage
    {
        public BookStorePage(IWebDriver driver): base(driver) { }

        private By _searchTextBox = By.Id("searchBox");
        private By _addToCollectionButton = By.XPath("//button[text()='Add To Your Collection']");

        public void SearchBook(string title) => SendKeyToElement(_searchTextBox, title);

        public void ClickBookLink(string bookTitle)
        {
            var bookLink = FindElement(By.LinkText(bookTitle));
            bookLink.Click();
        }

        public void AddBookToCollection() => ClickElement(_addToCollectionButton);

        public bool IsAlertShown(string message)
        {
            var alertDialog = WebDriver.SwitchTo().Alert();
            var text = alertDialog.Text;
            alertDialog.Accept();
            return Equals(message, text);
        }

        public ProfilePage GoToProfile()
        {
            NavigateTo("profile");
            return new ProfilePage(WebDriver);
        }
    }
}
