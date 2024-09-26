using Eshop.Contracts;
using Eshop.Data;
using Eshop.Models;
using Eshop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.VisualStudio.Threading;
namespace Eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager, ITokenService tokenService)
        {
             _userManager = userManager;
            _singInManager = singInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = new AppUser { UserName = registerDto.UserName, Email = registerDto.Email };
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status201Created, new NewUserDto ()
                        {
                            Email = user.Email, 
                            UserName = user.UserName,
                            Token = _tokenService.CreateToken(user),
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, roleResult.Errors);
                    }
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, createdUser.Errors);
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex); }
        }

        [HttpPost("login")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userManager.Users.FirstOrDefault(u => u.UserName==loginDto.UserName);

            if (user == null)
                return Unauthorized("Invalid user name!");

            var result = await _singInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Password is not correct");
            }

            return Ok(new NewUserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}
