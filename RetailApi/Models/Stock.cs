namespace RetailApi.Models
{
    public class Stock
    {
        public int ITEM_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string DEPT_NAME { get; set; }
        public string CAT_NAME { get; set; }
        public string BRAND_NAME { get; set; }
        public string BARCODE { get; set; }
        public string DUBAI { get; set; }
        public string SHARJAH { get; set; }
        public string AJMAN { get; set; }
        public decimal TOTAL { get; set; }
    }
    public class StockInput
    {
        public int USER_ID { get; set; }
        public int COMPANY_ID { get; set; }
    }
    public class ReportColumns
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Visibility { get; set; }
        public bool Group { get; set; }
        public bool Summary { get; set; }
    }
    public class StockResponse
    {
        public int Flag { get; set; }
        public string Message { get; set; }
        public List<ReportColumns> Columns { get; set; }
        public List<Stock> Data { get; set; }
    }
}
