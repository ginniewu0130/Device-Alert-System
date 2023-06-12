
using Microsoft.EntityFrameworkCore;
using PJ_Login.Models;

namespace PJ_Login.Data
{
    public class LoginContext:DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {
        }

        public DbSet<UserLogin> UserLogins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 定義實體類別和資料表之間的映射
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            // 可以根據需要添加其他的映射設定
            modelBuilder.Entity<UserLogin>().HasData(
                new UserLogin { UserId=1,Account="test001",Password="12345"},
                new UserLogin { UserId=2,Account="test002",Password="12345"} );

            base.OnModelCreating(modelBuilder);
        }
    }
}
