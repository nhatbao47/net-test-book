using NUnit.Framework;
using TestBook.Common;
using TestBook.PageObjects;

namespace TestBook.TestCases
{
    [TestFixture]
    public class DeleteBookTests: BaseTest
    {
        private const string _bookTitle = "Speaking JavaScript";
        private const string _bookIsbn = "9781449365035";
        private ProfilePage _profilePage;

        [SetUp]
        public void Setup()
        {
            SetupAll();
            DeleteAddedBooksOfUser();
            AddUserBooks(_bookIsbn);
            _profilePage = UserLoginsIntoApplication();
        }

        [Test]
        public void DeleteBookSuccessfully()
        {
            _profilePage.SearchBook(_bookTitle);
            _profilePage.ClickDeleteBookButton();
            _profilePage.AcceptConfirmationOnModal();
            _profilePage.WaitForAlertVisible();

            Assert.IsTrue(_profilePage.IsAlertShown("Book deleted."), "The alert is not shown");
            Assert.IsFalse(_profilePage.IsLinkTextExists(_bookTitle), $"The '{_bookTitle}' book is not exists");
        }
    }
}