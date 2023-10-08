using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService) {

            _bookService = bookService;
        }

        /// <summary>
        /// Método para buscar os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _bookService.Get();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
        
        /// <summary>
        /// Método para buscar o livro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id) {
            var result = await _bookService.GetById(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para criar e gerar o livro
        /// </summary>
        /// <param name="createBookDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateBookDto createBookDto) {
            var result = await _bookService.Create(createBookDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para atualizar o livro
        /// </summary>
        /// <param name="updateBookDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateBookDto updateBookDto) {
            var result = await _bookService.Update(updateBookDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para excluir um livro 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var result = await _bookService.Delete(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
