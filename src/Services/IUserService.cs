using System;
using System.Collections.Generic;
using kwetter_authentication.DTO;
using kwetter_authentication.Models;

namespace kwetter_authentication.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User Create(CreateRequest user);
        User GetById(string id);
        User UpdateUser(string id, UpdateRequest req);
        void DeleteById(string id);
        User UpdateRole(string id, string role);
        IEnumerable<User> GetAll();
    }
}
