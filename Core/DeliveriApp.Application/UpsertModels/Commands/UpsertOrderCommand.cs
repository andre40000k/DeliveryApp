using DeliveriApp.Domein.Entities;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class UpsertOrderCommand
    {
        public Guid RegionId { get; set; }
        public int OrderId { get; set; }
        public double OrderWeight { get; set; }
        public DateTime TimeOrder { get; set; }
        public int Distance { get; set; }
        public DateTime DeliveriTime { get; set; }

        public Order UpsertOrder()
        {
            return new Order
            {
                RegionId = RegionId,
                OrderId = OrderId,
                OrderWeight = OrderWeight,
                TimeOrder = TimeOrder,
                Distance = Distance,
                DeliveriTime = DeliveriTime,
                TimeDelivery = DeliveriTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
    }
}
