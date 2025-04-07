using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class PurchaseInvoiceService:IPurchaseInvoiceService
    {
        public List<PIDropdownData> GetPendingPoList(PIDropdownInput input)
        {
            List<PIDropdownData> POlist = new List<PIDropdownData>();
            SqlConnection connection = ADO.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_PENDING_PO_LIST";
            cmd.Parameters.AddWithValue("@SUPP_ID", input.SUPP_ID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                POlist.Add(new PIDropdownData
                {
                    PO_ID = ADO.ToInt32(dr["ID"]),
                    PO_NO = ADO.ToString(dr["PO_NO"]),
                    PO_DATE = Convert.ToDateTime(dr["PO_DATE"]),
                    SUPP_NAME = ADO.ToString(dr["SUPP_NAME"]),
                });
            }
            connection.Close();

            return POlist;
        }
        public GRNDetailResponce GetSelectedPoDetailS(GRNDetailInput input)
        {
            GRNDetailResponce response = new GRNDetailResponce();
            List<GRNDetails> poDetailsList = new List<GRNDetails>();

            SqlConnection connection = ADO.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_PO_DETAILS";
            cmd.Parameters.AddWithValue("@PO_ID", input.PO_ID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            // Populate PODetails
            foreach (DataRow dr in tbl.Rows)
            {
                GRNDetails poDetail = new GRNDetails
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    GRN_NO = ADO.ToInt32(dr["GRN_NO"]),
                    ITEM_ID = ADO.ToInt32(dr["ITEM_ID"]),
                    BARCODE = ADO.ToString(dr["BARCODE"]),
                    DESCRIPTION = ADO.ToString(dr["DESCRIPTION"]),
                    UOM = ADO.ToString(dr["UOM"]),
                    PRICE = ADO.ToFloat(dr["PRICE"]),
                    PENDING_QTY = ADO.ToFloat(dr["PENDING_QTY"]),
                    DISC_PERCENT = ADO.ToFloat(dr["DISC_PERCENT"]),
                    TAX_PERCENT = ADO.ToDecimal(dr["TAX_PERCENT"]),

                    COMPANY_ID = ADO.ToInt32(dr["COMPANY_ID"]),
                    PACKING = ADO.ToString(dr["PACKING"]),//MANAGE NULL
                    QUANTITY = ADO.ToFloat(dr["QUANTITY"]),
                    RATE = ADO.ToFloat(dr["RATE"]),
                    RETURN_QTY = ADO.ToFloat(dr["RETURN_QTY"]),
                    ITEM_DESC = ADO.ToString(dr["ITEM_DESC"]),
                    PO_DET_ID = ADO.ToInt32(dr["PO_DET_ID"]),
                    COST = ADO.ToFloat(dr["COST"]),
                    SUPP_PRICE = ADO.ToFloat(dr["SUPP_PRICE"]),
                    SUPP_AMOUNT = ADO.ToFloat(dr["SUPP_AMOUNT"]),
                    GRN_STORE_ID = ADO.ToInt32(dr["GRN_STORE_ID"]),
                    SUPP_ID = ADO.ToInt32(dr["SUPP_ID"]),
                };
                poDetailsList.Add(poDetail);
            }

            // Assign the populated data to the response object
            response.Flag = 1; // Or any flag you want to return
            response.Message = "Success"; // Any message you want to include
            response.GRNDetails = poDetailsList; // List of PODetails

            connection.Close();
            return response;
        }
        public Int32 Insert(PurchHeader purchHeader)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();

            try
            {
                DataTable tbl = new DataTable();

                tbl.Columns.Add("ID", typeof(long));
                tbl.Columns.Add("COMPANY_ID", typeof(int));
                tbl.Columns.Add("STORE_ID", typeof(int));
                tbl.Columns.Add("PURCH_ID", typeof(int));
                tbl.Columns.Add("GRN_DET_ID", typeof(int));
                tbl.Columns.Add("ITEM_ID", typeof(int));
                tbl.Columns.Add("PACKING", typeof(string));
                tbl.Columns.Add("QUANTITY", typeof(float));
                tbl.Columns.Add("RATE", typeof(float));
                tbl.Columns.Add("AMOUNT", typeof(float));
                tbl.Columns.Add("RETURN_QTY", typeof(float));
                tbl.Columns.Add("ITEM_DESC", typeof(string));
                tbl.Columns.Add("PO_DET_ID", typeof(long));
                tbl.Columns.Add("UOM", typeof(string));
                tbl.Columns.Add("DISC_PERCENT", typeof(float));
                tbl.Columns.Add("COST", typeof(float));
                tbl.Columns.Add("SUPP_PRICE", typeof(float));
                tbl.Columns.Add("SUPP_AMOUNT", typeof(float));
                tbl.Columns.Add("VAT_PERC", typeof(decimal));
                tbl.Columns.Add("VAT_AMOUNT", typeof(decimal));
                tbl.Columns.Add("GRN_STORE_ID", typeof(int));
                tbl.Columns.Add("RETURN_AMOUNT", typeof(float));

                if (purchHeader.PurchDetails != null && purchHeader.PurchDetails.Any())
                {
                    foreach (var ur in purchHeader.PurchDetails)
                    {
                        DataRow dRow = tbl.NewRow();

                        dRow["COMPANY_ID"] = ur.COMPANY_ID;
                        dRow["STORE_ID"] = ur.STORE_ID;
                        dRow["PURCH_ID"] = ur.PURCH_ID;
                        dRow["GRN_DET_ID"] = (object?)ur.GRN_DET_ID ?? DBNull.Value;
                        dRow["ITEM_ID"] = (object?)ur.ITEM_ID ?? DBNull.Value;
                        dRow["PACKING"] = ur.PACKING ?? string.Empty;
                        dRow["QUANTITY"] = (object?)ur.QUANTITY ?? DBNull.Value;
                        dRow["RATE"] = (object?)ur.RATE ?? DBNull.Value;
                        dRow["AMOUNT"] = (object?)ur.AMOUNT ?? DBNull.Value;
                        dRow["RETURN_QTY"] = (object?)ur.RETURN_QTY ?? DBNull.Value;
                        dRow["ITEM_DESC"] = ur.ITEM_DESC ?? string.Empty;
                        dRow["PO_DET_ID"] = (object?)ur.PO_DET_ID ?? DBNull.Value;
                        dRow["UOM"] = ur.UOM ?? string.Empty;
                        dRow["DISC_PERCENT"] = (object?)ur.DISC_PERCENT ?? DBNull.Value;
                        dRow["COST"] = (object?)ur.COST ?? DBNull.Value;
                        dRow["SUPP_PRICE"] = (object?)ur.SUPP_PRICE ?? DBNull.Value;
                        dRow["SUPP_AMOUNT"] = (object?)ur.SUPP_AMOUNT ?? DBNull.Value;
                        dRow["VAT_PERC"] = (object?)ur.VAT_PERC ?? DBNull.Value;
                        dRow["VAT_AMOUNT"] = (object?)ur.VAT_AMOUNT ?? DBNull.Value;
                        dRow["GRN_STORE_ID"] = (object?)ur.GRN_STORE_ID ?? DBNull.Value;
                        dRow["RETURN_AMOUNT"] = ur.RETURN_AMOUNT;

                        tbl.Rows.Add(dRow);
                    }
                }


                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_PURCH";

                cmd.Parameters.AddWithValue("ACTION", 1);
                cmd.Parameters.AddWithValue("@COMPANY_ID", purchHeader.COMPANY_ID);
                cmd.Parameters.AddWithValue("@STORE_ID", purchHeader.STORE_ID);
                cmd.Parameters.AddWithValue("@PURCH_DATE", purchHeader.PURCH_DATE ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IS_CREDIT", purchHeader.IS_CREDIT);
                cmd.Parameters.AddWithValue("@SUPP_ID", purchHeader.SUPP_ID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SUPP_INV_NO", purchHeader.SUPP_INV_NO ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SUPP_INV_DATE", purchHeader.SUPP_INV_DATE ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PO_ID", purchHeader.PO_ID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PO_NO", purchHeader.PO_NO ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FIN_ID", purchHeader.FIN_ID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PURCH_TYPE", purchHeader.PURCH_TYPE ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DISCOUNT_AMOUNT", purchHeader.DISCOUNT_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SUPP_GROSS_AMOUNT", purchHeader.SUPP_GROSS_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SUPP_NET_AMOUNT", purchHeader.SUPP_NET_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EXCHANGE_RATE", purchHeader.EXCHANGE_RATE ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GROSS_AMOUNT", purchHeader.GROSS_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CHARGE_DESCRIPTION", purchHeader.CHARGE_DESCRIPTION ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CHARGE_AMOUNT", purchHeader.CHARGE_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@VAT_AMOUNT", purchHeader.VAT_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NET_AMOUNT", purchHeader.NET_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@RETURN_AMOUNT", purchHeader.RETURN_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ADJ_AMOUNT", purchHeader.ADJ_AMOUNT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PAID_AMOUNT", purchHeader.PAID_AMOUNT);

                cmd.Parameters.AddWithValue("@UDT_TB_PURCH_DETAIL", tbl);


                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand();

                cmd1.Connection = connection;
                cmd1.Transaction = objtrans;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT MAX(ID) FROM TB_WORKSHEET";


                Int32 UserID = ADO.ToInt32(cmd1.ExecuteScalar());

                // Commit the transaction if everything is successful
                objtrans.Commit();

                return UserID;
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
    }
}
