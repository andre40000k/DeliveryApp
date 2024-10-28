using DeliveriApp.Domein;

namespace DeliveriApp.Application.Contract.Requests
{
    public class RequestManyOrders : BaseProperties
    {
        public int countOrders { get; set; }
    }
}
