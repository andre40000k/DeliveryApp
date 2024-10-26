namespace DeliveriApp.Domein.Entities
{
    public class City : BaseProperties
    {
        public string CityName { get; set; }
        public IEnumerable<Region> Regions { get; set; }
    }
}
