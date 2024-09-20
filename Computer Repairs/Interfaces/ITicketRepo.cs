using Computer_Repairs.Models;

namespace Computer_Repairs.Interfaces
{
    public interface ITicketRepo
    {
        Task <List<Ticket>> GetAllAsync ();
        Task <Ticket> GetByIdAsync (int id);
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<Ticket> DeleteAsync(int id);
    }
}
