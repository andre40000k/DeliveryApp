using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DeliveriApp.Domein.Entities;

namespace DeliveriApp.Data.Context
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) { }

        public DbSet<City> Citys => Set<City>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<RegionOrder> RegionOrders => Set<RegionOrder>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryContext).Assembly);
        }
    }
}
