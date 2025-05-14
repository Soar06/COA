﻿namespace CustomerOrderService.Application.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
       
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}