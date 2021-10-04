using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace todo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _myUserManager;
       
        private IConfiguration _config;

        public AccountController( UserManager<IdentityUser> injectedUserManager, IConfiguration config)
        {
            _myUserManager = injectedUserManager;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            //check if the SignupRequest is valid
            if (ModelState.IsValid)
            {
                //Create new user and map it with the request
                var newUser = new IdentityUser();
                newUser.UserName = request.UserName;
                newUser.Email = request.Email;
            
                var result = await _myUserManager.CreateAsync(newUser,request.Password);

                //Check if the user is created successfuly
                if (result.Succeeded)
                {
                    //Generate Token
                    var tokenString = GenerateJSONWebToken(newUser);
                   return Ok(new SignInResponse { token = tokenString });
                }
            }
            //otherwise
            return BadRequest("Invalid data entered");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInRequest request)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(request);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new SignInResponse { token = tokenString });
            }

            return response;
        }


        //Generate Token for the user if authenticated
        private string GenerateJSONWebToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),                
                new Claim(JwtRegisteredClaimNames.Email, user.Email),                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Check if the user authenticated
        private async Task<IdentityUser> AuthenticateUser(SignInRequest request)
        {

            //Validate the User Credentials
            var user = await _myUserManager.FindByNameAsync(request.UserName);
            var result = await _myUserManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                return user;
            }
            return null;
           
        }
    }
}

