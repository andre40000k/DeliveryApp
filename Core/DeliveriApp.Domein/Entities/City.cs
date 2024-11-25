namespace DeliveriApp.Domein.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public IEnumerable<Region> Regions { get; set; }
    }
}
