using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.Data.Configuration
{
    public class FiltrationOrderConfiguration : IEntityTypeConfiguration<FiltrationOrder>
    {
        public void Configure(EntityTypeBuilder<FiltrationOrder> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.OrderId).IsRequired();
            builder.Property(p => p.TimeOrder).IsRequired();
            builder.Property(p => p.OrderWeight).IsRequired();
            builder.Property(p => p.OrderWeight).IsRequired();
            builder.Property(p => p.DeliveriTime).IsRequired();

            builder.HasOne(r => r.Region)
                .WithMany(r => r.SortedOrders)
                .HasForeignKey(r => r.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("FiltrationOrder");
        }
    }
}
