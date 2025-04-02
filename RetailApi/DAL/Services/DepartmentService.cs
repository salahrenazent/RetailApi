using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class DepartmentService:IDepartmentService
    {
        public List<Department> GetAllDepartments()
        {
            List<Department> departmentList = new List<Department>();

            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_TB_DEPARTMENT"
                };
                cmd.Parameters.AddWithValue("ACTION", 0);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    departmentList.Add(new Department
                    {
                        ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]),
                        CODE = Convert.IsDBNull(dr["CODE"]) ? null : Convert.ToString(dr["CODE"]),
                        DEPT_NAME = Convert.IsDBNull(dr["DEPT_NAME"]) ? null : Convert.ToString(dr["DEPT_NAME"]),
                        COMPANY_NAME = Convert.IsDBNull(dr["COMPANY_NAME"]) ? null : Convert.ToString(dr["COMPANY_NAME"]),
                        COMPANY_ID = Convert.IsDBNull(dr["COMPANY_ID"]) ? 0 : Convert.ToInt32(dr["COMPANY_ID"]),
                        IS_ACTIVE = Convert.IsDBNull(dr["COMPANY_NAME"]) ? true : Convert.ToBoolean(dr["IS_ACTIVE"])
                    });
                }

                connection.Close();
            }
            return departmentList;
        }

        public int SaveDepartment(Department department)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SP_TB_DEPARTMENT"
                    };

                    cmd.Parameters.AddWithValue("ACTION", 1);
                    cmd.Parameters.AddWithValue("ID", (object)department.ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("CODE", (object)department.CODE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DEPT_NAME", (object)department.DEPT_NAME ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("COMPANY_ID", (object)department.COMPANY_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IS_ACTIVE", (object)department.IS_ACTIVE ?? DBNull.Value);

                    int departmentID = Convert.ToInt32(cmd.ExecuteScalar());
                    return departmentID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Department GetDepartmentById(int id)
        {
            Department department = new Department();

            try
            {
                string strSQL = "SELECT ID, CODE, DEPT_NAME, COMPANY_ID,IS_ACTIVE, IS_DELETED FROM TB_DEPARTMENT WHERE ID = " + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "Department");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    department.ID = Convert.ToInt32(dr["ID"]);
                    department.CODE = Convert.ToString(dr["CODE"]);
                    department.DEPT_NAME = Convert.ToString(dr["DEPT_NAME"]);
                    department.COMPANY_ID = Convert.ToInt32(dr["COMPANY_ID"]);
                    department.IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                    department.IS_DELETED = Convert.ToBoolean(dr["IS_DELETED"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return department;
        }

        public bool DeleteDepartment(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SP_TB_DEPARTMENT"
                    };
                    cmd.Parameters.AddWithValue("ACTION", 4);//delete
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
    }
}
