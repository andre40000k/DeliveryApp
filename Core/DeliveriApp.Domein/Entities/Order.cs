namespace DeliveriApp.Domein.Entities
{
    public class Order : BaseProperties
    {
        IEnumerable<RegionOrder> RegionOrder { get; set; }
    }
}
