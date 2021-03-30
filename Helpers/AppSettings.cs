using System;
namespace kwetter_authentication.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string MockUserPassword { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
    }
}
