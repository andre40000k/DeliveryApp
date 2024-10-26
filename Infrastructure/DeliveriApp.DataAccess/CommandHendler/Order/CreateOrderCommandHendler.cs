using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.CommandHendler.Order
{
    public class CreateOrderCommandHendler : IRequestHendler<UpsertOrderCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        public CreateOrderCommandHendler(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public async Task HendlerAsync(UpsertOrderCommand request, CancellationToken cancellationToken = default)
        {
            var maxOrderId = await _deliveryContext.Orders.MaxAsync(o => (int?)o.OrderId) ?? 0;
            request.OrderId = ++maxOrderId;

            await _deliveryContext.AddAsync(request.UpsertOrder(), cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
