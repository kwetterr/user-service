using System;
using kwetter_authentication.Models;

namespace kwetter_authentication.DTO
{
    public class AuthenticateResponse
    {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Biography { get; set; }
    public string Avatar { get; set; }

    public string Role { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Name = user.Name;
            Email = user.Email;
            Country = user.Country;
            Biography = user.Biography;
            Avatar = user.Avatar;
            Role = user.Role.ToString();
        }
    }
}
