using System;
using kwetter_authentication.DTO;
using kwetter_authentication.Helpers;
using kwetter_authentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace kwetter_authentication.Controllers
{
    [ApiController]
    [Route("/")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("authorize")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _service.Authenticate(model);

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
            var users = _service.GetAll();
            return Ok(users);
        }

        [HttpPost("/create")]
        public IActionResult Create(CreateRequest dto)
        {
            try
            {
                var user = _service.Create(dto);
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }

        [Authorize]
        [HttpGet("/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var user = _service.GetById(id);
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }

        [Authorize]
        [HttpPut("/{id}")]
        public IActionResult Update(string id, UpdateRequest request)
        {
            try
            {
                var user = _service.UpdateUser(id, request);
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }

        [Authorize]
        [HttpDelete("/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _service.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }

        [Authorize]
        [HttpPut("/{id}/role")]
        public IActionResult UpdateRole(string id)
        {
            try
            {
                _service.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }
    }
}
