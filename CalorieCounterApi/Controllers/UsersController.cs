using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Application.Contract.Services;
using CalorieCounterApi.DTOs;
using CalorieCounterApi.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalorieCounterApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                UserIdDto userId = new UserIdDto(id);
                UserDto user = _userService.GetUserBy(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponse(e));
            }
           
        }

        // POST api/users
        [HttpPost]
        public ActionResult Post(CreateUserRequest request)
        {
            try
            {
                CreateUserDto newUser = request.ToDto();
                UserIdDto id = _userService.CreateUser(newUser);
                return Created(Request.Host + Request.Path + "/" + id.Id, id);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponse(e));
            }
        }
    }
}