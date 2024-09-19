using Computer_Repairs.Data;
using Computer_Repairs.Interfaces;
using Computer_Repairs.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Repairs.Repo
{
    public class TicketRepo(ApplicationDBContext context) : ITicketRepo
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
