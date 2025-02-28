using RetailApi.Dtos;

namespace RetailApi.DAL.Interfaces
{
    public interface IUserService
    {
        public UserLoginResponse VerifyLogin(string loginName, string password,int compayId);
        public Int32 SaveData(User user);
        public List<User> GetAllUsers();
        public User GetItems(int id);
        public bool DeleteUser(int id);
        public UserRightsResponse GetUserRights(int userid,string path);
        public UserRightsResponse GetUserRightsAccess(int levelId,string component);
    }
}
