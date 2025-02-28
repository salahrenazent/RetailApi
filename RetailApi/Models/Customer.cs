﻿namespace RetailApi.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public int HQID { get; set; }
        public int AC_HEAD_ID { get; set; }
        public string CUST_CODE { get; set; }
        public string FIRST_NAME { get; set; }
        public string CONTACT_NAME { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string ZIP { get; set; }
        public string CITY { get; set; }
        public int STATE_ID { get; set; }
        public int COUNTRY_ID { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public int SALESMAN_ID { get; set; }
        public float? CREDIT_LIMIT { get; set; }
        public float? CURRENT_CREDIT { get; set; }
        public bool? IS_BLOCKED { get; set; }
        public string MOBILE_NO { get; set; }
        public string FAX_NO { get; set; }
        public string LAST_NAME { get; set; }
        public DateTime? DOB { get; set; }
        public int NATIONALITY { get; set; }
        public string NOTES { get; set; }
        public string CUST_NAME { get; set; }
        public int CREDIT_DAYS { get; set; }
        public int PAY_TERM_ID { get; set; }
        public int PRICE_CLASS_ID { get; set; }
        public float? DISCOUNT_PERCENT { get; set; }
        public DateTime? DOJ { get; set; }
        public int COMPANY_ID { get; set; }
        public int STORE_ID { get; set; }
        public int CUST_VAT_RULE_ID { get; set; }
        public string VAT_REGNO { get; set; }
        public bool? IS_DELETED { get; set; }
        public decimal? LOYALTY_POINT { get; set; }

        public string STATE_NAME { get; set; }
        public string COUNTRY_NAME { get; set; }

        public string EMP_NAME { get; set; }
        public string CODE { get; set; }
        public string CLASS_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string STORE_NAME { get; set; }
        public string VAT_RULE_DESCRIPTION { get; set; }
    }
    public class CustomerResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public Customer data { get; set; }
    }
}
