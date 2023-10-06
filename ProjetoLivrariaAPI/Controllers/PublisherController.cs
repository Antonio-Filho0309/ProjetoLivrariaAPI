using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Dtos.Publisher;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;

namespace ProjetoLivrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {

        public readonly IPublisherRepository _repo;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _repo.GetAllPublishers();
            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));
        }

        [HttpGet("{id}")]

        public IActionResult GetByid(int id)
        {
            var publisher = _repo.GetlPublisherById(id);
            var publisherDto = _mapper.Map<PublisherDto>(publisher);

            if (publisher == null)
            {
                return BadRequest("Editora não existe");
            }
            else
            {
                return Ok(publisherDto);
            }
        }


        [HttpPost]
        public IActionResult Post(CreatePublisherDto model)
        {

            var publisher = _mapper.Map<Publisher>(model);

            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publisher/{publisher.Id}", _mapper.Map<Publisher>(publisher));
            }
            else
            {
                return BadRequest("Editora não cadastrada");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdatePublisherDto model)
        {

            var publisher = _repo.GetlPublisherById(id);
            if (publisher == null)
            {
                return BadRequest("Editora não existe");
            }
            else
            {
                _mapper.Map(model, publisher);

                _repo.Update(publisher);
                if (_repo.SaveChanges())
                {
                    return Created($"/api/publisher/{model.Id}", _mapper.Map<Publisher>(publisher));
                }
                else
                {
                    return BadRequest("Editora não atualizada");
                }
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var publisher = _repo.GetlPublisherById(id);
            if (publisher == null)
            {
                return BadRequest("Editora não existe");
            }
            else
            {
                _repo.Delete(publisher);
                if (_repo.SaveChanges())
                {
                    return Ok("Editora Removida com sucesso");
                }
                else
                {
                    return BadRequest("Editora não cadastrado");
                }
            }
        }



    }
}
