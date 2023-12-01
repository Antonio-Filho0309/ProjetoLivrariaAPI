
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.Dtos.Publisher;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Services.Interfaces;
using System.Net;

namespace ProjetoLivrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {

        public readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
           
        }

        /// <summary>
        /// Método para buscar a editora por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id) {
            var result = await _publisherService.GetById(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        /// <summary>
        /// Método para retornar somente id e nome da editora
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSelect")]
        public async Task<ActionResult> GetSelect() {
            var result = await _publisherService.GetSelect();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// método para paginação
        /// </summary>
        /// <param name="publisherFilter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Paged")]
        public async Task<ActionResult> GetByIdAsync([FromQuery] Filter publisherFilter) {
            var result = await _publisherService.GetPagedAsync(publisherFilter);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// método colocar as editoras para dashboard
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetDash()
        {
            var result = await _publisherService.GetDash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Método parar criar  e gerar uma editora
        /// </summary>
        /// <param name="createPublisherDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePublisherDto createPublisherDto) {
            var result = await _publisherService.Create(createPublisherDto);
            if (result.StatusCode == HttpStatusCode.OK) 
                return StatusCode(201,result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para atualizar a  editora 
        /// </summary>
        /// <param name="updatePublisherDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdatePublisherDto updatePublisherDto) {
            var result = await _publisherService.Update(updatePublisherDto);
            if(result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Método para excluir a editora
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var result = await _publisherService.Delete(id);
            if(result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
       
    

    }
}
