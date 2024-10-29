using DeliveriApp.Application.Contract.Respons;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Application.UpsertModels.Queries;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Query.FiltrationOrderHendler
{
    public class GetOrderByTimeQuery : IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly IRequestHendler<UpsertFiltrationOrderCommand> _requestHendler;
        private readonly ILogger<GetOrderByTimeQuery> _logger;
        public GetOrderByTimeQuery(DeliveryContext deliveryContext,
            IRequestHendler<UpsertFiltrationOrderCommand> requestHendler,
            ILogger<GetOrderByTimeQuery> logger)
        {
            _deliveryContext = deliveryContext;
            _requestHendler = requestHendler;
            _logger = logger;
        }

        public async Task<ResponsFirstThityMinutesOrders> HendlerAsync(GetByIdRegionQuery request, CancellationToken cancellationToken = default)
        {
            var firstOrderTime = await _deliveryContext.Orders
                .Where(order => order.RegionId == request.Id)
                .OrderBy(order => order.TimeOrder)
                .Select(order => (DateTime?)order.TimeOrder)
                .FirstOrDefaultAsync(cancellationToken);

            _logger.LogInformation("Has been got the time of first order");

            if (firstOrderTime == null)
            {
                _logger.LogError("No orders in bd");
                throw new Exception();                
            }

            DateTime endTime = firstOrderTime.Value.AddMinutes(30);

            /*var filteredOrders = await _deliveryContext.Orders
                 .Where(order => order.RegionId == request.Id &&
                                 order.TimeOrder >= firstOrderTime &&
                                 order.TimeOrder <= endTime)
                 .OrderBy(time => time.DeliveriTime)
                 .ToListAsync();*/

            var filteredOrders = await _deliveryContext.Orders
                 .Where(order => order.RegionId == request.Id &&
                                 order.DeliveriTime >= firstOrderTime &&
                                 order.DeliveriTime <= endTime)
                 .OrderBy(time => time.DeliveriTime)
                 .ToListAsync();

            _logger.LogInformation("Has been got orders for delivery to a specific area of the city within half an hour after the time of the first order.");

            await _requestHendler.HendlerAsync(new UpsertFiltrationOrderCommand
            {
                Orders = filteredOrders
            });

            return new ResponsFirstThityMinutesOrders
            {
                Orders = filteredOrders
            };
        }
    }
}
