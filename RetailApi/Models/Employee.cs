namespace RetailApi.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EMP_CODE { get; set; }
        public string EMP_NAME { get; set; }
        public DateTime? DOB { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public int STATE_ID { get; set; }
        public int COUNTRY_ID { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public bool? IS_MALE { get; set; }
        public int DEPT_ID { get; set; }
        public int DESG_ID { get; set; }
        public DateTime? DOJ { get; set; }
        public string BANK_CODE { get; set; }
        public string BANK_AC_NO { get; set; }
        public string PP_NO { get; set; }
        public DateTime? PP_EXPIRY { get; set; }
        public string IQAMA_NO { get; set; }
        public DateTime? IQAMA_EXPIRY { get; set; }
        public string VISA_NO { get; set; }
        public DateTime? VISA_EXPIRY { get; set; }
        public string LICENSE_NO { get; set; }
        public DateTime? LICENSE_EXPIRY { get; set; }
        public int EMP_STATUS { get; set; }
        public bool? IS_SALESMAN { get; set; }
        public string IMAGE_NAME { get; set; }
        public string WORK_PERMIT_NO { get; set; }
        public DateTime? WORK_PERMIT_EXPIRY { get; set; }
        public string IBAN_NO { get; set; }
        public string DAMAN_NO { get; set; }
        public string DAMAN_CATEGORY { get; set; }
        public float? LEAVE_CREDIT { get; set; }
        public float? LESS_SERVICE_DAYS { get; set; }
        public bool? HOLD_SALARY { get; set; }
        public string MOL_NUMBER { get; set; }
        public DateTime? LAST_REJOIN_DATE { get; set; }
        public float? INCENTIVE_PERCENT { get; set; }
        public int STORE_ID { get; set; }
        public string IS_DELETED { get; set; }

        public string STATE_NAME { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string DEPT_NAME { get; set; }
        public string DESG_NAME { get; set; }
        public string STORE_NAME { get; set; }
    }
    public class EmployeeResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public Employee data { get; set; }
    }
}
