using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class DesignationService:IDesignationService
    {
        public List<Designation> GetAllDesignations()
        {
            List<Designation> designationList = new List<Designation>();

            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_EMPLOYEE_DESIGNATION"
                };
                cmd.Parameters.AddWithValue("ACTION", 0);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    designationList.Add(new Designation
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        CODE = dr["CODE"] as string,
                        DESG_NAME = dr["DESG_NAME"] as string,
                        COMPANY_ID = Convert.IsDBNull(dr["COMPANY_ID"]) ? 0 : Convert.ToInt32(dr["COMPANY_ID"]),
                        IS_INACTIVE = Convert.IsDBNull(dr["IS_INACTIVE"]) ? false : Convert.ToBoolean(dr["IS_INACTIVE"]),
                        COMPANY_NAME = dr["COMPANY_NAME"] as string,
                    });
                }

                connection.Close();
            }
            return designationList;
        }

        public int SaveDesignation(Designation designation)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SP_EMPLOYEE_DESIGNATION"
                    };

                    cmd.Parameters.AddWithValue("ACTION", 1);
                    cmd.Parameters.AddWithValue("ID", (object)designation.ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("CODE", (object)designation.CODE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DESG_NAME", (object)designation.DESG_NAME ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("COMPANY_ID", (object)designation.COMPANY_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IS_INACTIVE", (object)designation.IS_INACTIVE ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("IS_DELETED", (object)designation.IS_DELETED ?? DBNull.Value);

                    int designationID = Convert.ToInt32(cmd.ExecuteScalar());
                    return designationID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Designation GetDesignationById(int id)
        {
            Designation designation = new Designation();

            try
            {
                string strSQL = "SELECT ID, CODE, DESG_NAME, COMPANY_ID, IS_INACTIVE, IS_DELETED FROM TB_EMPLOYEE_DESIGNATION WHERE ID = " + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "Designation");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    designation.ID = Convert.ToInt32(dr["ID"]);
                    designation.CODE = dr["CODE"] as string;
                    designation.DESG_NAME = dr["DESG_NAME"] as string;
                    designation.COMPANY_ID = Convert.IsDBNull(dr["COMPANY_ID"]) ? 0 : Convert.ToInt32(dr["COMPANY_ID"]);
                    designation.IS_INACTIVE = Convert.IsDBNull(dr["IS_INACTIVE"]) ? false : Convert.ToBoolean(dr["IS_INACTIVE"]);
                    designation.IS_DELETED = Convert.IsDBNull(dr["IS_DELETED"]) ? false : Convert.ToBoolean(dr["IS_DELETED"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return designation;
        }

        public bool DeleteDesignation(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SP_EMPLOYEE_DESIGNATION"
                    };
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
    }
}
