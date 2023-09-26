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

        public PublisherController(IPublisherRepository repo) {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get() {
            var result= _repo.GetAllPublishers();
            return Ok(result);
        }

        [HttpGet("{id}")] 
        
        public IActionResult GetByid(int id) {
            var publisher = _repo.GetlPublisherById(id);
            if (publisher == null) {
                return BadRequest("Editora não existe");
            }
            else {
                return Ok(publisher);
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

            var pub = _repo.GetlPublisherById(id);
            if (pub == null) {
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

            var publi = _repo.GetlPublisherById(id);
            if (publi == null) {
                return BadRequest("Editora não existe");
            }
            else {
                _repo.Delete(publi);
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
