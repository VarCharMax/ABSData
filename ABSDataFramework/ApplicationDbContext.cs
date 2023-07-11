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

        public DbSet<PopulationData> FactPopulation { get; set; }

        public DbSet<Sex> DimSex { get; set; }

        public DbSet<Region> DimRegion { get; set; }

        public DbSet<DimState> DimState { get; set; }

        public DbSet<Age> DimAge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
