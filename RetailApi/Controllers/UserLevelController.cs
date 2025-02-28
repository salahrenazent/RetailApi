using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserLevelController : ControllerBase
    {
        private readonly IUserLevelService _userLevelService;
        public UserLevelController(IUserLevelService userLevelService)
        {
            _userLevelService = userLevelService;
        }
        [HttpPost]
        [Route("usermenulist")]
        public UserLevelResponse MenuList()
        {
            UserLevelResponse res = new UserLevelResponse();
            List<UserMenuList> menuLists = new List<UserMenuList>();
            try
            {
                
                menuLists = _userLevelService.GetAllUserMenuList();
                res.Flag = 1;
                res.Message = "Success";
                res.menu = menuLists;
            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("userlevelist")]
        public UserLevelResponse List()
        {
            UserLevelResponse res = new UserLevelResponse();
            List<UserLevel> userLevels = new List<UserLevel>();
            try
            {
                
                userLevels = _userLevelService.GetAllUserLevelList();
                res.Flag = 1;
                res.Message = "Success";
                res.data = userLevels;
            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("insert")]
        public UserLevelResponse Insert(UserLevel objUserLevels)
        {
            UserLevelResponse res = new UserLevelResponse();

            try
            {
                
                Int32 UserlevelID = _userLevelService.Insert(objUserLevels);

                res.Flag = 1;
                res.Message = "Success";
                //res.data = _userLevelService.GetItems(UserlevelID);
            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
                return res;
            }

            return res;
        }

        [HttpPost]
        [Route("update")]
        public UserLevelResponse Update(UserLevel objUserLevels)
        {
            UserLevelResponse res = new UserLevelResponse();

            try
            {
                
                Int32 UserlevelID = _userLevelService.Update(objUserLevels);

                res.Flag = 1;
                res.Message = "Success";
                // res.data = _userLevelService.GetItems(UserlevelID);
            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
                return res;
            }

            return res;
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public UserLevel Select(int id)
        {
            UserLevel objUserLevel = new UserLevel();
            try
            {
                
                objUserLevel = _userLevelService.GetItems(id);
            }
            catch (Exception ex)
            {

            }

            return objUserLevel;
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public UserLevelResponse Delete(int id)
        {
            UserLevelResponse res = new UserLevelResponse();

            try
            {
                

                _userLevelService.Delete(id);
                res.Flag = 1;
                res.Message = "Success";

            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
