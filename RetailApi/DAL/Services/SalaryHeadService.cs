using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class SalaryHeadService:ISalaryHeadService
    {
        public List<SalaryHead> GetAllSalaryHead()
        {
            List<SalaryHead> salaryHeadList = new List<SalaryHead>();
            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_SALARY_HEAD";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                foreach (DataRow dr in tbl.Rows)
                {
                    salaryHeadList.Add(new SalaryHead
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        CODE = Convert.ToString(dr["CODE"]),
                        HEAD_NAME = dr["HEAD_NAME"].ToString(),
                        PRINT_DESCRIPTION = Convert.ToString(dr["PRINT_DESCRIPTION"]),
                        AC_HEAD_ID = Convert.ToInt32(dr["AC_HEAD_ID"]),
                        HEAD_TYPE = Convert.ToInt16(dr["HEAD_TYPE"]),
                        HEAD_ORDER = Convert.ToInt16(dr["HEAD_ORDER"]),
                        IS_INACTIVE = Convert.ToBoolean(dr["IS_INACTIVE"]),
                        IS_WORKING_DAY = Convert.ToBoolean(dr["IS_WORKING_DAY"]),
                        IS_SYSTEM = Convert.ToBoolean(dr["IS_SYSTEM"]),
                        IS_FIXED = Convert.ToBoolean(dr["IS_FIXED"]),
                        IS_DELETED = Convert.ToBoolean(dr["IS_DELETED"])
                    });
                }
                connection.Close();
            }
            return salaryHeadList;
        }
        public Int32 SaveData(SalaryHead salaryHead)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_SALARY_HEAD"; // Stored Procedure Name

                    cmd.Parameters.AddWithValue("ACTION", 1); // 1 for Insert/Update
                    cmd.Parameters.AddWithValue("ID", salaryHead.ID);
                    cmd.Parameters.AddWithValue("CODE", salaryHead.CODE);
                    cmd.Parameters.AddWithValue("HEAD_NAME", salaryHead.HEAD_NAME);
                    cmd.Parameters.AddWithValue("PRINT_DESCRIPTION", salaryHead.PRINT_DESCRIPTION);
                    cmd.Parameters.AddWithValue("AC_HEAD_ID", salaryHead.AC_HEAD_ID);
                    cmd.Parameters.AddWithValue("HEAD_TYPE", salaryHead.HEAD_TYPE);
                    cmd.Parameters.AddWithValue("HEAD_ORDER", salaryHead.HEAD_ORDER);
                    cmd.Parameters.AddWithValue("IS_INACTIVE", salaryHead.IS_INACTIVE);
                    cmd.Parameters.AddWithValue("IS_WORKING_DAY", salaryHead.IS_WORKING_DAY);
                    cmd.Parameters.AddWithValue("IS_SYSTEM", salaryHead.IS_SYSTEM);
                    cmd.Parameters.AddWithValue("IS_FIXED", salaryHead.IS_FIXED);
                    cmd.Parameters.AddWithValue("IS_DELETED", salaryHead.IS_DELETED);

                    Int32 result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 EditData(SalaryHead salaryHead)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_SALARY_HEAD"; // Stored Procedure Name

                    cmd.Parameters.AddWithValue("ACTION", 2); // 1 for Insert/Update
                    cmd.Parameters.AddWithValue("ID", salaryHead.ID);
                    cmd.Parameters.AddWithValue("CODE", salaryHead.CODE);
                    cmd.Parameters.AddWithValue("HEAD_NAME", salaryHead.HEAD_NAME);
                    cmd.Parameters.AddWithValue("PRINT_DESCRIPTION", salaryHead.PRINT_DESCRIPTION);
                    cmd.Parameters.AddWithValue("AC_HEAD_ID", salaryHead.AC_HEAD_ID);
                    cmd.Parameters.AddWithValue("HEAD_TYPE", salaryHead.HEAD_TYPE);
                    cmd.Parameters.AddWithValue("HEAD_ORDER", salaryHead.HEAD_ORDER);
                    cmd.Parameters.AddWithValue("IS_INACTIVE", salaryHead.IS_INACTIVE);
                    cmd.Parameters.AddWithValue("IS_WORKING_DAY", salaryHead.IS_WORKING_DAY);
                    cmd.Parameters.AddWithValue("IS_SYSTEM", salaryHead.IS_SYSTEM);
                    cmd.Parameters.AddWithValue("IS_FIXED", salaryHead.IS_FIXED);
                    cmd.Parameters.AddWithValue("IS_DELETED", salaryHead.IS_DELETED);

                    Int32 result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SalaryHead GetItem(int id)
        {
            SalaryHead salaryHead = new SalaryHead();

            try
            {
                string strSQL = "SELECT * FROM TB_SALARY_HEAD WHERE ID =" + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "TB_SALARY_HEAD");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    salaryHead.ID = Convert.ToInt32(dr["ID"]);
                    salaryHead.CODE = Convert.ToString(dr["CODE"]);
                    salaryHead.HEAD_NAME = Convert.ToString(dr["HEAD_NAME"]);
                    salaryHead.PRINT_DESCRIPTION = Convert.ToString(dr["PRINT_DESCRIPTION"]);
                    salaryHead.AC_HEAD_ID = dr["AC_HEAD_ID"] != DBNull.Value ? Convert.ToInt32(dr["AC_HEAD_ID"]) : (int?)null;
                    salaryHead.HEAD_TYPE = dr["HEAD_TYPE"] != DBNull.Value ? Convert.ToInt16(dr["HEAD_TYPE"]) : (short?)null;
                    salaryHead.HEAD_ORDER = dr["HEAD_ORDER"] != DBNull.Value ? Convert.ToInt16(dr["HEAD_ORDER"]) : (short?)null;
                    salaryHead.IS_INACTIVE = Convert.ToBoolean(dr["IS_INACTIVE"]);
                    salaryHead.IS_WORKING_DAY = Convert.ToBoolean(dr["IS_WORKING_DAY"]);
                    salaryHead.IS_SYSTEM = Convert.ToBoolean(dr["IS_SYSTEM"]);
                    salaryHead.IS_FIXED = Convert.ToBoolean(dr["IS_FIXED"]);
                    salaryHead.IS_DELETED = Convert.ToBoolean(dr["IS_DELETED"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salaryHead;
        }

        public bool DeleteSalaryHead(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_SALARY_HEAD";
                    cmd.Parameters.AddWithValue("ACTION", 3); // 3 for Delete
                    cmd.Parameters.AddWithValue("ID", id);
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
    }
}
