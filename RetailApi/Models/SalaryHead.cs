namespace RetailApi.Models
{
    public class SalaryHead
    {
        public int ID { get; set; }  // Primary Key

        public string? CODE { get; set; }  // Nullable if not required

        public string? HEAD_NAME { get; set; }

        public string? PRINT_DESCRIPTION { get; set; }

        public int? AC_HEAD_ID { get; set; }  // Nullable 

        public short? HEAD_TYPE { get; set; }  // Using `short` for smallint

        public short? HEAD_ORDER { get; set; }

        public bool IS_INACTIVE { get; set; } = false;  // Default false

        public bool IS_WORKING_DAY { get; set; } = false;

        public bool IS_SYSTEM { get; set; } = false;

        public bool IS_FIXED { get; set; } = false;

        public bool IS_DELETED { get; set; } = false;
    }
    public class SalaryHeadResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public SalaryHead data { get; set; }
        public List<SalaryHead> datas { get; set; }
    }
}
