namespace DeliveriApp.Application.Contract.Requests
{
    public class RequestOrder
    {
        public Guid RegionId { get; set; }
        public double OrderWeight { get; set; }
        public DateTime TimeOrder { get; set; }
        public int Distance { get; set; }
        public DateTime DeliveriTime { get; set; }
    }
}

