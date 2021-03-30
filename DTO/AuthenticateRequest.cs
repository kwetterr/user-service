using System;
using System.ComponentModel.DataAnnotations;

namespace kwetter_authentication.DTO
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
