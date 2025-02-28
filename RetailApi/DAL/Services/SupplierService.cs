﻿using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RetailApi.DAL.Services
{
    public class SupplierService:ISupplierService
    {
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> supplierList = new List<Supplier>();
            using (SqlConnection connection = ADO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_SUPPLIER";
                cmd.Parameters.AddWithValue("ACTION", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);

                foreach (DataRow dr in tbl.Rows)
                {
                    supplierList.Add(new Supplier
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        HQID = Convert.ToInt32(dr["HQID"]),
                        AC_HEAD_ID = Convert.ToInt32(dr["AC_HEAD_ID"]),
                        SUPP_CODE = Convert.ToString(dr["SUPP_CODE"]),
                        SUPP_NAME = Convert.ToString(dr["SUPP_NAME"]),
                        CONTACT_NAME = Convert.ToString(dr["CONTACT_NAME"]),
                        ADDRESS1 = Convert.ToString(dr["ADDRESS1"]),
                        ADDRESS2 = Convert.ToString(dr["ADDRESS2"]),
                        ADDRESS3 = Convert.ToString(dr["ADDRESS3"]),
                        ZIP = Convert.ToString(dr["ZIP"]),
                        STATE_ID = Convert.ToInt32(dr["STATE_ID"]),
                        CITY = Convert.ToString(dr["CITY"]),
                        COUNTRY_ID = Convert.ToInt32(dr["COUNTRY_ID"]),
                        PHONE = Convert.ToString(dr["PHONE"]),
                        EMAIL = Convert.ToString(dr["EMAIL"]),
                        IS_INACTIVE = Convert.ToBoolean(dr["IS_INACTIVE"]),
                        MOBILE_NO = Convert.ToString(dr["MOBILE_NO"]),
                        NOTES = Convert.ToString(dr["NOTES"]),
                        FAX_NO = Convert.ToString(dr["FAX_NO"]),
                        VAT_REGNO = Convert.ToString(dr["VAT_REGNO"]),
                        CURRENCY_ID = Convert.ToInt32(dr["CURRENCY_ID"]),
                        PAY_TERM_ID = Convert.ToInt32(dr["PAY_TERM_ID"]),
                        VAT_RULE_ID = Convert.ToInt32(dr["VAT_RULE_ID"]),

                        COUNTRY_NAME = Convert.ToString(dr["COUNTRY_NAME"]),
                        CURRENCY_CODE = Convert.ToString(dr["CURRENCY_CODE"]),
                        PAYMENT_CODE = Convert.ToString(dr["PAYMENT_CODE"]),
                        DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]),
                        STATE_NAME = Convert.ToString(dr["STATE_NAME"]),
                    });
                }
                connection.Close();
            }
            return supplierList;
        }

        public bool SaveData(Supplier supplier)
        {
            SqlConnection connection = ADO.GetConnection();
            SqlTransaction objtrans = connection.BeginTransaction();

            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("SUPP_ID", typeof(Int32));
                tbl.Columns.Add("COST_ID", typeof(Int32));

                foreach (SupplierCost ur in supplier.Supplier_cost)
                {
                    DataRow dRow = tbl.NewRow();


                    dRow["SUPP_ID"] = ur.SUPP_ID;
                    dRow["COST_ID"] = ur.COST_ID;

                    tbl.Rows.Add(dRow);
                    tbl.AcceptChanges();
                }


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = objtrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TB_SUPPLIER";

                cmd.Parameters.AddWithValue("ACTION", 1);
                cmd.Parameters.AddWithValue("ID", supplier.ID);
                cmd.Parameters.AddWithValue("HQID", supplier.HQID);

                //cmd.Parameters.AddWithValue("ID", (object)suppliers.ID ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("HQID", (object)suppliers.HQID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("SUPP_CODE", (object)supplier.SUPP_CODE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("SUPP_NAME", (object)supplier.SUPP_NAME ?? DBNull.Value);
                cmd.Parameters.AddWithValue("CONTACT_NAME", (object)supplier.CONTACT_NAME ?? DBNull.Value);
                cmd.Parameters.AddWithValue("ADDRESS1", (object)supplier.ADDRESS1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("ADDRESS2", (object)supplier.ADDRESS2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("ADDRESS3", (object)supplier.ADDRESS3 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("ZIP", (object)supplier.ZIP ?? DBNull.Value);
                cmd.Parameters.AddWithValue("CITY", (object)supplier.CITY ?? DBNull.Value);
                cmd.Parameters.AddWithValue("STATE_ID", (object)supplier.STATE_ID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("COUNTRY_ID", (object)supplier.COUNTRY_ID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("PHONE", (object)supplier.PHONE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("EMAIL", (object)supplier.EMAIL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("IS_INACTIVE", (object)supplier.IS_INACTIVE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("MOBILE_NO", (object)supplier.MOBILE_NO ?? DBNull.Value);
                cmd.Parameters.AddWithValue("FAX_NO", (object)supplier.FAX_NO ?? DBNull.Value);
                cmd.Parameters.AddWithValue("NOTES", (object)supplier.NOTES ?? DBNull.Value);
                cmd.Parameters.AddWithValue("CURRENCY_ID", (object)supplier.CURRENCY_ID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("PAY_TERM_ID", (object)supplier.PAY_TERM_ID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("VAT_RULE_ID", (object)supplier.VAT_RULE_ID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("VAT_REGNO", (object)supplier.VAT_REGNO ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@UDT_TB_SUPPLIER_COST", tbl);

                cmd.ExecuteNonQuery();

                objtrans.Commit();

                connection.Close();
                return true;

                //Int32 CountryID = Convert.ToInt32(cmd.ExecuteScalar());



                //return CountryID;
            }
            catch (Exception ex)
            {
                objtrans.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public Supplier GetItems(int id)
        {
            Supplier suppliers = new Supplier();
            List<SupplierCost> supplierCosts = new List<SupplierCost>();

            try
            {
                string strSQL = "SELECT TB_SUPPLIER.ID, TB_SUPPLIER.HQID, TB_SUPPLIER.AC_HEAD_ID, TB_SUPPLIER.SUPP_CODE, TB_SUPPLIER.SUPP_NAME, " +
                   "TB_SUPPLIER.CONTACT_NAME, TB_SUPPLIER.ADDRESS1, TB_SUPPLIER.ADDRESS2, TB_SUPPLIER.ADDRESS3, TB_SUPPLIER.ZIP, " +
                   "TB_SUPPLIER.CITY, TB_SUPPLIER.PHONE, TB_SUPPLIER.EMAIL, TB_SUPPLIER.IS_INACTIVE, TB_SUPPLIER.MOBILE_NO, " +
                   "TB_SUPPLIER.NOTES, TB_SUPPLIER.FAX_NO, TB_SUPPLIER.VAT_REGNO,TB_SUPPLIER.IS_DELETED," +
                   "TB_SUPPLIER.COUNTRY_ID,TB_SUPPLIER.CURRENCY_ID,TB_SUPPLIER.PAY_TERM_ID,TB_SUPPLIER.VAT_RULE_ID," +
                   "TB_SUPPLIER.STATE_ID," +

                   "TB_COUNTRY.COUNTRY_NAME,TB_CURRENCY.CODE,TB_PAYMENT_TERMS.CODE," +
                   " TB_VAT_RULE_SUPPLIER.DESCRIPTION ,TB_STATE.STATE_NAME " +
                   "FROM TB_SUPPLIER " +

                   "LEFT JOIN TB_COUNTRY ON TB_SUPPLIER.COUNTRY_ID = TB_COUNTRY.ID " +
                   "LEFT JOIN TB_CURRENCY ON TB_SUPPLIER.CURRENCY_ID = TB_CURRENCY.ID " +
                   "LEFT JOIN TB_PAYMENT_TERMS ON TB_SUPPLIER.PAY_TERM_ID = TB_PAYMENT_TERMS.ID " +
                   "LEFT JOIN TB_VAT_RULE_SUPPLIER ON TB_SUPPLIER.VAT_RULE_ID = TB_VAT_RULE_SUPPLIER.ID " +
                   "LEFT JOIN TB_STATE ON TB_SUPPLIER.STATE_ID = TB_STATE.ID " +

                   "WHERE TB_SUPPLIER.ID =" + id;


                DataTable tbl = ADO.GetDataTable(strSQL, "Suppliers");
                if (tbl.Rows.Count > 0)
                {
                    DataRow dr = tbl.Rows[0];

                    suppliers.ID = Convert.ToInt32(dr["ID"]);
                    suppliers.HQID = Convert.ToInt32(dr["HQID"]);
                    suppliers.AC_HEAD_ID = Convert.ToInt32(dr["AC_HEAD_ID"]);
                    suppliers.SUPP_CODE = Convert.ToString(dr["SUPP_CODE"]);
                    suppliers.SUPP_NAME = Convert.ToString(dr["SUPP_NAME"]);
                    suppliers.CONTACT_NAME = Convert.ToString(dr["CONTACT_NAME"]);
                    suppliers.ADDRESS1 = Convert.ToString(dr["ADDRESS1"]);
                    suppliers.ADDRESS2 = Convert.ToString(dr["ADDRESS2"]);
                    suppliers.ADDRESS3 = Convert.ToString(dr["ADDRESS3"]);
                    suppliers.ZIP = Convert.ToString(dr["ZIP"]);
                    suppliers.STATE_ID = Convert.ToInt32(dr["STATE_ID"]);
                    suppliers.CITY = Convert.ToString(dr["CITY"]);
                    suppliers.PHONE = Convert.ToString(dr["PHONE"]);
                    suppliers.EMAIL = Convert.ToString(dr["EMAIL"]);
                    suppliers.IS_INACTIVE = Convert.ToBoolean(dr["IS_INACTIVE"]);
                    suppliers.MOBILE_NO = Convert.ToString(dr["MOBILE_NO"]);
                    suppliers.NOTES = Convert.ToString(dr["NOTES"]);
                    suppliers.FAX_NO = Convert.ToString(dr["FAX_NO"]);
                    suppliers.VAT_REGNO = Convert.ToString(dr["VAT_REGNO"]);
                    suppliers.IS_DELETED = Convert.ToString(dr["IS_DELETED"]);
                    suppliers.COUNTRY_ID = Convert.ToInt32(dr["COUNTRY_ID"]);
                    suppliers.COUNTRY_NAME = Convert.ToString(dr["COUNTRY_NAME"]);
                    suppliers.CURRENCY_ID = Convert.ToInt32(dr["CURRENCY_ID"]);
                    suppliers.CURRENCY_CODE = Convert.ToString(dr["CODE"]);
                    suppliers.PAY_TERM_ID = Convert.ToInt32(dr["PAY_TERM_ID"]);
                    suppliers.PAYMENT_CODE = Convert.ToString(dr["CODE"]);
                    suppliers.VAT_RULE_ID = Convert.ToInt32(dr["VAT_RULE_ID"]);
                    suppliers.DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]);
                    suppliers.STATE_ID = Convert.ToInt32(dr["STATE_ID"]);
                    suppliers.STATE_NAME = Convert.ToString(dr["STATE_NAME"]);
                }

                strSQL = "SELECT * FROM TB_SUPPLIER_COSTS " +
                  " WHERE TB_SUPPLIER_COSTS.SUPP_ID =" + id;

                DataTable tblItemComponent = ADO.GetDataTable(strSQL, "Supplier Cost");

                foreach (DataRow dr3 in tblItemComponent.Rows)
                {
                    supplierCosts.Add(new SupplierCost
                    {
                        SUPP_ID = ADO.ToInt32(dr3["SUPP_ID"]),
                        COST_ID = ADO.ToInt32(dr3["COST_ID"])

                    });
                }
                suppliers.Supplier_cost = supplierCosts;


            }
            catch (Exception ex)
            {

            }
            return suppliers;
        }


        public bool DeleteSupplier(int id)
        {
            try
            {
                SqlConnection connection = ADO.GetConnection();

                SqlCommand cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_TB_SUPPLIER"
                };
                cmd.Parameters.AddWithValue("ACTION", 4);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
                return true; // Deletion succeeded

            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This supplier is used in a purchase order"))
                {
                    // Handle the specific error message
                    Console.WriteLine("This supplier is used in a purchase order and cannot be deleted.");
                    return false;
                }
                else
                {
                    // Rethrow any other SQL exceptions
                    throw;
                }
            }
        }


        //public bool DeleteSupplier(int id)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = ADO.GetConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = connection;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "SP_TB_SUPPLIER";
        //            cmd.Parameters.AddWithValue("ACTION", 4);
        //            cmd.Parameters.AddWithValue("@ID", id);
        //            cmd.ExecuteNonQuery();

        //            connection.Close();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
