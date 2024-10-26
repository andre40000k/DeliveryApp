using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveriApp.Data.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(k=>k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.RegionName).IsRequired();
            builder.Property(p => p.MinDistanceFromCafe).IsRequired();
            builder.Property(p=>p.MaxDistanceFromCafe).IsRequired();
            
            builder.HasOne(c => c.City)
                .WithMany(c=>c.Regions)
                .HasForeignKey(c=>c.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(nameof(Region));
        }
    }
}
