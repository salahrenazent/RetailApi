using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailApi.Models
{
    [Table("TB_USERS")]
    public class ApplicationUser : IdentityUser<int>
    {
        [Key]
        [Column("USER_ID")]
        public override int Id { get; set; }
        [Column("USER_NAME")]
        public override string UserName { get; set; }
        public string LOGIN_NAME { get; set; }
        [Column("PASSWORD")]
        public override string PasswordHash { get; set; }
        [Column("EMAIL")]
        public override string Email { get; set; }
        public string MOBILE { get; set; }
        public int USER_LEVEL { get; set; }
        public bool IS_INACTIVE { get; set; }
        public string COMPANY_ID { get; set; }
    }
}
