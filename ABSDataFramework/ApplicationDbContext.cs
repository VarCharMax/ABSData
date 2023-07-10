using ABSDataFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace ABSDataFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
           DbContextOptions options) : base(options)
        {

        }

        public DbSet<abs_data> AbsData { get; set; }

        public DbSet<sex_abs> Sexes { get; set; }

        public DbSet<region> Regions { get; set; }

        public DbSet<state> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
