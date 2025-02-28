using Newtonsoft.Json;

namespace RetailApi.Models
{
    public class ReportTemplate
    {
        public int ID { get; set; }
        public int DOC_TYPE_ID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DOC_TYPE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LOG_TIME { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TEMPLATE_NAME { get; set; }
        public int USER_ID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string USER_NAME { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IS_DEFAULT { get; set; }
    }
    public class ReportTemplateResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public List<ReportTemplate> data { get; set; }
        public List<ReportOutput> datalist { get; set; }
    }
    public class ReportInput
    {
        public int DOC_TYPE_ID { get; set; }
        public int ID { get; set; }
    }
    public class ReportOutput
    {
        public int ID { get; set; }
        public string PO_NO { get; set; }
        public DateTime PO_DATE { get; set; }
        public int SUPP_ID { get; set; }
        public string SUPP_NAME { get; set; }
        public string SUPP_CONTACT { get; set; }
        public string SUPP_ADDRESS { get; set; }
        public string SUPP_MOBILE { get; set; }
        public string REF_NO { get; set; }
        public string PAYMENT_TERM { get; set; }
        public string DELIVERY_TERM { get; set; }
        public string STORE_NAME { get; set; }
        public string ADDRESS1 { get; set; }
        public string LOCATION { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_MOBILE { get; set; }
        public string DELIVERY_DESC { get; set; }
        public string CURRENCY { get; set; }
        public string REMARKS { get; set; }
        public float TOTAL_GROSS { get; set; }
        public float TOTAL_TAX { get; set; }
        public float TOTAL_NET { get; set; }
        public int DETAIL_ID { get; set; }
        public int ITEM_ID { get; set; }
        public string BARCODE { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public float QUANTITY { get; set; }
        public string UOM { get; set; }
        public decimal PRICE { get; set; }
        public float DISC_PERCENT { get; set; }
        public float AMOUNT { get; set; }
        public decimal TAX_PERCENT { get; set; }
        public decimal TAX_AMOUNT { get; set; }
        public decimal TOTAL_TAX_DETAIL { get; set; }

    }
}
