namespace DeliveriApp.Domein.Entities
{
    class Order : BaseProperties
    {
        IEnumerable<RegionOrder> RegionOrder { get; set; }
    }
}
