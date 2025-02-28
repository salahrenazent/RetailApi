using RetailApi.Dtos;
using RetailApi.Models;

namespace RetailApi.Services
{
    public class UserDataService
    {
        private ApplicationDbContext _dbContext;
        public UserDataService(ApplicationDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<UserLoginResponse> GetLoginRespone()
        {
            return null as UserLoginResponse;
        }
    }
}
