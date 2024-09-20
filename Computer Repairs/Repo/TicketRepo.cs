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
        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task<Ticket> DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return null;
            }
            _context.Remove(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
    }
}
