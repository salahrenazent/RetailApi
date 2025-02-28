using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RetailApi.Dtos;
using RetailApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AzentLibrary;
using RetailApi.DAL.Interfaces;
using System.Security.Cryptography;

namespace RetailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration; // To access your JWT settings
        private ApplicationDbContext _dbContext;
        private readonly IUserService _userRepository;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ApplicationDbContext dbContext,
            IUserService userRepository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _userRepository = userRepository;

        }

        //user registeration endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userData)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { UserName = userData.LOGIN_NAME,
                    LOGIN_NAME = userData.LOGIN_NAME,
                    Id = userData.USER_ID,

                    Email = userData.EMAIL,
                    MOBILE = userData.MOBILE,
                    USER_LEVEL = userData.USER_LEVEL,
                    IS_INACTIVE = userData.IS_INACTIVE,
                    COMPANY_ID = userData.COMPANY_ID,
                };

                var azentEncryptedPwd = AzentLibrary.Library.EncryptString(userData.PASSWORD);//encrypted with azent_library

                var result = await _userManager.CreateAsync(user, azentEncryptedPwd);

                if (result.Succeeded)
                {
                    return Ok(new { message = "User registered successfully." });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest(ModelState);
        }
        [HttpPost("registerold")]
        public UserResponse Registerold([FromBody] User userData)
        {
            UserResponse res = new UserResponse();

            try
            {
                Int32 UserID = _userRepository.SaveData(userData);

                res.flag = "1";
                res.message = "Success";
                //res.data = dbhandle.GetItems(UserID);
            }
            catch (Exception ex)
            {
                res.flag = "1";
                res.message = ex.Message;
            }

            return res;
        }

        //user login endpoint
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserVerificationInput vLoginInput)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(vLoginInput.LOGIN_NAME);

                if (user != null)
                {
                    var token = GenerateJwtToken(user);

                    //user data service
                    var responce =  _userRepository.VerifyLogin(
                        vLoginInput.LOGIN_NAME,
                        AzentLibrary.Library.EncryptString(vLoginInput.PASSWORD),
                        vLoginInput.COMPANY_ID
                        );


                    return Ok(new { responce });
                    //return Ok(new { Token = token });
                }

                return Unauthorized(new { message = "Invalid username or password" });
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }
        
        //private method for generating web token
        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, "Admin"),};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //endpoint for Password_Change
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            var user = await _userManager.GetUserAsync(User);
            var azentEncryptedNewPassword = AzentLibrary.Library.EncryptString(model.NewPassword);//encrypted with azent_library
            var azentEncryptedOldPassword = AzentLibrary.Library.EncryptString(model.OldPassword);//encrypted with azent_library
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, azentEncryptedOldPassword, azentEncryptedNewPassword);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Password changed successfully." });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return Unauthorized(new { message = "User not found." });
        }
    }
}
