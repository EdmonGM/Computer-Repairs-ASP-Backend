using Computer_Repairs.Data;
using Computer_Repairs.Dtos.User;
using Computer_Repairs.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Computer_Repairs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList().Select(s => s.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            _context.Users.Add(userModel);
            _context.SaveChanges();

            // When the User is created "GetUser" Controller is called with the Id paramater
            return CreatedAtAction(nameof(GetUser), new {id = userModel.Id}, userModel.ToUserDto());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound("No user found with the given id");
            }
            user.Name = userDto.Name;
            user.Username = userDto.Username;
            user.Role = userDto.Role;
            user.Salary = userDto.Salary;

            _context.SaveChanges();
            return Ok(user.ToUserDto());

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound("No user found with the given id");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
