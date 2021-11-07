using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Net.Http;
using TestBook.Models;
using TestBook.PageObjects;

namespace TestBook.Common
{
    public class BaseTest
    {
        protected IWebDriver webDriver;
        protected RestClient client;

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }

        public void SetupAll()
        {
            SetupWebDriver();
            SetupApiClient();
        }

        public void SetupApiClient()
        {
            client = new RestClient(new HttpClient(), Constants.AppUrl);
            client.SetAuthentication(Constants.Username, Constants.Password);
        }

        public void SetupWebDriver()
        {
            webDriver = WebDriverManagers.CreateBrowserDriver(Browser.Chrome);
            webDriver.Url = Constants.AppUrl;
        }


        public ProfilePage UserLoginsIntoApplication()
        {
            var homePage = new HomePage(webDriver);
            var loginPage = homePage.GoToLoginPage();
            var profilePage = loginPage.Login(Constants.Username, Constants.Password);
            profilePage.WaitForLoading();
            return profilePage;
        }

        public void AddUserBooks(params string[] isbns)
        {
            var collectionOfIsbns = new List<CollectionOfIsbn>();
            foreach (var isbn in isbns)
            {
                collectionOfIsbns.Add(new CollectionOfIsbn(isbn));
            }
            client.AddListOfBooks(Constants.UserId, collectionOfIsbns);
        }

        public void DeleteAddedBooksOfUser()
        {
            client.DeleteBooks(Constants.UserId);
        }
    }
}
