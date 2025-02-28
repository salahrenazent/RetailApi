using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class TransferOutService:ITransferOutService
    {
        public List<ItemDetails> GetItems(InputStore input)
        {
            List<ItemDetails> itemDetails = new List<ItemDetails>();
            SqlConnection connection = ADO.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ITEM_DETAILS";
            cmd.Parameters.AddWithValue("@STORE_ID", input.STORE_ID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            itemDetails = tbl.AsEnumerable().Select(dr => new ItemDetails
            {
                ITEM_ID = ADO.ToInt32(dr["ITEM_ID"]),
                UNIT_ID = ADO.ToInt32(dr["UNIT_ID"]),
                UOM = ADO.ToString(dr["UOM"]),
                COST = ADO.ToDecimal(dr["COST"]),
                ITEM_CODE = ADO.ToString(dr["ITEM_CODE"]),
                ITEM_NAME = ADO.ToString(dr["DESCRIPTION"]),
                BAR_CODE = ADO.ToString(dr["BARCODE"]),
                QTY_STOCK = ADO.ToDecimal(dr["QTY_STOCK"]),
                STORE_SALE_PRICE = ADO.ToDecimal(dr["STORE_SALE_PRICE"]),
                ITEM_SALE_PRICE = ADO.ToDecimal(dr["ITEM_SALE_PRICE"]),
            }).ToList();

            connection.Close();

            return itemDetails;
        }
        public Int32 Insert(TransferOut transferOut)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();

            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("COMPANY_ID", typeof(Int32));
                tbl.Columns.Add("STORE_ID", typeof(Int32));
                tbl.Columns.Add("ITEM_ID", typeof(Int32));
                tbl.Columns.Add("UOM", typeof(string));
                tbl.Columns.Add("QUANTITY", typeof(float));
                tbl.Columns.Add("COST", typeof(float));
                tbl.Columns.Add("AMOUNT", typeof(float));
                tbl.Columns.Add("BATCH_NO", typeof(string));
                tbl.Columns.Add("EXPIRY_DATE", typeof(DateTime));

                if (transferOut.TransferOutDetail != null && transferOut.TransferOutDetail.Any())
                {
                    foreach (TransferOutDetails ur in transferOut.TransferOutDetail)
                    {
                        DataRow dRow = tbl.NewRow();

                        dRow["COMPANY_ID"] = ur.COMPANY_ID;
                        dRow["STORE_ID"] = ur.STORE_ID;
                        dRow["ITEM_ID"] = ur.ITEM_ID;
                        dRow["UOM"] = ur.UOM;
                        dRow["QUANTITY"] = ur.QUANTITY;
                        dRow["COST"] = ur.COST;
                        dRow["AMOUNT"] = ur.AMOUNT;
                        dRow["BATCH_NO"] = string.IsNullOrEmpty(ur.BATCH_NO) ? string.Empty : ur.BATCH_NO; // Empty string if null
                        dRow["EXPIRY_DATE"] = ur.EXPIRY_DATE ?? new DateTime(1753, 1, 1);

                        tbl.Rows.Add(dRow);
                    }
                }
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_TRANSFER_OUT";

                cmd.Parameters.AddWithValue("ACTION", 1);
                cmd.Parameters.AddWithValue("@COMPANY_ID", transferOut.COMPANY_ID);
                cmd.Parameters.AddWithValue("@STORE_ID", transferOut.STORE_ID);
                cmd.Parameters.AddWithValue("@TRANSFER_DATE", transferOut.TRANSFER_DATE);
                cmd.Parameters.AddWithValue("@DEST_STORE_ID", transferOut.DEST_STORE_ID);
                cmd.Parameters.AddWithValue("@NET_AMOUNT", transferOut.NET_AMOUNT);
                cmd.Parameters.AddWithValue("@NARRATION", transferOut.NARRATION);
                cmd.Parameters.AddWithValue("@USER_ID", transferOut.USER_ID);
                cmd.Parameters.AddWithValue("@UDT_TB_TRANSFER_OUT", tbl);

                cmd.ExecuteNonQuery();
                objtrans.Commit();

                return 0;
            }
            catch (Exception ex)
            {
                // Rollback the transaction if an error occurs
                objtrans.Rollback();
                throw;
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public Int32 Update(TransferOut transferOut)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();

            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("COMPANY_ID", typeof(Int32));
                tbl.Columns.Add("STORE_ID", typeof(Int32));
                tbl.Columns.Add("ITEM_ID", typeof(Int32));
                tbl.Columns.Add("UOM", typeof(string));
                tbl.Columns.Add("QUANTITY", typeof(float));
                tbl.Columns.Add("COST", typeof(float));
                tbl.Columns.Add("AMOUNT", typeof(float));
                tbl.Columns.Add("BATCH_NO", typeof(string));
                tbl.Columns.Add("EXPIRY_DATE", typeof(DateTime));

                if (transferOut.TransferOutDetail != null && transferOut.TransferOutDetail.Any())
                {
                    foreach (TransferOutDetails ur in transferOut.TransferOutDetail)
                    {
                        DataRow dRow = tbl.NewRow();

                        dRow["COMPANY_ID"] = ur.COMPANY_ID;
                        dRow["STORE_ID"] = ur.STORE_ID;
                        dRow["ITEM_ID"] = ur.ITEM_ID;
                        dRow["UOM"] = ur.UOM;
                        dRow["QUANTITY"] = ur.QUANTITY;
                        dRow["COST"] = ur.COST;
                        dRow["AMOUNT"] = ur.AMOUNT;
                        dRow["BATCH_NO"] = string.IsNullOrEmpty(ur.BATCH_NO) ? string.Empty : ur.BATCH_NO; // Empty string if null
                        dRow["EXPIRY_DATE"] = ur.EXPIRY_DATE ?? new DateTime(1753, 1, 1);
                        tbl.Rows.Add(dRow);
                    }
                }
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_TRANSFER_OUT";

                cmd.Parameters.AddWithValue("ACTION", 2);

                cmd.Parameters.AddWithValue("@ID", transferOut.ID);
                cmd.Parameters.AddWithValue("@COMPANY_ID", transferOut.COMPANY_ID);
                cmd.Parameters.AddWithValue("@STORE_ID", transferOut.STORE_ID);
                cmd.Parameters.AddWithValue("@TRANSFER_DATE", transferOut.TRANSFER_DATE);
                cmd.Parameters.AddWithValue("@DEST_STORE_ID", transferOut.DEST_STORE_ID);
                cmd.Parameters.AddWithValue("@NET_AMOUNT", transferOut.NET_AMOUNT);
                cmd.Parameters.AddWithValue("@NARRATION", transferOut.NARRATION);
                cmd.Parameters.AddWithValue("@USER_ID", transferOut.USER_ID);

                cmd.Parameters.AddWithValue("@UDT_TB_TRANSFER_OUT", tbl);

                cmd.ExecuteNonQuery();
                objtrans.Commit();

                return 0;
            }
            catch (Exception ex)
            {
                // Rollback the transaction if an error occurs
                objtrans.Rollback();
                throw;
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public Int32 Verify(TransferOut transferOut)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();

            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("COMPANY_ID", typeof(Int32));
                tbl.Columns.Add("STORE_ID", typeof(Int32));
                tbl.Columns.Add("ITEM_ID", typeof(Int32));
                tbl.Columns.Add("UOM", typeof(string));
                tbl.Columns.Add("QUANTITY", typeof(float));
                tbl.Columns.Add("COST", typeof(float));
                tbl.Columns.Add("AMOUNT", typeof(float));
                tbl.Columns.Add("BATCH_NO", typeof(string));
                tbl.Columns.Add("EXPIRY_DATE", typeof(DateTime));

                if (transferOut.TransferOutDetail != null && transferOut.TransferOutDetail.Any())
                {
                    foreach (TransferOutDetails ur in transferOut.TransferOutDetail)
                    {
                        DataRow dRow = tbl.NewRow();

                        dRow["COMPANY_ID"] = ur.COMPANY_ID;
                        dRow["STORE_ID"] = ur.STORE_ID;
                        dRow["ITEM_ID"] = ur.ITEM_ID;
                        dRow["UOM"] = ur.UOM;
                        dRow["QUANTITY"] = ur.QUANTITY;
                        dRow["COST"] = ur.COST;
                        dRow["AMOUNT"] = ur.AMOUNT;
                        dRow["BATCH_NO"] = string.IsNullOrEmpty(ur.BATCH_NO) ? string.Empty : ur.BATCH_NO; // Empty string if null
                        dRow["EXPIRY_DATE"] = ur.EXPIRY_DATE ?? new DateTime(1753, 1, 1);
                        tbl.Rows.Add(dRow);
                    }
                }
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_TRANSFER_OUT";

                cmd.Parameters.AddWithValue("ACTION", 5);

                cmd.Parameters.AddWithValue("@ID", transferOut.ID);
                cmd.Parameters.AddWithValue("@COMPANY_ID", transferOut.COMPANY_ID);
                cmd.Parameters.AddWithValue("@STORE_ID", transferOut.STORE_ID);
                cmd.Parameters.AddWithValue("@TRANSFER_DATE", transferOut.TRANSFER_DATE);
                cmd.Parameters.AddWithValue("@DEST_STORE_ID", transferOut.DEST_STORE_ID);
                cmd.Parameters.AddWithValue("@NET_AMOUNT", transferOut.NET_AMOUNT);
                cmd.Parameters.AddWithValue("@NARRATION", transferOut.NARRATION);
                cmd.Parameters.AddWithValue("@USER_ID", transferOut.USER_ID);

                cmd.Parameters.AddWithValue("@UDT_TB_TRANSFER_OUT", tbl);

                cmd.ExecuteNonQuery();
                objtrans.Commit();

                return 0;
            }
            catch (Exception ex)
            {
                // Rollback the transaction if an error occurs
                objtrans.Rollback();
                throw;
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public Int32 Approve(TransferOut transferOut)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();

            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("COMPANY_ID", typeof(Int32));
                tbl.Columns.Add("STORE_ID", typeof(Int32));
                tbl.Columns.Add("ITEM_ID", typeof(Int32));
                tbl.Columns.Add("UOM", typeof(string));
                tbl.Columns.Add("QUANTITY", typeof(float));
                tbl.Columns.Add("COST", typeof(float));
                tbl.Columns.Add("AMOUNT", typeof(float));
                tbl.Columns.Add("BATCH_NO", typeof(string));
                tbl.Columns.Add("EXPIRY_DATE", typeof(DateTime));

                if (transferOut.TransferOutDetail != null && transferOut.TransferOutDetail.Any())
                {
                    foreach (TransferOutDetails ur in transferOut.TransferOutDetail)
                    {
                        DataRow dRow = tbl.NewRow();

                        dRow["COMPANY_ID"] = ur.COMPANY_ID;
                        dRow["STORE_ID"] = ur.STORE_ID;
                        dRow["ITEM_ID"] = ur.ITEM_ID;
                        dRow["UOM"] = ur.UOM;
                        dRow["QUANTITY"] = ur.QUANTITY;
                        dRow["COST"] = ur.COST;
                        dRow["AMOUNT"] = ur.AMOUNT;
                        dRow["BATCH_NO"] = string.IsNullOrEmpty(ur.BATCH_NO) ? string.Empty : ur.BATCH_NO; // Empty string if null
                        dRow["EXPIRY_DATE"] = ur.EXPIRY_DATE ?? new DateTime(1753, 1, 1);
                        tbl.Rows.Add(dRow);
                    }
                }
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_TRANSFER_OUT";

                cmd.Parameters.AddWithValue("ACTION", 6);

                cmd.Parameters.AddWithValue("@ID", transferOut.ID);
                cmd.Parameters.AddWithValue("@COMPANY_ID", transferOut.COMPANY_ID);
                cmd.Parameters.AddWithValue("@STORE_ID", transferOut.STORE_ID);
                cmd.Parameters.AddWithValue("@TRANSFER_DATE", transferOut.TRANSFER_DATE);
                cmd.Parameters.AddWithValue("@DEST_STORE_ID", transferOut.DEST_STORE_ID);
                cmd.Parameters.AddWithValue("@NET_AMOUNT", transferOut.NET_AMOUNT);
                cmd.Parameters.AddWithValue("@NARRATION", transferOut.NARRATION);
                cmd.Parameters.AddWithValue("@USER_ID", transferOut.USER_ID);

                cmd.Parameters.AddWithValue("@UDT_TB_TRANSFER_OUT", tbl);

                cmd.ExecuteNonQuery();
                objtrans.Commit();

                return 0;
            }
            catch (Exception ex)
            {
                // Rollback the transaction if an error occurs
                objtrans.Rollback();
                throw;
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                SqlConnection connection = ADO.GetConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_TRANSFER_OUT";
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
        public List<TransferOut> List(Int32 intUserID)
        {
            List<TransferOut> worksheetList = new List<TransferOut>();
            SqlConnection connection = ADO.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TB_TRANSFER_OUT";
            cmd.Parameters.AddWithValue("@ACTION", 0);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            foreach (DataRow dr in tbl.Rows)
            {
                worksheetList.Add(new TransferOut
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    TRANSFER_NO = ADO.ToString(dr["TRANSFER_NO"]),
                    TRANSFER_DATE = Convert.ToDateTime(dr["TRANSFER_DATE"]),
                    DEST_STORE_ID = ADO.ToInt32(dr["DEST_STORE_ID"]),
                    NARRATION = ADO.ToString(dr["NARRATION"]),
                    STATUS = ADO.ToString(dr["STATUS"])
                });
            }
            connection.Close();

            return worksheetList;
        }
        public TransferOut GetTransferOut(int id)
        {
            TransferOut transferOut = new TransferOut();
            List<TransferOutDetails> transferOutDetails = new List<TransferOutDetails>();
            try
            {
                string strSQL = "SELECT TB_TROUT_HEADER.*, " +
                 "TB_STORES.STORE_NAME, " +
                 "TB_STATUS.STATUS_DESC AS STATUS, " +
                 "TB_AC_TRANS_HEADER.NARRATION AS NARRATION " +
                 "FROM TB_TROUT_HEADER " +
                 "LEFT JOIN TB_STORES ON TB_TROUT_HEADER.DEST_STORE_ID = TB_STORES.ID " +
                 "LEFT JOIN TB_AC_TRANS_HEADER ON TB_TROUT_HEADER.TRANS_ID = TB_AC_TRANS_HEADER.TRANS_ID " +
                 "LEFT JOIN TB_STATUS ON TB_AC_TRANS_HEADER.TRANS_STATUS = TB_STATUS.id " +
                 "WHERE TB_TROUT_HEADER.ID = " + id;


                DataTable tbl = ADO.GetDataTable(strSQL, "TransferOut");

                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    transferOut = new TransferOut
                    {
                        ID = ADO.ToInt32(dr["ID"]),
                        COMPANY_ID = ADO.ToInt32(dr["COMPANY_ID"]),
                        STORE_ID = ADO.ToInt32(dr["STORE_ID"]),
                        TRANSFER_NO = ADO.ToString(dr["TRANSFER_NO"]),
                        TRANSFER_DATE = Convert.ToDateTime(dr["TRANSFER_DATE"]),
                        DEST_STORE_ID = ADO.ToInt32(dr["DEST_STORE_ID"]),
                        STORE_NAME = ADO.ToString(dr["STORE_NAME"]),
                        NET_AMOUNT = ADO.ToFloat(dr["NET_AMOUNT"]),
                        NARRATION = ADO.ToString(dr["NARRATION"]),
                        STATUS = ADO.ToString(dr["STATUS"])
                    };
                }

                strSQL = " SELECT TB_TROUT_DETAIL.*, TB_STORES.STORE_NAME, TB_ITEMS.DESCRIPTION, TB_ITEMS.BARCODE," +
                    " TB_ITEM_STOCK.QTY_STOCK FROM TB_TROUT_DETAIL" +
                    " LEFT JOIN TB_STORES ON TB_TROUT_DETAIL.STORE_ID = TB_STORES.ID" +
                    " LEFT JOIN TB_ITEMS ON TB_TROUT_DETAIL.ITEM_ID = TB_ITEMS.ID" +
                    " LEFT JOIN TB_ITEM_STOCK ON TB_ITEM_STOCK.ITEM_ID = TB_ITEMS.ID and " +
                     "TB_ITEM_STOCK.STORE_ID = TB_TROUT_DETAIL.STORE_ID" +
                    " WHERE TB_TROUT_DETAIL.TRANSFER_ID = " + id;

                DataTable tblTransferOutdetail = ADO.GetDataTable(strSQL, "TransferOutDetails");

                foreach (DataRow dr3 in tblTransferOutdetail.Rows)
                {
                    transferOutDetails.Add(new TransferOutDetails
                    {
                        ID = ADO.ToInt32(dr3["ID"]),
                        COMPANY_ID = ADO.ToInt32(dr3["COMPANY_ID"]),
                        STORE_ID = ADO.ToInt32(dr3["STORE_ID"]),
                        STORE_NAME = ADO.ToString(dr3["STORE_NAME"]),
                        ITEM_ID = ADO.ToInt32(dr3["ITEM_ID"]),
                        ITEM_NAME = ADO.ToString(dr3["DESCRIPTION"]),
                        BAR_CODE = ADO.ToString(dr3["BARCODE"]),
                        QTY_STOCK = ADO.ToFloat(dr3["QTY_STOCK"]),
                        UOM = ADO.ToString(dr3["UOM"]),
                        QUANTITY = ADO.ToFloat(dr3["QUANTITY"]),
                        COST = ADO.ToFloat(dr3["COST"]),
                        AMOUNT = ADO.ToFloat(dr3["AMOUNT"]),
                        BATCH_NO = ADO.ToString(dr3["BATCH_NO"]),
                        EXPIRY_DATE = Convert.ToDateTime(dr3["EXPIRY_DATE"])

                    });
                }


                transferOut.TransferOutDetail = transferOutDetails;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return transferOut;
        }
    }
}
