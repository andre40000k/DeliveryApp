namespace DeliveriApp.Domein.Entities
{
    class City : BaseProperties
    {
        public IEnumerable<Region> RegionList { get; set; }
    }
}
