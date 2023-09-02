using Microsoft.EntityFrameworkCore;

namespace Project1.Models
{
    public class FindHimDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MissingPerson> MissingPeople { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FindHim;Trusted_Connection=True;Encrypt=false");
        }
    }
}
