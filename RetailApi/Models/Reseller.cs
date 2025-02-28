namespace RetailApi.Models
{
    public class Reseller
    {
        public int ID { get; set; }

        public string RESELLER_CODE { get; set; }

        public string RESELLER_NAME { get; set; }

        public string RESELLER_PHONE { get; set; }

        public string RESELLER_EMAIL { get; set; }

        public string COUNTRY_ID { get; set; }

        public String COUNTRY_NAME { get; set; }

    }
    public class ResellerResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public Reseller data { get; set; }
    }
}
