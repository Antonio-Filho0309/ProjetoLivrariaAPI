using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Dtos.Publisher;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

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

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] CreatePublisherDto createPublisherDto) {
            var result = await _publisherService.Create(createPublisherDto);
            if (result.IsSucess) 
                return Ok(result);
            return BadRequest(result);
        }
        

       
    

    }
}
