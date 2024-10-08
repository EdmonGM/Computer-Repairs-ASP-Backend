﻿using Computer_Repairs.Dtos.Ticket;
using System.ComponentModel.DataAnnotations.Schema;

namespace Computer_Repairs.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
