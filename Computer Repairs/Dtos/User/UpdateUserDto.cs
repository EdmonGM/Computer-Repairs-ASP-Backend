﻿namespace Computer_Repairs.Dtos.User
{
    public class UpdateUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
