namespace TestBook.Models
{
    public class CollectionOfIsbn
    {
        private string _isbn;
        public CollectionOfIsbn(string isbn) => _isbn = isbn;
        public string Isbn
        {
            get => _isbn;
            set => _isbn = value;
        }
    }
}
