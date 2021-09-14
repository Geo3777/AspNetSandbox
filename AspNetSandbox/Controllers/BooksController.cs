using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using AspNetSandbox.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetSandbox;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandBox.Controllers
{
    /// <summary>BooksController .
    /// Exposes api CRUD operations for books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksSRepository repository;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        public BooksController(IBooksSRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<ValuesController>

        /// <summary>Gets all the instances of books.</summary>
        /// <returns>Enumerable of book objects.<br /></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(repository.Get());
        }

        // GET api/<ValuesController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = repository.Get(id);
                return Ok(book);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>

        /// <summary>Posts the specified book.</summary>
        /// <param name="book">The value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Post(book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ValuesController>/

        /// <summary>Updates the book at the specified id with the fields of value.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            repository.Put(id, book);
            return Ok();
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            repository.Delete(id);
            return Ok();
        }
    }
}
