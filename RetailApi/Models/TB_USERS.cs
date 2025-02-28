using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailApi.Models
{
    public class TB_USERS
    {
        public  int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string LOGIN_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public string USER_LEVEL { get; set; }
        public bool IS_INACTIVE { get; set; }
        public string COMPANY_ID { get; set; }
    }
}
