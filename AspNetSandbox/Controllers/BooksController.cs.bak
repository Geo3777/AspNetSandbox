using System.Collections.Generic;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSandbox.Controllers
{
    /// <summary>
    ///   <br />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.Get();
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return booksService.Get(id);
        }

        /// <summary>Posts the specified value.</summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.Post(value);
        }

        /// <summary>Puts the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.Put(id, value);
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.Delete(id);
        }
    }
}
