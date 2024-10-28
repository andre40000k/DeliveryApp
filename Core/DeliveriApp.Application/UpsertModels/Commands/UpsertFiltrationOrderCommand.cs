using DeliveriApp.Domein.Entities;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class UpsertFiltrationOrderCommand
    {
        public List<Order> Orders { get; set; }

        public List<FiltrationOrder> UpsertSortedOrder()
        {
            List<FiltrationOrder> sortedOrders = new ();

            foreach (var order in Orders)
            {
                sortedOrders.Add(
                    new FiltrationOrder
                    {
                        RegionId = order.RegionId,
                        OrderId = order.OrderId,
                        OrderWeight = order.OrderWeight,
                        TimeOrder = order.TimeOrder,
                        Distance = order.Distance,
                        DeliveriTime = order.DeliveriTime,
                        TimeDelivery = order.TimeDelivery,
                        
                    });
            }

            return sortedOrders;
        }
    }
}
