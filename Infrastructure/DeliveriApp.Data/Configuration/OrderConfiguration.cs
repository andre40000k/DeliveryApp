using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveriApp.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p=>p.OrderId).IsRequired();
            builder.Property(p=>p.OrderWeight).IsRequired();
            builder.Property(p=>p.DeliveriTime).IsRequired();

            builder.HasOne(r=>r.Region)
                .WithMany(r => r.Orders)
                .HasForeignKey(r=>r.RegionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(nameof(Order));
        }
    }
}
