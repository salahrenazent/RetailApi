namespace RetailApi.Models
{
    public class TB_USER_RIGHTS
    {
        public int ID { get; set; }
        public int LEVEL_ID { get; set; }
        public int MODULE_ID { get; set; }
        public bool IS_ADD { get; set; }
        public bool IS_VIEW { get; set; }
        public bool IS_MODIFY { get; set; }
        public bool IS_DELETE { get; set; }
        public bool IS_VERIFY { get; set; }
        public bool IS_APPROVE { get; set; }
        public bool IS_PRINT { get; set; }
        public bool IS_EXPORT { get; set; }
        public bool IS_MODIFY_DATE { get; set; }
        public virtual TB_USER_LEVELS TB_USER_LEVELS { get; set; }
        public virtual TB_USER_MODULES TB_USER_MODULES { get; set; }
    }
}
