using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TestBook.Models;
using Tiny.RestClient;

namespace TestBook.Common
{
    public class RestClient
    {
        private TinyRestClient _client;

        public RestClient(HttpClient httpClient, string apiEndpoint)
        {
            _client = new TinyRestClient(httpClient, apiEndpoint);
            _client.Settings.Formatters.OfType<JsonFormatter>().First().UseCamelCase();
        }

        public void SetAuthentication(string username, string password)
        {
            _client.Settings.DefaultHeaders.AddBasicAuthentication(username, password);
        }

        public void AddListOfBooks(string userId, ICollection<CollectionOfIsbn> collectionOfIsbns)
        {
            const string bookRoute = "BookStore/v1/Books";
            var model = new AddListOfBooks()
            {
                UserId = userId,
                CollectionOfIsbns = collectionOfIsbns
            };
            _client.PostRequest(bookRoute, model).ExecuteAsync();
        }

        public void DeleteBooks(string userId)
        {
            string bookRoute = $"BookStore/v1/Books?UserId={userId}";
            _client.DeleteRequest(bookRoute).ExecuteAsync();
        }
    }
}