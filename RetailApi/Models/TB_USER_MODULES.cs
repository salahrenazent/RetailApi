namespace RetailApi.Models
{
    public class TB_USER_MODULES
    {
        public int ID { get; set; }
        public string MODULE_NAME { get; set; }
        public int DOC_ID { get; set; }
        public int MAIN_MODULE_ID { get; set; }
        public string COMPONENT_NAME { get; set; }
        public string MENU_ICON { get; set; }
        public bool IS_INACTIVE { get; set; }
        public float MODULE_ORDER { get; set; }
        public ICollection<TB_USER_RIGHTS> TB_USER_RIGHTS {  get; set; }
    }
}
