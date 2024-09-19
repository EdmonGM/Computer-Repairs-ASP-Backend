using Computer_Repairs.Dtos.User;
using Computer_Repairs.Models;

namespace Computer_Repairs.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Username = userModel.Username,
                Role = userModel.Role,
                Salary = userModel.Salary,
                Tickets = userModel.Tickets.Select(t => t.ToTicketDto()).ToList(),
            };
        }
        public static User ToUserFromCreateDto(this CreateUserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Username = userDto.Username,
                Role = userDto.Role,
                Salary = userDto.Salary
            };
        }
    }
}
