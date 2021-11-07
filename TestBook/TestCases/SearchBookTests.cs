using NUnit.Framework;
using TestBook.Common;
using TestBook.PageObjects;

namespace TestBook.TestCases
{
    [TestFixture]
    public class SearchBookTests: BaseTest
    {
        private BookStorePage _bookStorePage;

        [SetUp]
        public void Setup()
        {
            SetupWebDriver();
            var homePage = new HomePage(webDriver);
            _bookStorePage = homePage.GoToBookStorePage();
        }

        [TestCase("design", "Learning JavaScript Design Patterns", "Designing Evolvable Web APIs with ASP.NET")]
        [TestCase("Design", "Learning JavaScript Design Patterns", "Designing Evolvable Web APIs with ASP.NET")]
        public void SearchBookMultipleResults(string keyword, params string[] expectedResults)
        {
            _bookStorePage.SearchBook(keyword);

            foreach (var book in expectedResults)
            {
                Assert.IsTrue(_bookStorePage.IsLinkTextExists(book), $"Not found '{book}' book");
            }

            var bookCount = _bookStorePage.CountCurrentBooksOnTable();
            Assert.AreEqual(expectedResults.Length, bookCount, $"There are {bookCount} books");
        }
    }
}