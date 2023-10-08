using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService) {

            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            var result =  await _bookService.Get();
            if(result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }




    }
}
