using NUnit.Framework;
using TestBook.PageObjects;

namespace TestBook.TestCases
{
    [TestFixture]
    public class AddBookTests: BaseTest
    {
        private ProfilePage _profilePage;
        private BookStorePage _bookStorePage;

        [SetUp]
        public void Setup()
        {
            SetupAll();
            DeleteAddedBooksOfUser();
            _profilePage = UserLoginsIntoApplication();
            _bookStorePage = _profilePage.GotoBookStore();
        }

        [Test]
        public void AddBookToYourCollection()
        {
            var book = "Git Pocket Guide";
            _bookStorePage.SearchBook(book);
            _bookStorePage.ClickBookLink(book);
            _bookStorePage.AddBookToCollection();
            _bookStorePage.WaitForAlertVisible();
            Assert.IsTrue(_bookStorePage.IsAlertShown("Book added to your collection."), "The alert is not shown");

            _profilePage = _bookStorePage.GoToProfile();
            Assert.IsTrue(_profilePage.IsLinkTextExists(book), $"The '{book}' book is not exists");
        }
    }
}