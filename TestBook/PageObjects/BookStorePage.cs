using OpenQA.Selenium;
using TestBook.Common;

namespace TestBook.PageObjects
{
    public class BookStorePage: BasePage
    {
        public BookStorePage(IWebDriver driver): base(driver) { }

        
        private By _addToCollectionButton = By.XPath("//button[text()='Add To Your Collection']");
        private By _bookImageCell = By.CssSelector("div[role='gridcell'] > img");

        public void AddBookToCollection() => ClickElement(_addToCollectionButton);

        public void ClickBookLink(string bookTitle)
        {
            var bookLink = FindElement(By.LinkText(bookTitle));
            bookLink.Click();
            WaitUntilPageReady();
        }

        public ProfilePage GoToProfile()
        {
            NavigateTo("profile");
            return new ProfilePage(WebDriver);
        }

        public int CountCurrentBooksOnTable() => FindElements(_bookImageCell).Count;
    }
}
