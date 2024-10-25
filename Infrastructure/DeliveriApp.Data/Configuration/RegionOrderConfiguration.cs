using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveriApp.Data.Configuration
{
    public class RegionOrderConfiguration : IEntityTypeConfiguration<RegionOrder>
    {
        public void Configure(EntityTypeBuilder<RegionOrder> builder)
        {
            throw new NotImplementedException();
        }
    }
}
