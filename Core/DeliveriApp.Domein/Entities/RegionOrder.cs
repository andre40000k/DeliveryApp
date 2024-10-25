namespace DeliveriApp.Domein.Entities
{
    public class RegionOrder : BaseProperties
    {

        public Guid RegionId { get; set; }
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
        public Region Region { get; set; }
    }
}
