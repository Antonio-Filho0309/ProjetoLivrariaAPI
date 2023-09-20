using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase {

        public List<Book> Books = new List<Book>() {
            new Book() {
                 Id = 2,
              Name = "Test3",
            },
             new Book() {
                 Id = 4,
              Name = "Test4",
            },
              new Book() {
                 Id = 3,
              Name = "Test5",
            },


        };

        public BookController() { }

        [HttpGet]
        public IActionResult Get() {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null) {
                return BadRequest("Livro não encontrado");
            }else {
                return Ok(book);
            }
        }

        [HttpPost]
        public IActionResult Post(Book book) {
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Put( int id ,Book book) {
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}
