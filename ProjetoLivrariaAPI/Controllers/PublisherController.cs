using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase {

        private readonly DataContext _context;

        public PublisherController(DataContext context) {
            _context = context;
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
            _context.Add(publisher);
            _context.SaveChanges();
            return Ok(publisher);       
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,Publisher publisher) {

            var edit = _context.Publishers.AsNoTracking().FirstOrDefault(publisher => publisher.Id == id);
            if (edit == null) {
                return BadRequest("Editora não existe");
            }
            else {
                _context.Update(publisher);
                _context.SaveChanges();
                return Ok(publisher);
            }
        }

       

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var edito = _context.Publishers.AsNoTracking().FirstOrDefault(publisher => publisher.Id == id);
            if (edito == null) {
                return BadRequest("Editora não existe");
            }
            else {
                _context.Remove(edito);
                _context.SaveChanges();
                return Ok("Editora Removida com Sucesso");
            }
        }



    }
}
