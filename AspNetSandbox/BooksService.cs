using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService
    {
        private List<Book> books;
        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                title = "War Hero",
                Language = "English",
                author = "Sven"
            });

            books.Add(new Book
            {
                Id = 2,
                title = "War Hero",
                Language = "English",
                author = "Sven"
            });

        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void Post(Book value)
        {
            int id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }

        public void Put(int id, string value)
        {

        }

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
