using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveriApp.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p=> p.CityName).IsRequired().HasMaxLength(100);

            builder.ToTable(nameof(City));
        }
    }
}
