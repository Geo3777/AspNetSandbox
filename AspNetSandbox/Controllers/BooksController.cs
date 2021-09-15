using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using AspNetSandbox.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetSandbox;
using Microsoft.AspNetCore.SignalR;
using AspNetSandbox.DTOs;
using AutoMapper;

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
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        public BooksController(IBooksSRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.hubContext = hubContext;
            this.mapper = mapper;
            this.repository = repository;
        }

        // GET: api/<ValuesController>

        /// <summary>Gets all the instances of books.</summary>
        /// <returns>Enumerable of book objects.<br /></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.Get());
        }

        // GET api/<ValuesController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
        /// <param name="bookDto">The value.</param>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.Post(book);
                hubContext.Clients.All.SendAsync("BookCreated", bookDto);
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
        /// <param name="bookDto"></param>
        /// <param name="book">The value.</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.Put(id, book);
            hubContext.Clients.All.SendAsync("BookUpdate", bookDto);
            return Ok();
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            hubContext.Clients.All.SendAsync("BookDelete", id);
            return Ok();
        }
    }
}
