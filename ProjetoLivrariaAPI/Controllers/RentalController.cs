using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.Dtos.Book;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.Dtos.Rental;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services;
using ProjetoLivrariaAPI.Services.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjetoLivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService) {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> Get(int id) {
            var result = await _rentalService.GetById(id);
            if (result.IsSucess)
                return Ok(result);
            return NotFound(result);
        }

        
        [HttpGet]
        [Route("Paged")]
        public async Task<ActionResult> GetByIdAsync([FromQuery] Filter rentalFilter) {
            var result = await _rentalService.GetPagedAsync(rentalFilter);
            if (result.IsSucess)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetDash()
        {
            var result = await _rentalService.GetDash();
            if (result.IsSucess)
                return Ok(result);
            return NotFound(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRentalDto createRentalDto) {
            var result = await _rentalService.Create(createRentalDto);
            if (result.IsSucess)
                return StatusCode(201, result);
            return BadRequest(result);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateRentalDto updateRentalDto) {
            var result = await _rentalService.Update(updateRentalDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);

        }
    }
}
