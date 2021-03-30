using System;
using System.ComponentModel.DataAnnotations;

namespace kwetter_authentication.DTO
{
  public class CreateRequest
  {
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string Country { get; set; } = "";
    public string Biography { get; set; } = "";
    public string Avatar { get; set; } = "";

    [Required]
    public string Password { get; set; }

  }
}
