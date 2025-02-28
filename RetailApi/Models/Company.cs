namespace RetailApi.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string WEBSITE { get; set; }
        public string COUNTRY_ID { get; set; }
        public String COUNTRY_NAME { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string VAT_REGN_NO { get; set; }
    }
    public class CompanyResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public Company data { get; set; }
    }

    public class DocSettings
    {
        public int TRANS_TYPE { get; set; }
        public string GROUP_CODE { get; set; }
        public int FIN_ID { get; set; }
        public int PREFIX { get; set; }
        public int START { get; set; }
        public int WIDTH { get; set; }
        public bool VERIFY_REQUIRED { get; set; }
    }
}
