using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    //post e get não precisam de id 
    public class UserController : ControllerBase {
        public List<User> Users = new List<User>() {
            new User () {
                Id = 1,
                Name = "Batman",
                City = "Fotal",
                Email = "batman@gmail.com",
                Address = "Gotham city"

            },
             new User () {
                Id = 2,
                Name = "Superman",
                City = "Fotal",
                Email = "superman@gmail.com",
                Address = "Metropolis"

            },
              new User () {
                Id = 3,
                Name = "Wonder Woman",
                City = "Fotal",
                Email = "batman@gmail.com",
                Address = "New York"

            }
        };

        public UserController() { }

        [HttpGet]
        public IActionResult Get() {
            return Ok(Users);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetByid(int id) {
            var user = Users.FirstOrDefault(user => user.Id == id);
            if (user == null) {
                return BadRequest("Usuario não existe");
            }
            else {
                return Ok(user);
            }

        }

        [HttpPost]
        public IActionResult Post(User user) {
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user) {
            return Ok(user);
        }
        //não passa nada dentro do OK e só precisa como parametro o id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}
