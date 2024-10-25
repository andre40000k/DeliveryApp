namespace DeliveriApp.Domein.Entities
{
    public class City : BaseProperties
    {
        public IEnumerable<Region> RegionList { get; set; }
    }
}
