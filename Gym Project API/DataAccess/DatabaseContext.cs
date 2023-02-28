using Microsoft.EntityFrameworkCore;

namespace Gym_Project_API.DataAccess
{
    public class DatabaseContext : DBContext
    {
        // public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ./BPR-DB.db");
        }
    }
}
