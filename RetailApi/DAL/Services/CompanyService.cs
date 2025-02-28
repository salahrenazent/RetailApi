using RetailApi.Helper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Runtime;
using RetailApi.Models;
using System.Data.SqlClient;
using RetailApi.DAL.Interfaces;

namespace RetailApi.DAL.Services
{
    public class CompanyService:ICompanyService
    {
        public List<Company> GetAllCompany()
        {
            List<Company> companyList = new List<Company>();


            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TB_COMPANY";
            cmd.Parameters.AddWithValue("ACTION", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                companyList.Add(new Company
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    COMPANY_NAME = Convert.ToString(dr["COMPANY_NAME"]),
                    ADDRESS1 = Convert.ToString(dr["ADDRESS1"]),
                    ADDRESS2 = Convert.ToString(dr["ADDRESS2"]),
                    ADDRESS3 = Convert.ToString(dr["ADDRESS3"]),
                    CITY = Convert.ToString(dr["CITY"]),
                    STATE = Convert.ToString(dr["STATE"]),
                    WEBSITE = Convert.ToString(dr["WEBSITE"]),
                    COUNTRY_NAME = dr["COUNTRY_NAME"].ToString(),
                    COUNTRY_ID = dr["COUNTRY_ID"].ToString(),
                    PHONE = Convert.ToString(dr["PHONE"]),
                    EMAIL = Convert.ToString(dr["EMAIL"]),
                    VAT_REGN_NO = Convert.ToString(dr["VAT_REGN_NO"])

                });
            }
            connection.Close();

            return companyList;
        }
        public Int32 SaveData(Company company)
        {
            try
            {

                SqlConnection connection = ADO.GetConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_COMPANY";

                cmd.Parameters.AddWithValue("ACTION", 1);
                cmd.Parameters.AddWithValue("ID", company.ID);


                cmd.Parameters.AddWithValue("COMPANY_NAME", company.COMPANY_NAME);
                cmd.Parameters.AddWithValue("ADDRESS1", company.ADDRESS1);
                cmd.Parameters.AddWithValue("ADDRESS2", company.ADDRESS2);
                cmd.Parameters.AddWithValue("ADDRESS3", company.ADDRESS3);
                cmd.Parameters.AddWithValue("CITY", company.CITY);
                cmd.Parameters.AddWithValue("STATE", company.STATE);
                cmd.Parameters.AddWithValue("WEBSITE", company.WEBSITE);
                cmd.Parameters.AddWithValue("COUNTRY_ID", company.COUNTRY_ID);
                cmd.Parameters.AddWithValue("PHONE", company.PHONE);
                cmd.Parameters.AddWithValue("EMAIL", company.EMAIL);
                cmd.Parameters.AddWithValue("VAT_REGN_NO", company.VAT_REGN_NO);
                Int32 UserID = Convert.ToInt32(cmd.ExecuteScalar());
                return UserID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Company GetItems(int id)
        {
            Company company = new Company();

            try
            {
                string strSQL =
                    "SELECT TB_COMPANY.ID, TB_COMPANY.COMPANY_NAME, TB_COMPANY.ADDRESS1,TB_COMPANY.ADDRESS2, " +
                "TB_COMPANY.ADDRESS3, TB_COMPANY.CITY, TB_COMPANY.STATE, TB_COMPANY.WEBSITE, TB_COMPANY.PHONE, TB_COMPANY.EMAIL," +
                " TB_COMPANY.VAT_REGN_NO, " +
                "TB_COUNTRY.COUNTRY_NAME " +
                  "FROM TB_COMPANY INNER JOIN TB_COUNTRY ON TB_COMPANY.COUNTRY_ID = TB_COUNTRY.ID " +
                  " WHERE TB_COMPANY.ID = " + id;


                DataTable tbl = ADO.GetDataTable(strSQL, "Company");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    company.ID = Convert.ToInt32(dr["ID"]);
                    company.COMPANY_NAME = Convert.ToString(dr["COMPANY_NAME"]);
                    company.ADDRESS1 = Convert.ToString(dr["ADDRESS1"]);
                    company.ADDRESS2 = Convert.ToString(dr["ADDRESS2"]);
                    company.ADDRESS3 = Convert.ToString(dr["ADDRESS3"]);
                    company.CITY = Convert.ToString(dr["CITY"]);
                    company.STATE = Convert.ToString(dr["STATE"]);
                    company.WEBSITE = Convert.ToString(dr["WEBSITE"]);
                    company.PHONE = Convert.ToString(dr["PHONE"]);
                    company.EMAIL = Convert.ToString(dr["EMAIL"]);
                    company.VAT_REGN_NO = Convert.ToString(dr["VAT_REGN_NO"]);
                    company.COUNTRY_NAME = dr["COUNTRY_NAME"].ToString();
                    company.COUNTRY_ID = dr["COUNTRY_ID"].ToString();

                }
            }
            catch (Exception ex)
            {

            }
            return company;
        }
        public bool DeleteCompany(int id)
        {
            try
            {
                SqlConnection connection = ADO.GetConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_COMPANY";
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

        public List<DocSettings> GetAllDocSettings()
        {
            List<DocSettings> companyList = new List<DocSettings>();
            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TB_DOC_SETTINGS";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                companyList.Add(new DocSettings
                {
                    TRANS_TYPE = ADO.ToInt32(dr["TRANS_TYPE"]),
                    GROUP_CODE = ADO.ToString(dr["GROUP_CODE"]),
                    FIN_ID = ADO.ToInt32(dr["FIN_ID"]),
                    PREFIX = ADO.ToInt32(dr["PREFIX"]),
                    START = ADO.ToInt32(dr["START"]),
                    WIDTH = ADO.ToInt32(dr["WIDTH"]),
                    VERIFY_REQUIRED = Convert.ToBoolean(dr["VERIFY_REQUIRED"])
                });
            }
            connection.Close();

            return companyList;
        }
    }
}
