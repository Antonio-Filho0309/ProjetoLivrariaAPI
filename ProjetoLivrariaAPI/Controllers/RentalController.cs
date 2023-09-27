using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase {

        private readonly IRentalRepository _repo;

        public RentalController(IRentalRepository repo) {
           _repo = repo;
        }

        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllRentals(true , true);

            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetByid(int id) {
                var rental = _repo.GetRentalById(id);
                if (rental == null) {
                    return BadRequest("Aluguel não encontrado");
                }
                else {
                    return Ok(rental);
                }
            }


        [HttpPost]
        public IActionResult Post(Rental rental) {

            _repo.Add(rental);
            if (_repo.SaveChanges()) {
                return Ok(rental);
            }
            else {
                return BadRequest("Aluguel não cadastrado");
            };
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rental rental) {

            var rent = _repo.GetRentalById(id);

            if (rent == null) {
                return BadRequest("Aluguel não existe");
            }
            else {
                _repo.Update(rental);
                if (_repo.SaveChanges()) {
                    return Ok(rental);
                }
                else {
                    return BadRequest("Aluguel não atualizado");
                }
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var rental = _repo.GetRentalById(id);
            if (rental == null) {
                return BadRequest("Aluguel não existe");
            }
            else {
                _repo.Delete(rental);
                if (_repo.SaveChanges()) {
                    return Ok("Aluguel Deletado com sucesso");
                }
                else {
                    return BadRequest("Aluguel não excluido");
                }
            }
        }
    }
}
