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

        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public void Post(Book value)
        {
            CountMemory.count = CountMemory.count + 1;
            int id = CountMemory.count;
            //int id = RandomNumber(100,1000);
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
    public static class CountMemory
    {
        public static int count = 2;
        
    }
}
