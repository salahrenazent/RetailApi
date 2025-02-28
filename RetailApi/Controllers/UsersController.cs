using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RetailApi.DAL.Interfaces;
using RetailApi.Dtos;
using RetailApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RetailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userRepository;
        private readonly IConfiguration _configuration; // To access your JWT settings

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IUserService userRepository,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        

        [HttpPost]
        [Route("list")]
        public List<User> List()
        {
            List<User> Users = new List<User>();

            try
            {
                Users = _userRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
            }
            return Users.ToList();
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public User Select(int id)
        {
            User objUser = new User();
            try
            {
                objUser = _userRepository.GetItems(id);
            }
            catch (Exception ex)
            {

            }

            return objUser;
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public UserResponse Delete(int id)
        {
            UserResponse res = new UserResponse();

            try
            {

                _userRepository.DeleteUser(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _userRepository.GetItems(id);
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }
            return res;
        }
        [HttpPost]
        [Route("rights")]
        public UserRightsResponse UserRights(UserRightsInput input)
        {
            UserRightsResponse res = new UserRightsResponse();
            try
            {
                res = _userRepository.GetUserRights(input.UserID, input.Path);

                res.flag = "1";
                res.message = "Success";
                return res;
            }

            catch (Exception ex)
            {

            }

            return res;
        }

        [HttpPost]
        [Route("rightsaccess")]
        public UserRightsResponse UserRightsAccess(UserRightAccessInput input)
        {
            UserRightsResponse res = new UserRightsResponse();
            try
            {
                res = _userRepository.GetUserRightsAccess(input.LEVEL_ID, input.COMPONENT_NAME);

                res.flag = "1";
                res.message = "Success";
                return res;
            }

            catch (Exception ex)
            {

            }

            return res;
        }
        //user registration method
        [HttpPost]
        [Route("save")]
        public UserResponse SaveData(User userData)
        {
            UserResponse res = new UserResponse();

            try
            {
                Int32 UserID = _userRepository.SaveData(userData);

                res.flag = "1";
                res.message = "Success";
                res.data = _userRepository.GetItems(UserID);
            }
            catch (Exception ex)
            {
                res.flag = "1";
                res.message = ex.Message;
            }

            return res;
        }
        [HttpPost]
        [Route("login")]
        public UserLoginResponse VerifyLogin(UserVerificationInput vLoginInput)
        {
            UserLoginResponse res = new UserLoginResponse();
            try
            {
                res = _userRepository.VerifyLogin(vLoginInput.LOGIN_NAME, AzentLibrary.Library.EncryptString(vLoginInput.PASSWORD), vLoginInput.COMPANY_ID);
                res.token = GenerateJwtToken(res.data);
            }
            catch (Exception ex)
            {

            }

            return res;
        }
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.USER_NAME),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.USER_ID.ToString()),
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
    }
}
