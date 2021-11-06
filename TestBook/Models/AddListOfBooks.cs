using System.Collections.Generic;

namespace TestBook.Models
{
    public class AddListOfBooks
    {
        public string UserId { get; set; }
        public ICollection<CollectionOfIsbn> CollectionOfIsbns { get; set; }
    }
}