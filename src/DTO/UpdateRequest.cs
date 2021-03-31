using System;
using System.ComponentModel.DataAnnotations;

namespace kwetter_authentication.DTO
{
    public class UpdateRequest
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; } = "";
        public string Biography { get; set; } = "";
        public string Avatar { get; set; } = "";
        public string Password { get; set; }
    }
}
