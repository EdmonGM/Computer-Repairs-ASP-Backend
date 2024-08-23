using Computer_Repairs.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Repairs.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<User> Users  { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
