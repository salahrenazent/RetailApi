using System.ComponentModel.DataAnnotations;

namespace RetailApi.Models
{
    public class TB_USER_LEVELS
    {
        [Key]
        public int LEVEL_ID { get; set; }
        public string LEVEL_NAME { get; set; }
        public bool CAN_VIEW_COST { get; set; }
        public bool IS_INACTIVE { get; set; }
        public bool IS_DELETED { get; set; }
        public int COMPANY_ID { get; set; }

        public ICollection<TB_USER_RIGHTS> TB_USER_RIGHTS { get; set; }
    }
}
