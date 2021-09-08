using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{

    public class BooksService : IBooksService
    {
        private List<Book> books;
        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                title = "Monte Cassino",
                Language = "English",
                author = "Sven Hassel"
            });

            books.Add(new Book
            {
                Id = 2,
                title = "Assignment Gestapo",
                Language = "English",
                author = "Sven Hassel"
            });

        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(_ => _.Id == id);
        }

        public void Post(Book value)
        {
           
            int id = CountId.GetNewId();
            value.Id = id;
            books.Add(value);
        }

        public void Put(int id, Book value)
        {
            var index = books.FindIndex(book => book.Id == id);
            books[index] = value;
        }

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
    public static class CountId
    {
        public static int count = 2;

        internal static int GetNewId()
        {
            return ++count;
        }
    }
}
