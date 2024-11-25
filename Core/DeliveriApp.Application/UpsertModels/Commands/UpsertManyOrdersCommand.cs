using DeliveriApp.Domein;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class UpsertManyOrdersCommand : BaseEntity
    {
        public int countOrders { get; set; }
    }
}
