using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase {

        //listagem para manipular e preencher melhor o objeto
        public List<Publisher> Publishers = new List<Publisher>() {
          new Publisher() {
              Id = 1,
              Name = "Test",
              City ="Fortaleza"
          },
           new Publisher() {
              Id = 2,
              Name = "Test2",
              City ="Fortaleza"
           },
            new Publisher() {
              Id = 3,
              Name = "Test3",
              City ="Fortaleza"
          }
        };

        public PublisherController() { }

        [HttpGet]
        public IActionResult Get() {
            return Ok(Publishers);
        }

        [HttpGet("{id}")] 
        
        public IActionResult GetByid(int id) {
            var aluno = Publishers.FirstOrDefault(publisher => publisher.Id == id);
            if (aluno == null) {
                return BadRequest("Editora não existe");
            }
            else {
                return Ok(aluno);
            }
        }


        [HttpPost]
        public IActionResult Post(Publisher publisher) {

           return Ok(publisher);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,Publisher publisher) {

            return Ok(publisher);
        }

       

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            return Ok();
        }



    }
}
