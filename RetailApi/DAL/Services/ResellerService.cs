using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class ResellerService:IResellerService
    {
        public List<Reseller> GetAllReseller()
        {
            List<Reseller> resellerList = new List<Reseller>();


            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_RESELLER";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    resellerList.Add(new Reseller
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        RESELLER_CODE = Convert.ToString(dr["RESELLER_CODE"]),
                        RESELLER_NAME = Convert.ToString(dr["RESELLER_NAME"]),
                        RESELLER_PHONE = Convert.ToString(dr["RESELLER_PHONE"]),
                        COUNTRY_NAME = dr["COUNTRY_NAME"].ToString(),
                        COUNTRY_ID = dr["COUNTRY_ID"].ToString(),
                        RESELLER_EMAIL = Convert.ToString(dr["RESELLER_EMAIL"])

                    });
                }
                connection.Close();
            }
            return resellerList;
        }

        public Int32 Insert(Reseller reseller)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_RESELLER";
                    cmd.Parameters.AddWithValue("ACTION", 1);
                    cmd.Parameters.AddWithValue("RESELLER_CODE", reseller.RESELLER_CODE);
                    cmd.Parameters.AddWithValue("RESELLER_NAME", reseller.RESELLER_NAME);
                    cmd.Parameters.AddWithValue("RESELLER_PHONE", reseller.RESELLER_PHONE);
                    cmd.Parameters.AddWithValue("RESELLER_EMAIL", reseller.RESELLER_EMAIL);

                    cmd.Parameters.AddWithValue("COUNTRY_ID", reseller.COUNTRY_ID);

                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = connection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "SELECT MAX(ID) FROM TB_RESELLER";
                    Int32 ResellerID = Convert.ToInt32(cmd1.ExecuteScalar());

                    return ResellerID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Reseller GetItems(int id)
        {
            Reseller reseller = new Reseller();
            try
            {
                string strSQL = "SELECT TB_RESELLER.ID,TB_RESELLER.RESELLER_CODE,TB_RESELLER.RESELLER_NAME, TB_RESELLER.RESELLER_PHONE, " +
                                " TB_RESELLER.RESELLER_EMAIL, TB_RESELLER.COUNTRY_ID," +

                                "TB_COUNTRY.COUNTRY_NAME " +
                                "FROM TB_RESELLER INNER JOIN TB_COUNTRY ON TB_RESELLER.COUNTRY_ID = TB_COUNTRY.ID " +
                                " WHERE IS_DELETED = 0 AND TB_RESELLER.ID = " + id;




                DataTable tbl = ADO.GetDataTable(strSQL, "Reseller");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    reseller.ID = Convert.ToInt32(dr["ID"]);
                    reseller.RESELLER_CODE = Convert.ToString(dr["RESELLER_CODE"]);
                    reseller.RESELLER_NAME = Convert.ToString(dr["RESELLER_NAME"]);
                    reseller.RESELLER_PHONE = Convert.ToString(dr["RESELLER_PHONE"]);
                    reseller.RESELLER_EMAIL = Convert.ToString(dr["RESELLER_EMAIL"]);
                    reseller.COUNTRY_NAME = dr["COUNTRY_NAME"].ToString();
                    reseller.COUNTRY_ID = dr["COUNTRY_ID"].ToString();


                }
            }
            catch (Exception ex)
            {

            }

            return reseller;
        }

        public bool Update(Reseller reseller)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_RESELLER";
                    cmd.Parameters.AddWithValue("ACTION", 3);

                    cmd.Parameters.AddWithValue("ID", reseller.ID);
                    cmd.Parameters.AddWithValue("RESELLER_CODE", reseller.RESELLER_CODE);
                    cmd.Parameters.AddWithValue("RESELLER_NAME", reseller.RESELLER_NAME);
                    cmd.Parameters.AddWithValue("RESELLER_PHONE", reseller.RESELLER_PHONE);
                    cmd.Parameters.AddWithValue("RESELLER_EMAIL", reseller.RESELLER_EMAIL);
                    cmd.Parameters.AddWithValue("COUNTRY_ID", reseller.COUNTRY_ID);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteReseller(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_RESELLER";
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
