﻿

namespace Hostel.Core.DTOs
{
    public class RegisterRequestDTO
    {
        public  string Username { get; set; } = string.Empty;
        public  string Password { get; set; } = string.Empty;
        public  string Role { get; set; } = "Staff";
    }
}
