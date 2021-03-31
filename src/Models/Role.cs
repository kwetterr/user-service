using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace kwetter_authentication.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        [EnumMember(Value = "USER")]
        USER,

        [EnumMember(Value = "MODERATOR")]
        MODERATOR,

        [EnumMember(Value = "ADMIN")]
        ADMIN
    }
}
