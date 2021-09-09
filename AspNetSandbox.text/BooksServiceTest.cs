using AspNetSandbox.Models;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// this is test suit for books api.
    /// </summary>
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
                Title = "Book1",
                Author = "Author1",
                Language = "Romanian",
            });

            booksService.Delete(2);
            booksService.Post(new Book
            {
                Title = "Book2",
                Author = "Author2",
                Language = "English",
            });

            // Assert
            Assert.Equal("Book1", booksService.Get(3).Title);
        }
    }
}
