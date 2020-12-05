using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.Helpers;
using ProiectDAW.IServices;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var Result = _userService.Register(request);
             if (Result)
            {
                return Ok();
            } else
            {
                return Conflict();
            }
            
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            AuthenticationResponse response =  _userService.Login(request);
            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(_userService.GetAll().Where(x => x.UserId == user.UserId).ToList());
        }
    }
}
