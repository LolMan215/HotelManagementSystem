namespace HotelManagementSystem.Server.Controllers
{
    using HotelManagementSystemBL.DTOs.Account;
    using HotelManagementSystemBL.Services;
    using HotelManagementSystemDAL.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JWTService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(JWTService iwtService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _jwtService = iwtService;
            _userManager = userManager; 
            _signInManager = signInManager;
        }

        [Authorize]
        [HttpGet("refresh-user-token")]
        public async Task<ActionResult<ApplicationUserDto>> RefreshUserToken()
        {
            var applicationUser = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Email)?.Value);
            return CreateApplicationUserDto(applicationUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUserDto>> Login(LoginDto model)
        {
            var applicationUser = await _userManager.FindByNameAsync(model.UserName);
            if (applicationUser == null) return Unauthorized("Invalid username or password");

            if (applicationUser.EmailConfirmed == false) return Unauthorized("Confirm your email");

            var result = await _signInManager.CheckPasswordSignInAsync(applicationUser, model.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid username or password");

            return CreateApplicationUserDto(applicationUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if(await CheckEmailExistsAsync(model.Email))
            {
                return BadRequest($"An existing account is using {model.Email}, email address. Please try with another email adress");
            }

            var applicationUserToAdd = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email.ToLower(),
                Email = model.Email.ToLower(),
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(applicationUserToAdd, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok("Account has been created");
        }


        private ApplicationUserDto CreateApplicationUserDto(ApplicationUser applicationUser)
        {
            return new ApplicationUserDto
            {
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                JWT = _jwtService.CreateJWT(applicationUser)
            };
        }

        private async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }

    }
}
