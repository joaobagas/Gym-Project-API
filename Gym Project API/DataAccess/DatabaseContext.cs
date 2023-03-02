using Gym_Project_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Gym_Project_API.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Post> Posts { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source = ./BPR-DB.db");
        }
    }
}
