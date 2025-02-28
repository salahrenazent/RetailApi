using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class PackingService:IPackingService
    {
        public List<Packing> GetAllPacking()
        {
            List<Packing> packingList = new List<Packing>();
            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_PACKING";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                foreach (DataRow dr in tbl.Rows)
                {
                    packingList.Add(new Packing
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]),
                        NO_OF_UNITS = Convert.ToInt32(dr["NO_OF_UNITS"])
                    });
                }
                connection.Close();
            }
            return packingList;
        }
        public bool Insert(Packing packing)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_PACKING";
                cmd.Parameters.AddWithValue("ACTION", 1);
                cmd.Parameters.AddWithValue("DESCRIPTION", packing.DESCRIPTION);
                cmd.Parameters.AddWithValue("NO_OF_UNITS", packing.NO_OF_UNITS);
                cmd.ExecuteNonQuery();
                objtrans.Commit();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                objtrans.Rollback();
                connection.Close();
                throw ex;
            }
        }
        public Packing GetItems(int id)
        {
            Packing packing = new Packing();
            try
            {
                string strSQL = "SELECT * FROM TB_PACKING " +
                 "WHERE TB_PACKING.ID = " + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "Packing");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    packing.ID = Convert.ToInt32(dr["ID"]);
                    packing.DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]);
                    packing.NO_OF_UNITS = Convert.ToInt32(dr["NO_OF_UNITS"]);
                }
            }
            catch (Exception ex)
            {

            }

            return packing;
        }
        public bool Update(Packing packing)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_PACKING";
                cmd.Parameters.AddWithValue("ACTION", 2);
                cmd.Parameters.AddWithValue("ID", packing.ID);
                cmd.Parameters.AddWithValue("DESCRIPTION", packing.DESCRIPTION);
                cmd.Parameters.AddWithValue("NO_OF_UNITS", packing.NO_OF_UNITS);
                cmd.ExecuteNonQuery();
                objtrans.Commit();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                objtrans.Rollback();
                connection.Close();
                throw ex;
            }
        }
        public bool DeletePacking(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_PACKING";
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
