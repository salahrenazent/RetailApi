using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RetailApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser {  get; set; }
        public DbSet<TB_USER_MODULES> TB_USER_MODULES {  get; set; }
        public DbSet<TB_USER_LEVELS> TB_USER_LEVELS {  get; set; }
        public DbSet<TB_USER_RIGHTS> TB_USER_RIGHTS {  get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Map IdentityUser to TB_USERS
            builder.Entity<ApplicationUser>().ToTable("TB_USERS");

            
        }
    }
}
