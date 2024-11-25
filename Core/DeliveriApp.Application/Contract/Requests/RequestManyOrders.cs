using DeliveriApp.Domein;

namespace DeliveriApp.Application.Contract.Requests
{
    public class RequestManyOrders : BaseEntity
    {
        public int countOrders { get; set; }
    }
}
