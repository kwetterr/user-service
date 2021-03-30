using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace kwetter_authentication.Models
{
  [Table("User")]

  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Biography { get; set; }
    public string Avatar { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    public Role Role { get; set; }
  }
}
