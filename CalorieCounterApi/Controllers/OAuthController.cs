using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Application.Contract.Services;
using CalorieCounterApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalorieCounterApi.Controllers
{
    [Route("[controller]/token")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public OAuthController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<OAuthController>
        [HttpPost]
        public ActionResult Post(AuthenticationRequest request)
        {
            try
            {
                UserDto user = _userService.GetUserBy(new CredentialsDto(request.UserName, request.Password));
                string token = CreateTokenFor(user);

                return Ok(new { access_token = token });
            }
            catch (Exception e)
            {
                return Unauthorized(new ErrorResponse(e));
            }
        }

        private string CreateTokenFor(UserDto user)
        { 
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "Some_id"),
                new Claim(ClaimTypes.Email, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var secretBytes = Encoding.UTF8.GetBytes(GlobalConstants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: GlobalConstants.Issuer,
                audience: GlobalConstants.Audiance,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}