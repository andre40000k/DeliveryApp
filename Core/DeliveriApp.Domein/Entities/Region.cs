namespace DeliveriApp.Domein.Entities
{
    public class Region : BaseProperties
    {
        public Guid CityId { get; set; }
        public City City { get; set; }

        public string RegionName { get; set; }
        public int MinDistanceFromCafe { get; set; }
        public int MaxDistanceFromCafe { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }
}
