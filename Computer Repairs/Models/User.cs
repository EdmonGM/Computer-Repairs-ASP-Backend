using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Computer_Repairs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6,2)")]
        public decimal Salary { get; set; }
        public List<Ticket> Tickets { get; set; } = [];
    }
}
