using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase {

        public List<Rental> Rentals = new List<Rental>() {
            new Rental() {
                Id = 1,
                
            },
             new Rental() {
                Id = 2,

            },
              new Rental() {
                Id = 3,

            }
        };

        [HttpGet]
        public IActionResult Get() {
            return Ok(Rentals);
        }

        [HttpGet("{id}")]

        public IActionResult GetByid(int id) {
            var aluno = Rentals.FirstOrDefault(rental => rental.Id == id);
            if (aluno == null) {
                return BadRequest("Editora não existe");
            }
            else {
                return Ok(aluno);
            }
        }


        [HttpPost]
        public IActionResult Post(Rental rental) {

            return Ok(rental);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rental rental) {

            return Ok(rental);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            return Ok();
        }
    }
}
