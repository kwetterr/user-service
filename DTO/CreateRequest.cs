using System;
using System.ComponentModel.DataAnnotations;

namespace kwetter_authentication.DTO
{
  public class CreateRequest
  {
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
