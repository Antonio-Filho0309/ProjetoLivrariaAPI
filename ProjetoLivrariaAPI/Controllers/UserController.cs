using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase {


        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService) {
            _userService = userService;
        }
        /// <summary>
        /// Método para listar e mostrar usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _userService.Get();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);

        }

        /// <summary>
        /// Método para encontrar um usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id) {
            var result = await _userService.GetById(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// Método para retornar apenas o nome e o id do usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSelect")]
        public async Task<ActionResult> GetSelect() {
            var result = await _userService.GetSelect();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para paginação 
        /// </summary>
        /// <param name="userFilter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Paged")]
        public async Task<ActionResult> GetByIdAsync([FromQuery] Filter userFilter) {
            var result = await _userService.GetPagedAsync(userFilter);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }



        /// <summary>
        /// Método para criar e gerar usuário
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDto createUserDto) {
            var result = await _userService.Create(createUserDto);
            if (result.IsSucess)
                return Created("",result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para atualizar o usuário
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateUserDto updateUserDto) {
            var result = await _userService.Update(updateUserDto);
            if(result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para Deletar o usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var result = await _userService.Delete(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

       


    }

}





