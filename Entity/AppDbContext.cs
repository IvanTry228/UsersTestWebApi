using Microsoft.EntityFrameworkCore;

namespace UsersTestApi.Entity
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserItem> UsersItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)" +
                                        "\\mssqllocaldb;" +
                                        "Database=userstestdb;" +
                                        "Trusted_Connection=True;");
        }
    }
}