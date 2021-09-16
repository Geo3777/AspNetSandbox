using System;
using AspNetSandbox;
using AspNetSandbox.DTOs;
using AspNetSandbox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
            Book BookList = (Book)repository.Get();
            ReadBookDto booksDto = mapper.Map<ReadBookDto>(BookList);
            return Ok(booksDto);

            // return Ok(repository.Get());
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
                Book book = repository.Get(id);
                ReadBookDto bookDto = mapper.Map<ReadBookDto>(book);
                return Ok(bookDto);
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.Put(id, book);
            hubContext.Clients.All.SendAsync("BookUpdated", bookDto);
            return Ok();
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = repository.Get(id);
            ReadBookDto bookDto = mapper.Map<ReadBookDto>(book);
            repository.Delete(bookDto.Id);
            hubContext.Clients.All.SendAsync("BookDelete", id);
            return Ok();
        }
    }
}
