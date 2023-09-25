﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //post e get não precisam de id 
    public class UserController : ControllerBase {

        public readonly IUserRepository _repo;
        private readonly DataContext _context;

        public UserController(DataContext context, IUserRepository repo) {
            _repo = repo;
            _context = context;
        }


      
        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Users);
        }

        [HttpGet("{id}")]

        public IActionResult GetByid(int id) {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user == null) {
                return BadRequest("Usuario não existe");
            }
            else {
                return Ok(user);
            }

        }

        [HttpPost]
        public IActionResult Post(User user) {
            _repo.Add(user);
            if(_repo.SaveChanges()) {
                return Ok(user);
            }else {
                return BadRequest("Usuário não cadastrado");
            }
          
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user) {
            var usu = _context.Users.AsNoTracking().FirstOrDefault(user => user.Id == id);
            if (usu == null) {
                return BadRequest("Usuário não encontrado");
            }
            else {
                _repo.Update(user);
                if (_repo.SaveChanges()) {
                    return Ok(user);
                }
                else {
                    return BadRequest("Usuário não Atualizado");
                }

            }
        }
        // e só precisa como parametro o id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var user = _context.Users.AsNoTracking().FirstOrDefault(user => user.Id == id);
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
