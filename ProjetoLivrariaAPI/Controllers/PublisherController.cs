using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase {

        public readonly IPublisherRepository _repo;
        private readonly DataContext _context;

        public PublisherController(DataContext context , IPublisherRepository repo) {
            _context = context;
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Publishers);
        }

        [HttpGet("{id}")] 
        
        public IActionResult GetByid(int id) {
            var editora = _context.Publishers.FirstOrDefault(publisher => publisher.Id == id);
            if (editora == null) {
                return BadRequest("Editora não existe");
            }
            else {
                return Ok(editora);
            }
        }


        [HttpPost]
        public IActionResult Post(Publisher publisher) {

            _repo.Add(publisher);
            if (_repo.SaveChanges()) {
                return Ok(publisher);
            }
            else {
                return BadRequest("Editora não cadastrado");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,Publisher publisher) {

            var edit = _context.Publishers.AsNoTracking().FirstOrDefault(publisher => publisher.Id == id);
            if (edit == null) {
                return BadRequest("Editora não existe");
            }
            else {
                _repo.Update(publisher);
                if (_repo.SaveChanges()) {
                    return Ok(publisher);
                }
                else {
                    return BadRequest("Editora não atualizado");
                }
            }
        }

       

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var edito = _context.Publishers.AsNoTracking().FirstOrDefault(publisher => publisher.Id == id);
            if (edito == null) {
                return BadRequest("Editora não existe");
            }
            else {
                _repo.Delete(edito);
                if (_repo.SaveChanges()) {
                    return Ok("Editora Removida com sucesso");
                }
                else {
                    return BadRequest("Editora não cadastrado");
                }
            }
        }



    }
}
