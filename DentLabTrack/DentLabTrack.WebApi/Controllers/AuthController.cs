using DentLabTrack.Business.Operations.User;
using DentLabTrack.Business.Operations.User.Dtos;
using DentLabTrack.WebApi.Jwt;
using DentLabTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace DentLabTrack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //This controller is responsible for authentication and authorization operations.
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
                LastName = request.LastName,
                FirstName = request.FirstName

            };
            var result = await _userService.AddUser(addUserDto);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _userService.LoginUser(new LoginUserDto { Email = request.Email, Password = request.Password });
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            var user = result.Data;
            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            Console.WriteLine(configuration["Jwt:SecretKey"]);
            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)
            });

            return Ok(new LoginResponse
            {
                Message = "Giriş başarılı",
                Token = token,
            });
        }
        [HttpGet("me")]
        [Authorize(Roles = "Doctor,Technician,Admin")]
        public IActionResult GetMyUser()
        {
            return Ok();
        }
    }
}
