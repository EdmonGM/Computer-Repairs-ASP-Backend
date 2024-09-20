using Computer_Repairs.Dtos.User;
using Computer_Repairs.Models;

namespace Computer_Repairs.Interfaces
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(int id, UpdateUserDto userDto);
        Task<User> DeleteAsync(int id);
        Task<bool> UserExsits(int id);
    }
}
