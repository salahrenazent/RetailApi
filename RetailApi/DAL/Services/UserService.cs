using RetailApi.DAL.Interfaces;
using RetailApi.Dtos;
using RetailApi.Helper;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class UserService:IUserService
    {
        public UserService()
        {
        }

        public UserLoginResponse VerifyLogin(string loginName, string password, int companyId)
        {
            UserLoginResponse result = new UserLoginResponse();
            List<UserMenu> userMenus = new List<UserMenu>();
            List<MenuPrivileges> userPrivileges = new List<MenuPrivileges>();
            Settings usersettings = new Settings();

            User usr = new User();
            SqlConnection objCon = new SqlConnection();
            try
            {
                using (SqlConnection conn = ADO.GetConnection())
                {

                    using (SqlCommand cmd = new SqlCommand("SP_VERIFY_LOGIN", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LOGIN_NAME", loginName);
                        cmd.Parameters.AddWithValue("@PASSWORD", password);
                        cmd.Parameters.AddWithValue("@COMPANY_ID", companyId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);

                            if (ds.Tables.Count > 0)
                            {
                                result.flag = ds.Tables[0].Rows[0]["FLAG"].ToString();
                                result.message = ds.Tables[0].Rows[0]["MESSAGE"].ToString();

                                if (result.flag == "1")
                                {

                                    usr.USER_ID = Convert.ToInt32(ds.Tables[1].Rows[0]["USER_ID"]);
                                    usr.USER_NAME = ds.Tables[1].Rows[0]["USER_NAME"].ToString();
                                    usr.LOGIN_NAME = ds.Tables[1].Rows[0]["LOGIN_NAME"].ToString();
                                    usr.PASSWORD = "";
                                    usr.EMAIL = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                                    usr.MOBILE = ds.Tables[1].Rows[0]["MOBILE"].ToString();
                                    usr.USER_LEVEL = Convert.ToInt32(ds.Tables[1].Rows[0]["USER_LEVEL"]);
                                    usr.LEVEL_NAME = ds.Tables[1].Rows[0]["LEVEL_NAME"].ToString();
                                    usr.IS_INACTIVE = Convert.ToBoolean(ds.Tables[1].Rows[0]["IS_INACTIVE"]);
                                    usr.CAN_VIEW_COST = Convert.ToBoolean(ds.Tables[1].Rows[0]["CAN_VIEW_COST"]);
                                    usr.STORE_ID = 1;
                                    usr.STORE_NAME = "CENTRAL STORE";


                                    if (ds.Tables[2].Rows.Count > 0)
                                    {
                                        DataRow[] ArDrMenu = ds.Tables[2].Select("MAIN_MODULE_ID  = 0");
                                        foreach (DataRow dr in ArDrMenu)
                                        {
                                            UserMenu mnu = new UserMenu();
                                            mnu.id = dr["ID"].ToString();
                                            mnu.text = dr["MODULE_NAME"].ToString();
                                            mnu.icon = dr["MENU_ICON"].ToString();
                                            mnu.path = dr["COMPONENT_NAME"].ToString();

                                            List<UserMenuItem> LstMenuItem = new List<UserMenuItem>();
                                            DataRow[] ArMenuItem = ds.Tables[2].Select("MAIN_MODULE_ID  = " + dr["ID"].ToString());
                                            foreach (DataRow dr1 in ArMenuItem)
                                            {
                                                LstMenuItem.Add(new UserMenuItem
                                                {
                                                    id = dr1["ID"].ToString(),
                                                    text = dr1["MODULE_NAME"].ToString(),
                                                    path = dr1["COMPONENT_NAME"].ToString()
                                                });
                                            }
                                            mnu.items = LstMenuItem.ToList();

                                            userMenus.Add(mnu);
                                        }

                                        foreach (DataRow dr in ds.Tables[2].Rows)
                                        {
                                            userPrivileges.Add(new MenuPrivileges
                                            {
                                                id = dr["ID"].ToString(),
                                                text = dr["MODULE_NAME"].ToString(),
                                                CanAdd = Convert.ToBoolean(dr["IS_ADD"]) ? "1" : "0",
                                                CanView = Convert.ToBoolean(dr["IS_VIEW"]) ? "1" : "0",
                                                CanModify = Convert.ToBoolean(dr["IS_MODIFY"]) ? "1" : "0",
                                                CanDelete = Convert.ToBoolean(dr["IS_DELETE"]) ? "1" : "0",
                                                CanVerify = Convert.ToBoolean(dr["IS_VERIFY"]) ? "1" : "0",
                                                CanApprove = Convert.ToBoolean(dr["IS_APPROVE"]) ? "1" : "0",
                                                CanPrint = Convert.ToBoolean(dr["IS_PRINT"]) ? "1" : "0",
                                                CanModifyDate = Convert.ToBoolean(dr["IS_MODIFY_DATE"]) ? "1" : "0"

                                            }

                                            );

                                        }
                                        DataRow drSettings = ds.Tables[3].Rows[0];
                                        usersettings.CUST_CODE_AUTO = Convert.ToBoolean(drSettings["CUST_CODE_AUTO"]);
                                        usersettings.SUPP_CODE_AUTO = Convert.ToBoolean(drSettings["SUPP_CODE_AUTO"]);
                                        usersettings.EMP_CODE_AUTO = Convert.ToBoolean(drSettings["EMP_CODE_AUTO"]);
                                        usersettings.ITEM_CODE_AUTO = Convert.ToBoolean(drSettings["ITEM_CODE_AUTO"]);
                                        usersettings.DEFAULT_COUNTRY_CODE = drSettings["DEFAULT_COUNTRY_CODE"].ToString();
                                        usersettings.ITEM_PROPERTY1 = drSettings["ITEM_PROPERTY1"].ToString();
                                        usersettings.ITEM_PROPERTY2 = drSettings["ITEM_PROPERTY2"].ToString();
                                        usersettings.ITEM_PROPERTY3 = drSettings["ITEM_PROPERTY3"].ToString();
                                        usersettings.ITEM_PROPERTY4 = drSettings["ITEM_PROPERTY4"].ToString();
                                        usersettings.ITEM_PROPERTY5 = drSettings["ITEM_PROPERTY5"].ToString();
                                        usersettings.REFERENCE_LABEL = drSettings["REFERENCE_LABEL"].ToString();
                                        usersettings.COMMENT_LABEL = drSettings["COMMENT_LABEL"].ToString();
                                        usersettings.STATE_LABEL = drSettings["STATE_LABEL"].ToString();
                                        usersettings.COMMIT_WITH_SAVE = true;
                                        usersettings.DATE_FORMAT = drSettings["DateFormat"].ToString();
                                        usersettings.CURRENCY_ID = Convert.ToInt32(drSettings["CURRENCY_ID"]);
                                        usersettings.CURRENCY_NAME = drSettings["CURRENCY_NAME"].ToString();
                                        usersettings.CURRENCY_CODE = drSettings["CODE"].ToString();
                                        usersettings.CURRENCY_SYMBOL = drSettings["SYMBOL"].ToString();
                                        usersettings.NEGATIVE_ALLOWED = true;
                                    }
                                    result.data = usr;
                                    result.menus = userMenus.ToList();
                                    result.privileges = userPrivileges.ToList();
                                    result.settings = usersettings;
                                    result.Taxname = "VAT Name";

                                }
                            }
                        }
                    }
                }
                    

                

                
            }
            catch (Exception ex)
            {
                result.flag = "0";
                result.message = ex.Message;
            }
            finally
            {
                objCon.Close();
            }

            return result;

        }

        public Int32 SaveData(User user)
        {
            try
            {

                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_USERS";

                    cmd.Parameters.AddWithValue("ACTION", 1);
                    cmd.Parameters.AddWithValue("USER_ID", user.USER_ID);
                    cmd.Parameters.AddWithValue("USER_NAME", user.USER_NAME);
                    cmd.Parameters.AddWithValue("LOGIN_NAME", user.LOGIN_NAME);
                    cmd.Parameters.AddWithValue("PASSWORD", AzentLibrary.Library.EncryptString(user.PASSWORD));

                    cmd.Parameters.AddWithValue("EMAIL", user.EMAIL);
                    cmd.Parameters.AddWithValue("MOBILE", user.MOBILE);
                    cmd.Parameters.AddWithValue("USER_LEVEL", user.USER_LEVEL);
                    cmd.Parameters.AddWithValue("IS_INACTIVE", user.IS_INACTIVE);
                    cmd.Parameters.AddWithValue("COMPANY_ID", user.COMPANY_ID);

                    //identity fields
                    //cmd.Parameters.AddWithValue("EmailConfirmed", 0);
                    //cmd.Parameters.AddWithValue("PhoneNumberConfirmed", 0);
                    //cmd.Parameters.AddWithValue("TwoFactorEnabled", 0);
                    //cmd.Parameters.AddWithValue("LockoutEnabled", 0);
                    //cmd.Parameters.AddWithValue("AccessFailedCount", 0);

                    Int32 UserID = Convert.ToInt32(cmd.ExecuteScalar());



                    return UserID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();

            using(SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_USERS";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    userList.Add(new User
                    {
                        USER_ID = Convert.ToInt32(dr["USER_ID"]),
                        USER_NAME = Convert.ToString(dr["USER_NAME"]),
                        LOGIN_NAME = Convert.ToString(dr["LOGIN_NAME"]),
                        //PASSWORD = Convert.ToString(dr["PASSWORD"]),

                        PASSWORD = AzentLibrary.Library.DecryptString(Convert.ToString(dr["PASSWORD"])),

                        EMAIL = Convert.ToString(dr["EMAIL"]),
                        MOBILE = Convert.ToString(dr["MOBILE"]),
                        LEVEL_NAME = dr["LEVEL_NAME"].ToString(),
                        USER_LEVEL = Convert.ToInt32(dr["USER_LEVEL"].ToString()),
                        IS_INACTIVE = Convert.ToBoolean(dr["IS_INACTIVE"]),
                        COMPANY_ID = dr["COMPANY_ID"].ToString()
                    });
                }
                connection.Close();

                return userList;
            }
            
        }
        public User GetItems(int id)
        {
            User user = new User();
            try
            {
                string strSQL = "SELECT TB_USERS.USER_ID,TB_USERS.USER_NAME,TB_USERS.LOGIN_NAME, TB_USERS.PASSWORD, " +
                                "TB_USERS.EMAIL,TB_USERS.MOBILE,TB_USERS.USER_LEVEL,TB_USERS.IS_INACTIVE,TB_USERS.COMPANY_ID, " +
                                "TB_USER_LEVELS.LEVEL_NAME " +
                                "FROM TB_USERS INNER JOIN TB_USER_LEVELS ON TB_USERS.USER_LEVEL = TB_USER_LEVELS.LEVEL_ID " +
                                " WHERE TB_USERS.IS_DELETED = 0 AND TB_USERS.USER_ID = " + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "Users");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    user.USER_ID = Convert.ToInt32(dr["USER_ID"]);
                    user.USER_NAME = Convert.ToString(dr["USER_NAME"]);
                    user.LOGIN_NAME = Convert.ToString(dr["LOGIN_NAME"]);
                    user.PASSWORD = AzentLibrary.Library.DecryptString(Convert.ToString(dr["PASSWORD"]));
                    user.EMAIL = Convert.ToString(dr["EMAIL"]);
                    user.MOBILE = Convert.ToString(dr["MOBILE"]);
                    user.USER_LEVEL = Convert.ToInt32(dr["USER_LEVEL"].ToString());
                    user.LEVEL_NAME = dr["LEVEL_NAME"].ToString();
                    user.IS_INACTIVE = Convert.ToBoolean(dr["IS_INACTIVE"]);
                    user.COMPANY_ID = Convert.ToString(dr["COMPANY_ID"]);

                }
            }
            catch (Exception ex)
            {

            }

            return user;
        }
        public bool DeleteUser(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_USERS";
                    cmd.Parameters.AddWithValue("ACTION", 4);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserRightsResponse GetUserRights(int UserID, string Path)
        {
            UserRightsResponse result = new UserRightsResponse();
            SqlConnection objCon = new SqlConnection();
            try
            {
                List<UserRights> userrights = new List<UserRights>();
                objCon = ADO.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GET_USER_RIGHT";
                cmd.Parameters.AddWithValue("@USER_ID", UserID);
                cmd.Parameters.AddWithValue("@PATH", Path);
                cmd.CommandTimeout = 0;

                DataSet ds = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(ds);

                // Check if there are any results in the dataset
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UserRights usr = new UserRights
                        {
                            CAN_ADD = row["IS_ADD"].ToString(),
                            CAN_VIEW_COST = row["IS_VIEW_COST"].ToString(),
                            CAN_MODIFY = row["IS_MODIFY"].ToString(),
                            CAN_DELETE = row["IS_DELETE"].ToString(),
                            CAN_VERIFY = row["IS_VERIFY"].ToString(),
                            CAN_APPROVE = row["IS_APPROVE"].ToString(),
                            CAN_PRINT = row["IS_PRINT"].ToString(),
                            CAN_EXPORT = row["IS_EXPORT"].ToString()
                        };
                        userrights.Add(usr);
                    }

                    result.flag = "1"; // Success
                    result.message = "Data retrieved successfully.";
                }
                else
                {
                    result.flag = "0";
                    result.message = "No data found.";
                }

                result.UserRight = userrights; // Assign the populated list to result.data
            }
            catch (Exception ex)
            {
                result.flag = "0";
                result.message = ex.Message;
            }
            finally
            {
                if (objCon != null && objCon.State == ConnectionState.Open)
                {
                    objCon.Close(); // connection  close
                }
            }

            return result;
        }
        public UserRightsResponse GetUserRightsAccess(int LevelID, string Component)
        {
            UserRightsResponse result = new UserRightsResponse();
            SqlConnection objCon = new SqlConnection();
            try
            {
                List<UserRights> userrights = new List<UserRights>();
                objCon = ADO.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GET_MODULE_ACCESS_RIGHT";
                cmd.Parameters.AddWithValue("@LEVEL_ID", LevelID);
                cmd.Parameters.AddWithValue("@COMPONENT_NAME", Component);
                cmd.CommandTimeout = 0;

                DataSet ds = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(ds);

                // Check if there are any results in the dataset
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UserRights usr = new UserRights
                        {
                            CAN_ADD = row["IS_ADD"].ToString(),
                            CAN_VIEW = row["IS_VIEW"].ToString(),
                            CAN_MODIFY = row["IS_MODIFY"].ToString(),
                            CAN_DELETE = row["IS_DELETE"].ToString(),
                            CAN_VERIFY = row["IS_VERIFY"].ToString(),
                            CAN_APPROVE = row["IS_APPROVE"].ToString(),
                            CAN_PRINT = row["IS_PRINT"].ToString(),
                            CAN_EXPORT = row["IS_EXPORT"].ToString(),
                            CAN_MODIFY_DATE = row["IS_MODIFY_DATE"].ToString(),
                            DOC_TYPE = Convert.ToInt32(row["DOC_TYPE"])
                        };
                        userrights.Add(usr);
                    }

                    result.flag = "1"; // Success
                    result.message = "Data retrieved successfully.";
                }
                else
                {
                    result.flag = "0";
                    result.message = "No data found.";
                }

                result.UserRight = userrights; // Assign the populated list to result.data
            }
            catch (Exception ex)
            {
                result.flag = "0";
                result.message = ex.Message;
            }
            finally
            {
                if (objCon != null && objCon.State == ConnectionState.Open)
                {
                    objCon.Close(); // connection  close
                }
            }

            return result;
        }
    }
}
