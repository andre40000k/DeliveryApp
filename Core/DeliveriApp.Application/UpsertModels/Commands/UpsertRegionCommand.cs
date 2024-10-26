using DeliveriApp.Domein.Entities;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class UpsertRegionCommand
    {
        public Guid CityId { get; set; }
        public string RegionName { get; set; }
        public int MinDistanceFromCafe { get; set; }
        public int MaxDistanceFromCafe { get; set; }

        public Region UpsertRegion()
        {
            return new Region
            {
                CityId = CityId,
                RegionName = RegionName,
                MaxDistanceFromCafe = MaxDistanceFromCafe,
                MinDistanceFromCafe = MinDistanceFromCafe
            };
        }
    }
}
