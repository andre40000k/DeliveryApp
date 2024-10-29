using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.OrderHendler
{
    public class CreateOrderCommandHendler : IRequestHendler<UpsertOrderCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly ILogger<CreateOrderCommandHendler> _logger;
        public CreateOrderCommandHendler(DeliveryContext deliveryContext, 
            ILogger<CreateOrderCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _logger = logger;
        }
        public async Task HendlerAsync(UpsertOrderCommand request, CancellationToken cancellationToken = default)
        {
            int maxOrderId = await _deliveryContext.Orders.MaxAsync(o => (int?)o.OrderId) ?? 0;
            request.OrderId = ++maxOrderId;
            _logger.LogInformation("The order hes gotten {OrderId}", request.OrderId);


            await _deliveryContext.AddAsync(request.UpsertOrder(), cancellationToken);
            _logger.LogInformation("The order add to bd orders");
            await _deliveryContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Save changes in bd for orders");
        }
    }
}
