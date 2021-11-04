using NUnit.Framework;
using OpenQA.Selenium;
using TestBook.Common;
using TestBook.PageObjects;

namespace TestBook.TestCases
{
    public class LoginTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = WebDriverManagers.CreateBrowserDriver(Browser.Chrome);
            _driver.Url = Constants.AppUrl;
        }

        [Test]
        public void AddBookToYourCollection()
        {
            var homePage = new HomePage(_driver);
            var loginPage = homePage.GoToLoginPage();
            var profilePage = loginPage.Login(Constants.Username, Constants.Password);
            profilePage.WaitForLoading();
            Assert.AreEqual(profilePage.GetLoggedUserName(), Constants.Username);

            var bookStorePage = profilePage.GotoBookStore();
            Assert.AreEqual("Book Store", bookStorePage.GetMainHeaderText());

            var book = "Git Pocket Guide";
            bookStorePage.SearchBook(book);
            bookStorePage.ClickBookLink(book);
            bookStorePage.AddBookToCollection();
            Assert.IsTrue(bookStorePage.IsAlertShown("Book added to your collection."));

            profilePage = bookStorePage.GoToProfile();
            Assert.IsTrue(profilePage.IsBookExists(book));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}