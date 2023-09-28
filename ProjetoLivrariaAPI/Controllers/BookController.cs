using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllBooks(true);
            return Ok(result);
        }
         
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var book = _repo.GetBookById(id , true);
            if (book == null) {
                return BadRequest("Livro não encontrado");
            }
            else {
                return Ok(book);
            }
        }

        [HttpPost]
        public IActionResult Post(CreateBookDto model) {

            var book = _mapper.Map<Book>(model);

            _repo.Add(book);

            if (_repo.SaveChanges()) {

                return Created($"/api/book/{book.Id}", _mapper.Map<Book>(book));

            }
            else {
                return BadRequest("Livro não cadastrado");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBookDto model) {
            var book = _repo.GetBookById(id , true);
            if (book == null) {
                return BadRequest("Livro não existe");
            }
            else {
                _mapper.Map(model, book);

                _repo.Update(book);
                if (_repo.SaveChanges()) {
                    return Created($"/api/book/{model.Id}", book);
                }
                else {
                    return BadRequest("Livro não atualizado");
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var b = _repo.GetBookById(id);
            if (b == null) {
                return BadRequest("Livro não existe");
            }else {
                _repo.Delete(b);
                if(_repo.SaveChanges()) {
                    return Ok("Livro Deletado com sucesso");
                }else {
                    return BadRequest("Livro não excluido");
                }
            }
        }
    }
}
