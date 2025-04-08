using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class EmployeeService:IEmployeeService
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_EMPLOYEE";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    employeeList.Add(new Employee
                    {

                        ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]),
                        EMP_CODE = Convert.IsDBNull(dr["EMP_CODE"]) ? null : Convert.ToString(dr["EMP_CODE"]),
                        EMP_NAME = Convert.IsDBNull(dr["EMP_NAME"]) ? null : Convert.ToString(dr["EMP_NAME"]),
                        DOB = Convert.IsDBNull(dr["DOB"]) ? (DateTime?)null : Convert.ToDateTime(dr["DOB"]),
                        ADDRESS1 = Convert.IsDBNull(dr["ADDRESS1"]) ? null : Convert.ToString(dr["ADDRESS1"]),
                        ADDRESS2 = Convert.IsDBNull(dr["ADDRESS2"]) ? null : Convert.ToString(dr["ADDRESS2"]),
                        ADDRESS3 = Convert.IsDBNull(dr["ADDRESS3"]) ? null : Convert.ToString(dr["ADDRESS3"]),
                        STATE_ID = Convert.IsDBNull(dr["STATE_ID"]) ? 0 : Convert.ToInt32(dr["STATE_ID"]),
                        CITY = Convert.IsDBNull(dr["CITY"]) ? null : Convert.ToString(dr["CITY"]),
                        COUNTRY_ID = Convert.IsDBNull(dr["COUNTRY_ID"]) ? 0 : Convert.ToInt32(dr["COUNTRY_ID"]),
                        MOBILE = Convert.IsDBNull(dr["MOBILE"]) ? null : Convert.ToString(dr["MOBILE"]),
                        EMAIL = Convert.IsDBNull(dr["EMAIL"]) ? null : Convert.ToString(dr["EMAIL"]),
                        IS_MALE = Convert.IsDBNull(dr["IS_MALE"]) ? (bool?)null : Convert.ToBoolean(dr["IS_MALE"]),
                        DEPT_ID = Convert.IsDBNull(dr["DEPT_ID"]) ? 0 : Convert.ToInt32(dr["DEPT_ID"]),
                        DESG_ID = Convert.IsDBNull(dr["DESG_ID"]) ? 0 : Convert.ToInt32(dr["DESG_ID"]),
                        DOJ = Convert.IsDBNull(dr["DOJ"]) ? (DateTime?)null : Convert.ToDateTime(dr["DOJ"]),
                        BANK_CODE = Convert.IsDBNull(dr["BANK_CODE"]) ? null : Convert.ToString(dr["BANK_CODE"]),
                        BANK_AC_NO = Convert.IsDBNull(dr["BANK_AC_NO"]) ? null : Convert.ToString(dr["BANK_AC_NO"]),
                        PP_NO = Convert.IsDBNull(dr["PP_NO"]) ? null : Convert.ToString(dr["PP_NO"]),
                        PP_EXPIRY = Convert.IsDBNull(dr["PP_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["PP_EXPIRY"]),
                        IQAMA_NO = Convert.IsDBNull(dr["IQAMA_NO"]) ? null : Convert.ToString(dr["IQAMA_NO"]),
                        IQAMA_EXPIRY = Convert.IsDBNull(dr["IQAMA_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["IQAMA_EXPIRY"]),
                        VISA_NO = Convert.IsDBNull(dr["VISA_NO"]) ? null : Convert.ToString(dr["VISA_NO"]),
                        VISA_EXPIRY = Convert.IsDBNull(dr["VISA_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["VISA_EXPIRY"]),
                        LICENSE_NO = Convert.IsDBNull(dr["LICENSE_NO"]) ? null : Convert.ToString(dr["LICENSE_NO"]),
                        LICENSE_EXPIRY = Convert.IsDBNull(dr["LICENSE_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["LICENSE_EXPIRY"]),
                        EMP_STATUS = Convert.IsDBNull(dr["EMP_STATUS"]) ? 0 : Convert.ToInt32(dr["EMP_STATUS"]),
                        IS_SALESMAN = Convert.IsDBNull(dr["IS_SALESMAN"]) ? (bool?)null : Convert.ToBoolean(dr["IS_SALESMAN"]),
                        IMAGE_NAME = Convert.IsDBNull(dr["IMAGE_NAME"]) ? null : Convert.ToString(dr["IMAGE_NAME"]),
                        WORK_PERMIT_NO = Convert.IsDBNull(dr["WORK_PERMIT_NO"]) ? null : Convert.ToString(dr["WORK_PERMIT_NO"]),
                        WORK_PERMIT_EXPIRY = Convert.IsDBNull(dr["WORK_PERMIT_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["WORK_PERMIT_EXPIRY"]),
                        IBAN_NO = Convert.IsDBNull(dr["IBAN_NO"]) ? null : Convert.ToString(dr["IBAN_NO"]),
                        DAMAN_NO = Convert.IsDBNull(dr["DAMAN_NO"]) ? null : Convert.ToString(dr["DAMAN_NO"]),
                        DAMAN_CATEGORY = Convert.IsDBNull(dr["DAMAN_CATEGORY"]) ? null : Convert.ToString(dr["DAMAN_CATEGORY"]),
                        LEAVE_CREDIT = Convert.IsDBNull(dr["LEAVE_CREDIT"]) ? (float?)null : Convert.ToSingle(dr["LEAVE_CREDIT"]),
                        LESS_SERVICE_DAYS = Convert.IsDBNull(dr["LESS_SERVICE_DAYS"]) ? (float?)null : Convert.ToSingle(dr["LESS_SERVICE_DAYS"]),
                        HOLD_SALARY = Convert.IsDBNull(dr["HOLD_SALARY"]) ? (bool?)null : Convert.ToBoolean(dr["HOLD_SALARY"]),
                        MOL_NUMBER = Convert.IsDBNull(dr["MOL_NUMBER"]) ? null : Convert.ToString(dr["MOL_NUMBER"]),
                        LAST_REJOIN_DATE = Convert.IsDBNull(dr["LAST_REJOIN_DATE"]) ? (DateTime?)null : Convert.ToDateTime(dr["LAST_REJOIN_DATE"]),
                        INCENTIVE_PERCENT = Convert.IsDBNull(dr["INCENTIVE_PERCENT"]) ? (float?)null : Convert.ToSingle(dr["INCENTIVE_PERCENT"]),
                        STORE_ID = Convert.IsDBNull(dr["STORE_ID"]) ? 0 : Convert.ToInt32(dr["STORE_ID"]),
                        IS_DELETED = Convert.IsDBNull(dr["IS_DELETED"]) ? null : Convert.ToString(dr["IS_DELETED"]),
                        STORE_NAME = Convert.IsDBNull(dr["STORE_NAME"]) ? null : Convert.ToString(dr["STORE_NAME"]),
                        STATE_NAME = Convert.IsDBNull(dr["STATE_NAME"]) ? null : Convert.ToString(dr["STATE_NAME"]),
                        COUNTRY_NAME = Convert.IsDBNull(dr["COUNTRY_NAME"]) ? null : Convert.ToString(dr["COUNTRY_NAME"]),
                        DEPT_NAME = Convert.IsDBNull(dr["DEPT_NAME"]) ? null : Convert.ToString(dr["DEPT_NAME"]),
                        DESG_NAME = Convert.IsDBNull(dr["DESG_NAME"]) ? null : Convert.ToString(dr["DESG_NAME"])
                    });
                }
                connection.Close();
            }
            return employeeList;
        }

        public Int32 SaveData(Employee employee)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_EMPLOYEE";

                    cmd.Parameters.AddWithValue("ACTION", 1);

                    //cmd.Parameters.AddWithValue("ID", employee.ID);
                    cmd.Parameters.AddWithValue("ID", (object)employee.ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("EMP_CODE", (object)employee.EMP_CODE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("EMP_NAME", (object)employee.EMP_NAME ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DOB", (object)employee.DOB ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("ADDRESS1", (object)employee.ADDRESS1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("ADDRESS2", (object)employee.ADDRESS2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("ADDRESS3", (object)employee.ADDRESS3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("STATE_ID", (object)employee.STATE_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("CITY", (object)employee.CITY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("COUNTRY_ID", (object)employee.COUNTRY_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("MOBILE", (object)employee.MOBILE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("EMAIL", (object)employee.EMAIL ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IS_MALE", (object)employee.IS_MALE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DEPT_ID", (object)employee.DEPT_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DESG_ID", (object)employee.DESG_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DOJ", (object)employee.DOJ ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("BANK_CODE", (object)employee.BANK_CODE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("BANK_AC_NO", (object)employee.BANK_AC_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("PP_NO", (object)employee.PP_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("PP_EXPIRY", (object)employee.PP_EXPIRY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IQAMA_NO", (object)employee.IQAMA_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IQAMA_EXPIRY", (object)employee.IQAMA_EXPIRY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("VISA_NO", (object)employee.VISA_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("VISA_EXPIRY", (object)employee.VISA_EXPIRY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("LICENSE_NO", (object)employee.LICENSE_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("LICENSE_EXPIRY", (object)employee.LICENSE_EXPIRY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("EMP_STATUS", (object)employee.EMP_STATUS ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IS_SALESMAN", (object)employee.IS_SALESMAN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IMAGE_NAME", (object)employee.IMAGE_NAME ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("WORK_PERMIT_NO", (object)employee.WORK_PERMIT_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("WORK_PERMIT_EXPIRY", (object)employee.WORK_PERMIT_EXPIRY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IBAN_NO", (object)employee.IBAN_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DAMAN_NO", (object)employee.DAMAN_NO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("DAMAN_CATEGORY", (object)employee.DAMAN_CATEGORY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("LEAVE_CREDIT", (object)employee.LEAVE_CREDIT ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("LESS_SERVICE_DAYS", (object)employee.LESS_SERVICE_DAYS ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("HOLD_SALARY", (object)employee.HOLD_SALARY ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("MOL_NUMBER", (object)employee.MOL_NUMBER ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("LAST_REJOIN_DATE", (object)employee.LAST_REJOIN_DATE ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("INCENTIVE_PERCENT", (object)employee.INCENTIVE_PERCENT ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("STORE_ID", (object)employee.STORE_ID ?? DBNull.Value);



                    Int32 StoreID = Convert.ToInt32(cmd.ExecuteScalar());

                    return StoreID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetItems(int id)
        {
            Employee employee = new Employee();

            try
            {
                string strSQL = "SELECT TB_EMPLOYEE.ID, TB_EMPLOYEE.EMP_CODE, TB_EMPLOYEE.EMP_NAME, TB_EMPLOYEE.DOB, " +
                "TB_EMPLOYEE.ADDRESS1, TB_EMPLOYEE.ADDRESS2, TB_EMPLOYEE.ADDRESS3, TB_EMPLOYEE.CITY, TB_EMPLOYEE.STATE_ID, " +
                "TB_EMPLOYEE.COUNTRY_ID, TB_EMPLOYEE.MOBILE, TB_EMPLOYEE.EMAIL,TB_EMPLOYEE.IS_MALE,  " +
                "TB_EMPLOYEE.DEPT_ID, TB_EMPLOYEE.DESG_ID, TB_EMPLOYEE.DOJ, TB_EMPLOYEE.BANK_CODE, TB_EMPLOYEE.BANK_AC_NO, " +
                "TB_EMPLOYEE.PP_NO, TB_EMPLOYEE.PP_EXPIRY, TB_EMPLOYEE.IQAMA_NO, TB_EMPLOYEE.IQAMA_EXPIRY, " +
                "TB_EMPLOYEE.VISA_NO, TB_EMPLOYEE.VISA_EXPIRY, TB_EMPLOYEE.LICENSE_NO, " +
                "TB_EMPLOYEE.LICENSE_EXPIRY, TB_EMPLOYEE.EMP_STATUS, TB_EMPLOYEE.IS_SALESMAN, " +
                "TB_EMPLOYEE.IMAGE_NAME, TB_EMPLOYEE.WORK_PERMIT_NO, TB_EMPLOYEE.WORK_PERMIT_EXPIRY, " +
                "TB_EMPLOYEE.IBAN_NO, TB_EMPLOYEE.DAMAN_NO, TB_EMPLOYEE.DAMAN_CATEGORY, " +
                "TB_EMPLOYEE.LEAVE_CREDIT, TB_EMPLOYEE.LESS_SERVICE_DAYS, TB_EMPLOYEE.HOLD_SALARY, " +
                "TB_EMPLOYEE.MOL_NUMBER, TB_EMPLOYEE.LAST_REJOIN_DATE, TB_EMPLOYEE.INCENTIVE_PERCENT, " +
                "TB_EMPLOYEE.IS_DELETED, TB_EMPLOYEE.STORE_ID, " +

                "TB_STATE.STATE_NAME, TB_COUNTRY.COUNTRY_NAME, TB_EMPLOYEE_DEPARTMENT.DEPT_NAME, " +
                "TB_EMPLOYEE_DESIGNATION.DESG_NAME, TB_STORES.STORE_NAME " + // Added space here
                "FROM TB_EMPLOYEE " +
                "LEFT JOIN TB_STATE ON TB_EMPLOYEE.STATE_ID = TB_STATE.ID " +
                "LEFT JOIN TB_COUNTRY ON TB_EMPLOYEE.COUNTRY_ID = TB_COUNTRY.ID " +
                "LEFT JOIN TB_EMPLOYEE_DEPARTMENT ON TB_EMPLOYEE.DEPT_ID = TB_EMPLOYEE_DEPARTMENT.ID " +
                "LEFT JOIN TB_EMPLOYEE_DESIGNATION ON TB_EMPLOYEE.DESG_ID = TB_EMPLOYEE_DESIGNATION.ID " +
                "LEFT JOIN TB_STORES ON TB_EMPLOYEE.STORE_ID = TB_STORES.ID " +
                "WHERE TB_EMPLOYEE.ID = " + id;


                DataTable tbl = ADO.GetDataTable(strSQL, "Employee");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    employee.ID = Convert.ToInt32(dr["ID"]);
                    employee.EMP_CODE = Convert.ToString(dr["EMP_CODE"]);
                    employee.EMP_NAME = Convert.ToString(dr["EMP_NAME"]);
                    employee.DOB = Convert.IsDBNull(dr["DOB"]) ? (DateTime?)null : Convert.ToDateTime(dr["DOB"]);

                    employee.ADDRESS1 = Convert.ToString(dr["ADDRESS1"]);
                    employee.ADDRESS2 = Convert.ToString(dr["ADDRESS2"]);
                    employee.ADDRESS3 = Convert.ToString(dr["ADDRESS3"]);
                    employee.STATE_ID = Convert.ToInt32(dr["STATE_ID"]);
                    employee.CITY = Convert.ToString(dr["CITY"]);
                    employee.COUNTRY_ID = Convert.ToInt32(dr["COUNTRY_ID"]);
                    employee.MOBILE = Convert.ToString(dr["MOBILE"]);
                    employee.EMAIL = Convert.ToString(dr["EMAIL"]);
                    employee.IS_MALE = Convert.ToBoolean(dr["IS_MALE"]);
                    employee.DEPT_ID = Convert.ToInt32(dr["DEPT_ID"]);
                    employee.DESG_ID = Convert.ToInt32(dr["DESG_ID"]);
                    employee.DOJ = Convert.IsDBNull(dr["DOJ"]) ? (DateTime?)null : Convert.ToDateTime(dr["DOJ"]);

                    employee.BANK_CODE = Convert.ToString(dr["BANK_CODE"]);
                    employee.BANK_AC_NO = Convert.ToString(dr["BANK_AC_NO"]);
                    employee.PP_NO = Convert.ToString(dr["PP_NO"]);
                    //employee.PP_EXPIRY = Convert.ToDateTime(dr["PP_EXPIRY"]);
                    employee.PP_EXPIRY = Convert.IsDBNull(dr["PP_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["PP_EXPIRY"]);

                    employee.IQAMA_NO = Convert.ToString(dr["IQAMA_NO"]);
                    //employee.IQAMA_EXPIRY = Convert.ToDateTime(dr["IQAMA_EXPIRY"]);
                    employee.IQAMA_EXPIRY = Convert.IsDBNull(dr["IQAMA_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["IQAMA_EXPIRY"]);

                    employee.VISA_NO = Convert.ToString(dr["VISA_NO"]);
                    employee.VISA_EXPIRY = Convert.ToDateTime(dr["VISA_EXPIRY"]);
                    employee.LICENSE_NO = Convert.ToString(dr["LICENSE_NO"]);
                    //  employee.LICENSE_EXPIRY = Convert.ToDateTime(dr["LICENSE_EXPIRY"]);
                    employee.LICENSE_EXPIRY = Convert.IsDBNull(dr["LICENSE_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["LICENSE_EXPIRY"]);

                    employee.EMP_STATUS = Convert.ToInt32(dr["EMP_STATUS"]);
                    employee.IS_SALESMAN = Convert.ToBoolean(dr["IS_SALESMAN"]);
                    employee.IMAGE_NAME = Convert.ToString(dr["IMAGE_NAME"]);
                    employee.WORK_PERMIT_NO = Convert.ToString(dr["WORK_PERMIT_NO"]);
                    //employee.WORK_PERMIT_EXPIRY = Convert.ToDateTime(dr["WORK_PERMIT_EXPIRY"]);
                    employee.WORK_PERMIT_EXPIRY = Convert.IsDBNull(dr["WORK_PERMIT_EXPIRY"]) ? (DateTime?)null : Convert.ToDateTime(dr["WORK_PERMIT_EXPIRY"]);

                    employee.IBAN_NO = Convert.ToString(dr["IBAN_NO"]);
                    employee.DAMAN_NO = Convert.ToString(dr["DAMAN_NO"]);
                    employee.DAMAN_CATEGORY = Convert.ToString(dr["DAMAN_CATEGORY"]);
                    employee.LEAVE_CREDIT = float.Parse(dr["LEAVE_CREDIT"].ToString());
                    employee.LESS_SERVICE_DAYS = float.Parse(dr["LESS_SERVICE_DAYS"].ToString());
                    employee.HOLD_SALARY = Convert.ToBoolean(dr["HOLD_SALARY"]);
                    employee.MOL_NUMBER = Convert.ToString(dr["MOL_NUMBER"]);
                    //employee.LAST_REJOIN_DATE = Convert.ToDateTime(dr["LAST_REJOIN_DATE"]);
                    employee.LAST_REJOIN_DATE = Convert.IsDBNull(dr["LAST_REJOIN_DATE"]) ? (DateTime?)null : Convert.ToDateTime(dr["LAST_REJOIN_DATE"]);

                    employee.INCENTIVE_PERCENT = float.Parse(dr["INCENTIVE_PERCENT"].ToString());
                    employee.STORE_ID = Convert.ToInt32(dr["STORE_ID"]);
                    employee.IS_DELETED = Convert.ToString(dr["IS_DELETED"]);

                    employee.STORE_NAME = Convert.ToString(dr["STORE_NAME"]);

                    employee.STATE_NAME = Convert.ToString(dr["STATE_NAME"]);
                    employee.COUNTRY_NAME = Convert.ToString(dr["COUNTRY_NAME"]);
                    employee.DEPT_NAME = Convert.ToString(dr["DEPT_NAME"]);
                    employee.DESG_NAME = Convert.ToString(dr["DESG_NAME"]);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employee;
        }

        public bool DeleteEmployees(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_EMPLOYEE";
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
