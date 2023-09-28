using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase {

        public readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult Get() {

            var users = _repo.GetAllUsers();

          
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));

        }

        [HttpGet("{id}")]

        public IActionResult GetByid(int id) {
            var user = _repo.GetlUserById(id);
            var userDto = _mapper.Map<UserDto>(user);

            if (user == null) {
                return BadRequest("Usuario não existe");
            }
            else {
                return Ok(userDto);
            }

        }

        [HttpPost]
        public IActionResult Post(CreateUserDto model) {

            var user = _mapper.Map<User>(model);

            _repo.Add(user);
            if (_repo.SaveChanges()) {
                return Created($"/api/user/{user.Id}" , _mapper.Map<User>(user));
            }
            else {
                return BadRequest("Usuário não cadastrado");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserDto model) {
            var user = _repo.GetlUserById(id);
            if (user == null) {
                return BadRequest("Usuário não encontrado");
            }
            else {
                _mapper.Map(model, user);

                _repo.Update(user);
                if (_repo.SaveChanges()) {
                    return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
                }
                else {
                    return BadRequest("Usuário não Atualizado");
                }

            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var user = _repo.GetlUserById(id);
            if (user == null) {
                return BadRequest("Usuário não encontrado");
            }
            else {
                _repo.Delete(user);
                if (_repo.SaveChanges()) {
                    return Ok("Usuário deletado com sucesso");
                }
                else {
                    return BadRequest("Usuário não deletado");
                }

            }
        }
    }
}
