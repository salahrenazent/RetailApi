using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class MasterDataService:IMasterDataService
    {
        public MasterDataResponse GetMasterList()
        {

            MasterDataResponse response = new MasterDataResponse();
            response.Department = new List<MasterData>();
            response.Category = new List<MasterData>();
            response.SubCategory = new List<MasterData>();
            response.Brand = new List<MasterData>();
            response.Supplier = new List<MasterData>();

            SqlConnection connection = ADO.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MASTER_DATA";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Process Department
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    response.Department.Add(new MasterData
                    {
                        ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0,
                        CODE = dr["CODE"] != DBNull.Value ? Convert.ToString(dr["CODE"]) : string.Empty,
                        DESCRIPTION = dr["DESCRIPTION"] != DBNull.Value ? Convert.ToString(dr["DESCRIPTION"]) : string.Empty
                    });
                }
            }

            // Category
            if (ds.Tables.Count > 1)
            {
                foreach (DataRow dr1 in ds.Tables[1].Rows)
                {
                    response.Category.Add(new MasterData
                    {
                        ID = dr1["ID"] != DBNull.Value ? Convert.ToInt32(dr1["ID"]) : 0,
                        CODE = dr1["CODE"] != DBNull.Value ? Convert.ToString(dr1["CODE"]) : string.Empty,
                        DESCRIPTION = dr1["DESCRIPTION"] != DBNull.Value ? Convert.ToString(dr1["DESCRIPTION"]) : string.Empty
                    });
                }
            }

            // SubCategory
            if (ds.Tables.Count > 2)
            {
                foreach (DataRow dr2 in ds.Tables[2].Rows)
                {
                    response.SubCategory.Add(new MasterData
                    {
                        ID = dr2["ID"] != DBNull.Value ? Convert.ToInt32(dr2["ID"]) : 0,
                        CODE = dr2["CODE"] != DBNull.Value ? Convert.ToString(dr2["CODE"]) : string.Empty,
                        DESCRIPTION = dr2["DESCRIPTION"] != DBNull.Value ? Convert.ToString(dr2["DESCRIPTION"]) : string.Empty
                    });
                }
            }

            //Brand
            if (ds.Tables.Count > 3)
            {
                foreach (DataRow dr3 in ds.Tables[3].Rows)
                {
                    response.Brand.Add(new MasterData
                    {
                        ID = dr3["ID"] != DBNull.Value ? Convert.ToInt32(dr3["ID"]) : 0,
                        CODE = dr3["CODE"] != DBNull.Value ? Convert.ToString(dr3["CODE"]) : string.Empty,
                        DESCRIPTION = dr3["DESCRIPTION"] != DBNull.Value ? Convert.ToString(dr3["DESCRIPTION"]) : string.Empty
                    });
                }
            }

            //Supplier
            if (ds.Tables.Count > 4)
            {
                foreach (DataRow dr4 in ds.Tables[4].Rows)
                {
                    response.Supplier.Add(new MasterData
                    {
                        ID = dr4["ID"] != DBNull.Value ? Convert.ToInt32(dr4["ID"]) : 0,
                        CODE = dr4["CODE"] != DBNull.Value ? Convert.ToString(dr4["CODE"]) : string.Empty,
                        DESCRIPTION = dr4["DESCRIPTION"] != DBNull.Value ? Convert.ToString(dr4["DESCRIPTION"]) : string.Empty
                    });
                }
            }
            return response;
        }
    }
}
