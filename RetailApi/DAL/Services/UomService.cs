using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class UomService:IUomService
    {
        public List<Uom> GetAllUom()
        {
            List<Uom> uomList = new List<Uom>();
            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_UOM";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                foreach (DataRow dr in tbl.Rows)
                {
                    uomList.Add(new Uom
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        UOM = Convert.ToString(dr["UOM"])
                    });
                }
                connection.Close();
            }
            return uomList;
        }
        public bool Insert(Uom uom)
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
                cmd.CommandText = "SP_TB_UOM";
                cmd.Parameters.AddWithValue("ACTION", 1);
                cmd.Parameters.AddWithValue("UOM", uom.UOM);
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
        public Uom GetItems(int id)
        {
            Uom uom = new Uom();
            try
            {
                string strSQL = "SELECT * FROM TB_UOM " +
                 "WHERE TB_UOM.ID = " + id;

                DataTable tbl = ADO.GetDataTable(strSQL, "Uom");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    uom.ID = Convert.ToInt32(dr["ID"]);
                    uom.UOM = Convert.ToString(dr["UOM"]);

                }
            }
            catch (Exception ex)
            {

            }

            return uom;
        }
        public bool Update(Uom uom)
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
                cmd.CommandText = "SP_TB_UOM";
                cmd.Parameters.AddWithValue("ACTION", 3);
                cmd.Parameters.AddWithValue("ID", uom.ID);
                cmd.Parameters.AddWithValue("UOM", uom.UOM);
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
        public bool DeleteUom(int id)
        {
            try
            {
                using (SqlConnection connection = ADO.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_TB_UOM";
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
