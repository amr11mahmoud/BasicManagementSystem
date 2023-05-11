using Microsoft.EntityFrameworkCore;

namespace BasicMangementSystem.Web.Data
{
    public class MangementSystemDbContext:DbContext
    {
        public MangementSystemDbContext(DbContextOptions<MangementSystemDbContext> options):base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
