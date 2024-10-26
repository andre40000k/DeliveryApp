namespace DeliveriApp.Application.Contract.Requests
{
    public class RequestOrderCommand
    {
        public Guid RegionId { get; set; }
        public double OrderWeight { get; set; }
        public DateTime DeliveriTime { get; set; }
    }
}

