using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class DropDownService:IDropDownService
    {
        public List<DropDown> GetDropDownData(string vName)
        {
            List<DropDown> vList = new List<DropDown>();
            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GET_DROPDOWN_DATA";
                cmd.Parameters.AddWithValue("@NAME", vName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    vList.Add(new DropDown
                    {
                        ID = Convert.ToInt32(dr["ID"]),

                        DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]),
                        REMARKS = ADO.ToString(dr["REMARKS"])
                    });
                }
                connection.Close();
            }
            return vList;
        }
    }
}
