using Computer_Repairs.Data;
using Computer_Repairs.Dtos.User;
using Computer_Repairs.Interfaces;
using Computer_Repairs.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Repairs.Repo
{
    public class UserRepo(ApplicationDBContext context) : IUserRepo
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Include(t => t.Tickets).ToListAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(t => t.Tickets).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            user.Name = userDto.Name;
            user.Username = userDto.Username;
            user.Role = userDto.Role;
            user.Salary = userDto.Salary;

            await _context.SaveChangesAsync(); 
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) 
            {
                return null;
            }
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> UserExsits(int id)
        {
            return _context.Users.AnyAsync(u => u.Id == id);
        }
    }
}
