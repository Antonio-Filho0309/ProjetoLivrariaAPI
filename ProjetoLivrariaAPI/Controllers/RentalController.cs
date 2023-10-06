using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.Rental;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjetoLivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase {

        private readonly IRentalRepository _repo;
        private readonly IMapper _mapper;

        public RentalController(IRentalRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() {
            var rentals = _repo.GetAllRentals(true, true);

            return Ok(_mapper.Map<IEnumerable<RentalDto>>(rentals));
        }

        [HttpGet("{id}")]

        public IActionResult GetByid(int id) {
            var rental = _repo.GetRentalById(id, true , true);
            var rentalDto = _mapper.Map<RentalDto>(rental);
            if (rental == null) {
                return BadRequest("Aluguel não encontrado");
            }
            else {
                return Ok(rentalDto);
            }
        }


        [HttpPost]
        public IActionResult Post(CreateRentalDto model) {

            var rental = _mapper.Map<Rental>(model);
            rental.Status = "Pendente";

            _repo.Add(rental);
            if (_repo.SaveChanges()) {
                return Created($"/api/rental/{rental.Id}", _mapper.Map<Rental>(rental));
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
