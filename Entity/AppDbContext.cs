using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UsersTestApi.Entity
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserItem> UsersItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //usersdb
            string connectString = Configuration.GetConnectionString("BloggingDatabase");// Configuration.GetConnectionString("BloggingDatabase"); // .("usersdb");
            optionsBuilder.UseSqlServer("Server=(localdb)" +
                                        "\\mssqllocaldb;" +
                                        "Database=userstestdb;" +
                                        "Trusted_Connection=True;");
        }
    }
}