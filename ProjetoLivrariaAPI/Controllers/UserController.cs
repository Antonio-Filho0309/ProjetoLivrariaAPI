using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

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

        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        /// <summary>
        /// Método Responsável para listar todos os usuários
        /// </summary>
        /// <returns></returns>

       

        /// <summary>
        /// Método Responsável para buscar o usuário pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

       

        /// <summary>
        /// Método Responsável para Cadastrar os usuários 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
         public async Task<ActionResult> Post([FromBody] CreateUserDto createUserDto) {
            var result = await _userService.Create(createUserDto);
            if(result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        }

        /// <summary>
        /// Método Responsável para atualizar os cadastros do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        
       
        
        /// <summary>
        /// Método Resposável para Deletar o cadastro do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
       
    
}
