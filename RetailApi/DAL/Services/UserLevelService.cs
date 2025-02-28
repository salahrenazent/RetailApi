using RetailApi.DAL.Interfaces;
using RetailApi.Dtos;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class UserLevelService:IUserLevelService
    {
        public List<UserMenuList> GetAllUserMenuList()
        {
            List<UserMenuList> usermenuList = new List<UserMenuList>();


            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TB_USER_LEVELS";
            cmd.Parameters.AddWithValue("ACTION", 5);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                usermenuList.Add(new UserMenuList
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    MODULE_NAME = ADO.ToString(dr["MODULE_NAME"]),
                    MAIN_MODULE_ID = ADO.ToInt32(dr["MAIN_MODULE_ID"]),
                    COMPONENT_NAME = ADO.ToString(dr["COMPONENT_NAME"]),
                    MENU_ICON = ADO.ToString(dr["MENU_ICON"]),
                    IS_INACTIVE = ADO.Toboolean(dr["IS_INACTIVE"]),
                    MODULE_ORDER = ADO.ToFloat(dr["MODULE_ORDER"])
                });
            }
            connection.Close();

            return usermenuList;
        }
        public List<UserLevel> GetAllUserLevelList()
        {
            List<UserLevel> userlevelList = new List<UserLevel>();
            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TB_USER_LEVELS";
            cmd.Parameters.AddWithValue("ACTION", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                userlevelList.Add(new UserLevel
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    LEVEL_NAME = ADO.ToString(dr["LEVEL_NAME"]),
                    CAN_VIEW_COST = ADO.Toboolean(dr["CAN_VIEW_COST"]),
                    IS_INACTIVE = ADO.Toboolean(dr["IS_INACTIVE"]),
                    COMPANY_ID = ADO.ToInt32(dr["COMPANY_ID"])
                });
            }
            connection.Close();

            return userlevelList;
        }
        public Int32 Insert(UserLevel userLevel)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("ID", typeof(Int32));
                tbl.Columns.Add("MODULE_ID", typeof(Int32));
                tbl.Columns.Add("IS_ADD", typeof(bool));
                tbl.Columns.Add("IS_VIEW", typeof(bool));
                tbl.Columns.Add("IS_MODIFY", typeof(bool));
                tbl.Columns.Add("IS_DELETE", typeof(bool));
                tbl.Columns.Add("IS_VERIFY", typeof(bool));
                tbl.Columns.Add("IS_APPROVE", typeof(bool));
                tbl.Columns.Add("IS_PRINT", typeof(bool));
                tbl.Columns.Add("IS_EXPORT", typeof(bool));
                foreach (UserRight ur in userLevel.rights)
                {
                    DataRow dRow = tbl.NewRow();
                    dRow["ID"] = ur.ID;
                    dRow["MODULE_ID"] = ur.MODULE_ID;
                    dRow["IS_ADD"] = ur.IS_ADD;
                    dRow["IS_VIEW"] = ur.IS_VIEW;
                    dRow["IS_MODIFY"] = ur.IS_MODIFY;
                    dRow["IS_DELETE"] = ur.IS_DELETE;
                    dRow["IS_VERIFY"] = ur.IS_VERIFY;
                    dRow["IS_APPROVE"] = ur.IS_APPROVE;
                    dRow["IS_PRINT"] = ur.IS_PRINT;
                    dRow["IS_EXPORT"] = ur.IS_EXPORT;

                    tbl.Rows.Add(dRow);
                    tbl.AcceptChanges();
                }
                SqlConnection connection = ADO.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_USER_LEVELS";
                cmd.Parameters.AddWithValue("ACTION", 1);

                cmd.Parameters.AddWithValue("LEVEL_NAME", userLevel.LEVEL_NAME);
                cmd.Parameters.AddWithValue("CAN_VIEW_COST", userLevel.CAN_VIEW_COST);
                cmd.Parameters.AddWithValue("IS_INACTIVE", userLevel.IS_INACTIVE);
                cmd.Parameters.AddWithValue("COMPANY_ID", userLevel.COMPANY_ID);
                cmd.Parameters.AddWithValue("@UDT_TB_USER_RIGHTS", tbl);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = connection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT MAX(LEVEL_ID) FROM TB_USER_LEVELS";
                Int32 UserlevelID = Convert.ToInt32(cmd1.ExecuteScalar());

                return UserlevelID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 Update(UserLevel userLevel)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("ID", typeof(Int32));
                tbl.Columns.Add("MODULE_ID", typeof(Int32));
                tbl.Columns.Add("IS_ADD", typeof(bool));
                tbl.Columns.Add("IS_VIEW", typeof(bool));
                tbl.Columns.Add("IS_MODIFY", typeof(bool));
                tbl.Columns.Add("IS_DELETE", typeof(bool));
                tbl.Columns.Add("IS_VERIFY", typeof(bool));
                tbl.Columns.Add("IS_APPROVE", typeof(bool));
                tbl.Columns.Add("IS_PRINT", typeof(bool));
                tbl.Columns.Add("IS_EXPORT", typeof(bool));
                foreach (UserRight ur in userLevel.rights)
                {
                    DataRow dRow = tbl.NewRow();
                    dRow["ID"] = ur.ID;
                    dRow["MODULE_ID"] = ur.MODULE_ID;
                    dRow["IS_ADD"] = ur.IS_ADD;
                    dRow["IS_VIEW"] = ur.IS_VIEW;
                    dRow["IS_MODIFY"] = ur.IS_MODIFY;
                    dRow["IS_DELETE"] = ur.IS_DELETE;
                    dRow["IS_VERIFY"] = ur.IS_VERIFY;
                    dRow["IS_APPROVE"] = ur.IS_APPROVE;
                    dRow["IS_PRINT"] = ur.IS_PRINT;
                    dRow["IS_EXPORT"] = ur.IS_EXPORT;

                    tbl.Rows.Add(dRow);
                    tbl.AcceptChanges();
                }
                SqlConnection connection = ADO.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_USER_LEVELS";
                cmd.Parameters.AddWithValue("ACTION", 3);

                cmd.Parameters.AddWithValue("ID", userLevel.ID);
                cmd.Parameters.AddWithValue("LEVEL_NAME", userLevel.LEVEL_NAME);
                cmd.Parameters.AddWithValue("CAN_VIEW_COST", userLevel.CAN_VIEW_COST);
                cmd.Parameters.AddWithValue("IS_INACTIVE", userLevel.IS_INACTIVE);
                cmd.Parameters.AddWithValue("COMPANY_ID", userLevel.COMPANY_ID);
                cmd.Parameters.AddWithValue("@UDT_TB_USER_RIGHTS", tbl);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = connection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT MAX(LEVEL_ID) FROM TB_USER_LEVELS";
                Int32 UserlevelID = Convert.ToInt32(cmd1.ExecuteScalar());

                return UserlevelID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public UserLevel GetItems(int id)
        {
            UserLevel item = new UserLevel();

            List<UserRight> itemalias = new List<UserRight>();

            try
            {
                string strSQL = "SELECT LEVEL_ID as ID, LEVEL_NAME, CAN_VIEW_COST, " +
                        "IS_INACTIVE, COMPANY_ID FROM TB_USER_LEVELS " +
                         "WHERE IS_DELETED = 0 AND TB_USER_LEVELS.LEVEL_ID = " + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "Items");

                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    item = new UserLevel
                    {

                        ID = ADO.ToInt32(dr["ID"]),
                        LEVEL_NAME = ADO.ToString(dr["LEVEL_NAME"]),
                        CAN_VIEW_COST = ADO.Toboolean(dr["CAN_VIEW_COST"]),
                        IS_INACTIVE = ADO.Toboolean(dr["IS_INACTIVE"]),
                        COMPANY_ID = ADO.ToInt32(dr["COMPANY_ID"])

                    };
                }



                // Query to get item aliases
                strSQL = "SELECT * FROM TB_USER_RIGHTS WHERE LEVEL_ID =" + id;

                DataTable tblItemAlias = ADO.GetDataTable(strSQL, "ItemAlias");

                foreach (DataRow dr1 in tblItemAlias.Rows)
                {
                    itemalias.Add(new UserRight
                    {
                        ID = ADO.ToInt32(dr1["ID"]),
                        MODULE_ID = ADO.ToInt32(dr1["MODULE_ID"]),
                        IS_ADD = ADO.Toboolean(dr1["IS_ADD"]),
                        IS_VIEW = ADO.Toboolean(dr1["IS_VIEW"]),
                        IS_MODIFY = ADO.Toboolean(dr1["IS_MODIFY"]),
                        IS_DELETE = ADO.Toboolean(dr1["IS_DELETE"]),
                        IS_VERIFY = ADO.Toboolean(dr1["IS_VERIFY"]),
                        IS_APPROVE = ADO.Toboolean(dr1["IS_APPROVE"]),
                        IS_PRINT = ADO.Toboolean(dr1["IS_PRINT"]),
                        IS_EXPORT = ADO.Toboolean(dr1["IS_EXPORT"])
                    });
                }


                item.rights = itemalias;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public bool Delete(int id)
        {
            try
            {
                SqlConnection connection = ADO.GetConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_USER_LEVELS";
                cmd.Parameters.AddWithValue("ACTION", 4);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
