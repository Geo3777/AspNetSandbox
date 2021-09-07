using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    class BooksServiceTest
    {
        public static void ShouldHaveLondonCoordinates()
        {
            // Assume
            var booksService = new BooksService();


            // Act
            booksService.Post(new Book
            {
                title = "Psyho ABC",
                author = "John",
                Language = "Romanian"
            });

            booksService.Delete(2);
            booksService.Post(new Book
            {
                title = "The art of not giving a f..",
                author = "Tom example",
                Language = "English"
            });

            //Assert
            Assert.Equal("Psyho ABC", booksService.Get(3).title);
        }
    }
}
