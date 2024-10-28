using DeliveriApp.Domein;

namespace DeliveriApp.Application.Contract.Requests
{
    public class RequestManyOrdersCommand : BaseProperties
    {
        public int countOrders { get; set; }
    }
}
