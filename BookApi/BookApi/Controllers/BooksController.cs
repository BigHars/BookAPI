using BooksLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksRepository _data;

        public BooksController(BooksRepository data)
        {
            _data = data;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Book> books = _data.GetAllBooks();
                return Ok(books);
            }
            catch (ArgumentNullException)
            {
                return NoContent();
            }
        }

        // GET api/<BooksController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Book book =  _data.GetBookById(id);
                return Ok(book);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] Book value)
        {
            try
            {
                Book book = _data.AddBook(value);
                return Created("A new book was created: ", value);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Book value)
        {
            try
            {
                Book book = _data.UpdateBook(id, value);
                return Created("The requesteed book has been updated to: ", value);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                Book book = _data.RemoveBook(id);
                return Ok(book);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
        }
    }
}
