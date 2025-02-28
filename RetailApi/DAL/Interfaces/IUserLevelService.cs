using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IUserLevelService
    {
        public List<UserMenuList> GetAllUserMenuList();
        public List<UserLevel> GetAllUserLevelList();
        public Int32 Insert(UserLevel userLevel);
        public Int32 Update(UserLevel userLevel);
        public UserLevel GetItems(int id);
        public bool Delete(int id);
    }
}
