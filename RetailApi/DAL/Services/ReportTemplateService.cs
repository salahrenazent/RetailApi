using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class ReportTemplateService:IReportTemplateService
    {
        public List<ReportTemplate> GetReportTemplates()
        {
            List<ReportTemplate> reportList = new List<ReportTemplate>();
            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_DOCUMENT_TEMPLATE_DATA_SOURCE";
            cmd.Parameters.AddWithValue("ACTION", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                reportList.Add(new ReportTemplate
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    // COMPANY_ID = ADO.ToInt32(dr["COMPANY_ID"]),
                    DOC_TYPE_ID = ADO.ToInt32(dr["DOC_TYPE_ID"]),
                    DOC_TYPE = ADO.ToString(dr["TRANS_TYPE"]),
                    TEMPLATE_NAME = ADO.ToString(dr["TEMPLATE_NAME"]),
                    USER_ID = ADO.ToInt32(dr["USER_ID"]),
                    USER_NAME = ADO.ToString(dr["USER_NAME"]),
                    LOG_TIME = Convert.ToDateTime(dr["LOG_TIME"]),
                    IS_DEFAULT = ADO.Toboolean(dr["IS_DEFAULT"])
                    // FILE_DATA = ADO.ToString(dr["FILE_DATA"]),

                });
            }
            connection.Close();

            return reportList;
        }

        public Int32 CheckDefault(ReportInput input)
        {
            try
            {
                SqlConnection connection = ADO.GetConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MAKE_DEFAULT";


                cmd.Parameters.AddWithValue("@ID", input.ID);
                cmd.Parameters.AddWithValue("@DOC_TYPE_ID", input.DOC_TYPE_ID);

                cmd.ExecuteNonQuery();

                return 0;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReportOutput> GetReportOutput(ReportInput input)
        {
            List<ReportOutput> reportList = new List<ReportOutput>();
            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DOCUMENT_DATASOURCE";
            cmd.Parameters.AddWithValue("@ACTION", 1);
            cmd.Parameters.AddWithValue("@ID", input.ID);
            cmd.Parameters.AddWithValue("@DOC_TYPE_ID", input.DOC_TYPE_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                reportList.Add(new ReportOutput
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    PO_NO = ADO.ToString(dr["PO_NO"]),
                    PO_DATE = Convert.ToDateTime(dr["PO_DATE"]),
                    SUPP_ID = ADO.ToInt32(dr["SUPP_ID"]),
                    SUPP_NAME = ADO.ToString(dr["SUPP_NAME"]),
                    SUPP_CONTACT = ADO.ToString(dr["SUPP_CONTACT"]),
                    SUPP_ADDRESS = ADO.ToString(dr["SUPP_ADDRESS"]),
                    SUPP_MOBILE = ADO.ToString(dr["SUPP_MOBILE"]),
                    REF_NO = ADO.ToString(dr["REF_NO"]),
                    PAYMENT_TERM = ADO.ToString(dr["PAYMENT_TERM"]),
                    DELIVERY_TERM = ADO.ToString(dr["DELIVERY_TERM"]),
                    STORE_NAME = ADO.ToString(dr["STORE_NAME"]),
                    ADDRESS1 = ADO.ToString(dr["ADDRESS1"]),
                    LOCATION = ADO.ToString(dr["LOCATION"]),
                    CONTACT_NAME = ADO.ToString(dr["CONTACT_NAME"]),
                    CONTACT_MOBILE = ADO.ToString(dr["CONTACT_MOBILE"]),
                    DELIVERY_DESC = ADO.ToString(dr["DELIVERY_DESC"]),
                    CURRENCY = ADO.ToString(dr["CURRENCY"]),
                    REMARKS = ADO.ToString(dr["REMARKS"]),
                    TOTAL_GROSS = ADO.ToFloat(dr["TOTAL_GROSS"]),
                    TOTAL_TAX = ADO.ToFloat(dr["TOTAL_TAX"]),
                    TOTAL_NET = ADO.ToFloat(dr["TOTAL_NET"]),
                    DETAIL_ID = ADO.ToInt32(dr["DETAIL_ID"]),
                    ITEM_ID = ADO.ToInt32(dr["ITEM_ID"]),
                    BARCODE = ADO.ToString(dr["BARCODE"]),
                    ITEM_DESCRIPTION = ADO.ToString(dr["ITEM_DESCRIPTION"]),
                    QUANTITY = ADO.ToFloat(dr["QUANTITY"]),
                    UOM = ADO.ToString(dr["UOM"]),
                    PRICE = ADO.ToDecimal(dr["PRICE"]),
                    DISC_PERCENT = ADO.ToFloat(dr["DISC_PERCENT"]),
                    AMOUNT = ADO.ToInt32(dr["AMOUNT"]),
                    TAX_PERCENT = ADO.ToDecimal(dr["TAX_PERCENT"]),
                    TAX_AMOUNT = ADO.ToDecimal(dr["TAX_AMOUNT"]),
                    TOTAL_TAX_DETAIL = ADO.ToDecimal(dr["TOTAL_TAX_DETAIL"])
                });
            }
            connection.Close();

            return reportList;
        }

        public List<ReportTemplate> GetTemplateList(ReportInput input)
        {
            List<ReportTemplate> templateList = new List<ReportTemplate>();
            SqlConnection connection = ADO.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DOCUMENT_DATASOURCE";

            cmd.Parameters.AddWithValue("@ACTION", 0);
            cmd.Parameters.AddWithValue("@DOC_TYPE_ID", input.DOC_TYPE_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            foreach (DataRow dr in tbl.Rows)
            {
                templateList.Add(new ReportTemplate
                {
                    ID = ADO.ToInt32(dr["ID"]),
                    DOC_TYPE_ID = ADO.ToInt32(dr["DOC_TYPE_ID"]),
                    TEMPLATE_NAME = ADO.ToString(dr["TEMPLATE_NAME"]),
                    IS_DEFAULT = ADO.Toboolean(dr["IS_DEFAULT"])
                });
            }
            connection.Close();

            return templateList;
        }
    }
}
