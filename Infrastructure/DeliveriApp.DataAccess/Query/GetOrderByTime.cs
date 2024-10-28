using DeliveriApp.Application.Contract.Respons;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Application.UpsertModels.Queries;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.Query
{
    public class GetOrderByTime : IRequestHendler<GetByIdQuery, ResponsFirstThityMinutesOrders>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly IRequestHendler<UpsertFiltrationOrderCommand> _requestHendler;
        public GetOrderByTime(DeliveryContext deliveryContext, 
            IRequestHendler<UpsertFiltrationOrderCommand> requestHendler)
        {
            _deliveryContext = deliveryContext;
            _requestHendler = requestHendler;
        }

        public async Task<ResponsFirstThityMinutesOrders> HendlerAsync(GetByIdQuery request, CancellationToken cancellationToken = default)
        {
            var firstOrderTime = await _deliveryContext.Orders
                .Where(order => order.RegionId == request.Id)
                .OrderBy(order => order.TimeOrder)
                .Select(order => (DateTime?) order.TimeOrder)
                .FirstOrDefaultAsync(cancellationToken);

            if (firstOrderTime == null)
            {
                return new ResponsFirstThityMinutesOrders();
            }

            DateTime endTime = firstOrderTime.Value.AddMinutes(30);

            var filteredOrders = await _deliveryContext.Orders
                 .Where(order => order.RegionId == request.Id &&
                                 order.TimeOrder >= firstOrderTime &&
                                 order.TimeOrder <= endTime)
                 .ToListAsync();

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
