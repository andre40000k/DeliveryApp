using Microsoft.EntityFrameworkCore;
using DeliveriApp.Domein.Entities;

namespace DeliveriApp.Data.Context
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) { }

        public DbSet<City> Citys { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryContext).Assembly);
        }
    }
}
