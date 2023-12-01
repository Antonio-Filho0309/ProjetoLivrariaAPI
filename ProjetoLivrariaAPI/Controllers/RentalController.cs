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
using System.Net;

namespace ProjetoLivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService) {
            _rentalService = rentalService;
        }

        /// <summary>
        ///  Método para buscar o aluguel por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> Get(int id) {
            var result = await _rentalService.GetById(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// método para paginação
        /// </summary>
        /// <param name="rentalFilter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Paged")]
        public async Task<ActionResult> GetByIdAsync([FromQuery] Filter rentalFilter) {
            var result = await _rentalService.GetPagedAsync(rentalFilter);
            if (result.StatusCode == HttpStatusCode.OK) 
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// método para colocas os alugueis na dashboard
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetDash()
        {
            var result = await _rentalService.GetDash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// metodo para criar e gerar um aluguel
        /// </summary>
        /// <param name="createRentalDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRentalDto createRentalDto) {
            var result = await _rentalService.Create(createRentalDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);
            return BadRequest(result);

        }

        /// <summary>
        /// método para atualizar um aluguel
        /// </summary>
        /// <param name="updateRentalDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateRentalDto updateRentalDto) {
            var result = await _rentalService.Update(updateRentalDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);

        }
    }
}
