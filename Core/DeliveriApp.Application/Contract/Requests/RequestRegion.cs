namespace DeliveriApp.Application.Contract.Requests
{
    public class RequestRegion
    {
        public Guid CityId { get; set; }
        public string RegionName { get; set; }
        public int MinDistanceFromCafe { get; set; }
        public int MaxDistanceFromCafe { get; set; }
    }
}
