using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace kwetter_authentication.Models
{
    public enum Role
    {
        USER,
        MODERATOR,
        ADMIN
    }
}
    