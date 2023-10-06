using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;

namespace ProjetoLivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>

        public readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método Responsável para listar todos os usuários
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get() {

            var users = _repo.GetAllUsers();

          
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));

        }

        /// <summary>
        /// Método Responsável para buscar o usuário pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Método Responsável para Cadastrar os usuários 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(CreateUserDto model) {

            var user = _mapper.Map<User>(model);

            _repo.Add(user);
            if (_repo.SaveChanges()) {
                return Created($"/api/user/{user.Id}" , _mapper.Map<UserDto>(user));
            }
            else {
                return BadRequest("Usuário não cadastrado");
            }

        }

        /// <summary>
        /// Método Responsável para atualizar os cadastros do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserDto model) {
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
        
        /// <summary>
        /// Método Resposável para Deletar o cadastro do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
