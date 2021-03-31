using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using kwetter_authentication.DTO;
using kwetter_authentication.Helpers;
using kwetter_authentication.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace kwetter_authentication.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationContext _context;

        public UserService(IOptions<AppSettings> options, ApplicationContext context)
        {
            _appSettings = options.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public User Create(CreateRequest req)
        {
            var res = _context.Users.Add(
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = req.Username,
                    Name = req.Name,
                    Email = req.Email,
                    Country = req.Country,
                    Biography = req.Biography,
                    Avatar = req.Avatar,
                    Role = Role.USER,
                }
            );
            _context.SaveChanges();
            return res.Entity;
        }

        public void DeleteById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User UpdateRole(string id, string role)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                user.Role = (Role)Enum.Parse((typeof(Role)), role);
                _context.SaveChanges();
                return user;
            }
            catch
            {
                throw new ArgumentException("Role doesn't exist");
            }
        }

        public User UpdateUser(string id, UpdateRequest req)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            user.Biography = req.Biography;
            user.Avatar = req.Avatar;
            user.Country = req.Country;
            user.Email = req.Email;
            user.Name = req.Name;
            user.Password = req.Password;
            _context.SaveChanges();
            return user;
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
