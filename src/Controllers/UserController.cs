using System;
using kwetter_authentication.DTO;
using kwetter_authentication.Helpers;
using kwetter_authentication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kwetter_authentication.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly ApplicationContext _context;

    public UsersController(IUserService userService, ApplicationContext context)
    {
      _context = context;
      _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      try
      {
        var response = _userService.Authenticate(model);

        if (response == null)
          return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
      }
      catch (Exception e)
      {
        return BadRequest(new { message = e.ToString() });
      }
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _userService.GetAll();
      return Ok(users);
    }

    [HttpGet("getnew")]
    public IActionResult GetAllNew()
    {
      return Ok(_context.Users);
    }


    [HttpPost("create")]
    public IActionResult Create(CreateRequest dto)
    {
      try
      {
        var user = new Models.User() 
        { 
          FirstName = dto.Username,
          LastName = dto.LastName, 
          Username = dto.Username, 
          Password = dto.Password 
        };
        var u = _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(u);
      }
      catch (Exception e)
      {
        return BadRequest(new { message = e.ToString() });
      }
    }
  }
}
