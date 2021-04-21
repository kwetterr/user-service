using System;
namespace kwetter_authentication.Helpers
{
    public class AppSettings
    {
        public string JwtSecret { get; set; }
        public int Iterations { get; set; }
        public string ConnectionString { get; set; }
        public string AllowedHosts { get; set; }
    }
}
