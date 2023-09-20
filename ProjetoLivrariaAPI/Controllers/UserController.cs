using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    //post e get não precisam de id 
    public class UserController : ControllerBase {

        private readonly DataContext _context;

        public UserController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Users);
        }

        [HttpGet("byId")]

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
            _context.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user) {
            var usu = _context.Users.AsNoTracking().FirstOrDefault(user => user.Id == id);
            if (usu == null) {
                return BadRequest("Usuário não encontrado");
            }
            else {
                _context.Update(user);
                _context.SaveChanges();
                return Ok(user);
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
                _context.Remove(user);
                _context.SaveChanges();
                return Ok("Usuário Removido com Sucesso!");
            }
        }
    }
}
