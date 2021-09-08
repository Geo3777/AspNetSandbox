using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksServiceTest
    {
        [Fact]
        public static void BookIdTest()
        {
            // Assume
            var booksService = new BooksService();


            // Act
            booksService.Post(new Book
            {
                title = "Book1",
                author = "Author1",
                Language = "Romanian"
            });

            booksService.Delete(2);
            booksService.Post(new Book
            {
                title = "Book2",
                author = "Author2",
                Language = "English"
            });

            //Assert
            Assert.Equal("Book1", booksService.Get(1).title);
        }
    }
}
