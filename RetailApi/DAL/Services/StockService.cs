using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class StockService:IStockService
    {
        public StockResponse GetStockWithStore(StockInput input)
        {
            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "SP_GET_STOREWISE_STOCK"
            };

            cmd.Parameters.AddWithValue("@USER_ID", input.USER_ID);
            cmd.Parameters.AddWithValue("@COMPANY_ID", input.COMPANY_ID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable stockTable = ds.Tables[0];
            DataTable columnsTable = ds.Tables[1];

            var columns = columnsTable.AsEnumerable().Select(dr => new ReportColumns
            {
                Title = ADO.ToString(dr["ColTitle"]),
                Name = ADO.ToString(dr["ColName"]),
                Type = ADO.ToString(dr["ColType"]),
                Visibility = ADO.Toboolean(dr["ColIsVisible"]),
                Group = ADO.Toboolean(dr["ColIsGroup"]),
                Summary = ADO.Toboolean(dr["ColIsSummary"])
            }).ToList();

            var stocklist = stockTable.AsEnumerable().Select(dr => new Stock
            {
                DESCRIPTION = ADO.ToString(dr["ITEM_DESCRPTION"]),
                DEPT_NAME = ADO.ToString(dr["DEPT_NAME"]),
                CAT_NAME = ADO.ToString(dr["CAT_NAME"]),
                BRAND_NAME = ADO.ToString(dr["BRAND_NAME"]),
                BARCODE = ADO.ToString(dr["BARCODE"]),
                DUBAI = ADO.ToString(dr["DUBAI"]),
                SHARJAH = ADO.ToString(dr["SHARJAH"]),
                AJMAN = ADO.ToString(dr["AJMAN"]),
                TOTAL = ADO.ToDecimal(dr["TOTAL"]),
            }).ToList();

            connection.Close();

            return new StockResponse
            {
                Data = stocklist,
                Columns = columns
            };
        }
    }
}
