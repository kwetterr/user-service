using System;
using System.Collections.Generic;
using kwetter_authentication.DTO;
using kwetter_authentication.Models;

namespace kwetter_authentication.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
