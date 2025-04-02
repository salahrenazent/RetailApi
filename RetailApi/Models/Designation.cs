namespace RetailApi.Models
{
    public class Designation
    {
        public int ID { get; set; } // Primary Key, Auto-Increment
        public string CODE { get; set; }
        public string DESG_NAME { get; set; }
        public int COMPANY_ID { get; set; }
        public string? COMPANY_NAME { get; set; }
        public bool IS_INACTIVE { get; set; }
        public bool IS_DELETED { get; set; }
        public byte[] DBTimestamp { get; set; }
    }
    public class DesignationResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public Designation data { get; set; }
        public List<Designation> datas { get; set; }
    }
}
