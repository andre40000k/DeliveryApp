using DeliveriApp.Domein;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class UpsertManyOrdersCommand : BaseProperties
    {
        public int countOrders { get; set; }
    }
}
