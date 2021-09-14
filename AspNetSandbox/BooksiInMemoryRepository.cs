using AspNetSandbox.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetSandbox
{
    public class BooksiInMemoryRepository : IBooksSRepository
    {
        private List<Book> books;

        public BooksiInMemoryRepository()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Monte Cassino",
                Language = "English",
                Author = "Sven Hassel",
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "Assignment Gestapo",
                Language = "English",
                Author = "Sven Hassel",
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
        public static int Count = 2;

        internal static int GetNewId()
        {
            return ++Count;
        }
    }
}
