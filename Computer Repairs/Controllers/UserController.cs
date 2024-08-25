using Computer_Repairs.Data;
using Computer_Repairs.Dtos.User;
using Computer_Repairs.Interfaces;
using Computer_Repairs.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Computer_Repairs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepo userRepo) : ControllerBase
    {
        private readonly  IUserRepo _userRepo = userRepo;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllAsync();
                
            var usersDto = users.Select(s => s.ToUserDto());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            await _userRepo.CreateAsync(userModel);

            // When the User is created "GetUser" Controller is called with the Id paramater
            return CreatedAtAction(nameof(GetUser), new {id = userModel.Id}, userModel.ToUserDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            var user = await _userRepo.UpdateAsync(id, userDto);
            if(user == null)
            {
                return NotFound("No user found with the given id");
            }
           
            return Ok(user.ToUserDto());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepo.DeleteAsync(id);
            if(user == null)
            {
                return NotFound("No user found with the given id");
            }

            return NoContent();
        }
    }
}
