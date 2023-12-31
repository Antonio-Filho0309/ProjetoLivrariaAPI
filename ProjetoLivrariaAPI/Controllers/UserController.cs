﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.Dtos.User;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services;
using ProjetoLivrariaAPI.Services.Interfaces;
using System.Net;

namespace ProjetoLivrariaAPI.Controllers
{
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
        /// Método para encontrar um usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id) {
            var result = await _userService.GetById(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        /// <summary>
        /// Método para retornar apenas o nome e o id do usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSelect")]
        public async Task<ActionResult> GetSelect() {
            var result = await _userService.GetSelect();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
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
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// método para colocas os usuários na dashboard
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetDash()
        {
            var result = await _userService.GetDash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Método para criar e gerar usuário
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDto createUserDto) {
            var result = await _userService.Create(createUserDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201,result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

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
            if(result.StatusCode == HttpStatusCode.OK)
                return Ok(result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Método para excluir o usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var result = await _userService.Delete(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

       


    }

}





