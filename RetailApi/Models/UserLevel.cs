using Newtonsoft.Json;

namespace RetailApi.Models
{
    public class UserLevel
    {
        public int ID { get; set; }
        public string LEVEL_NAME { get; set; }
        public bool CAN_VIEW_COST { get; set; }
        public bool IS_INACTIVE { get; set; }
        public int COMPANY_ID { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UserRight> rights { get; set; }

    }
    public class UserRight
    {
        public int ID { get; set; }
        public int MODULE_ID { get; set; }
        public bool IS_ADD { get; set; }
        public bool IS_VIEW { get; set; }
        public bool IS_MODIFY { get; set; }
        public bool IS_DELETE { get; set; }
        public bool IS_VERIFY { get; set; }
        public bool IS_APPROVE { get; set; }
        public bool IS_PRINT { get; set; }
        public bool IS_EXPORT { get; set; }
    }

    public class UserMenuList
    {
        public int ID { get; set; }
        public string MODULE_NAME { get; set; }
        public int MAIN_MODULE_ID { get; set; }
        public string COMPONENT_NAME { get; set; }
        public string MENU_ICON { get; set; }
        public bool IS_INACTIVE { get; set; }
        public float MODULE_ORDER { get; set; }

    }
    public class UserLevelResponse
    {
        public int Flag { get; set; }
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UserMenuList> menu { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UserLevel> data { get; set; }
    }
}
