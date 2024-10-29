using DeliveriApp.Application.Contract.Respons;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Application.UpsertModels.Queries;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.Query.FiltrationOrderHendler
{
    public class GetOrderByTimeQuery : IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly IRequestHendler<UpsertFiltrationOrderCommand> _requestHendler;
        public GetOrderByTimeQuery(DeliveryContext deliveryContext,
            IRequestHendler<UpsertFiltrationOrderCommand> requestHendler)
        {
            _deliveryContext = deliveryContext;
            _requestHendler = requestHendler;
        }

        public async Task<ResponsFirstThityMinutesOrders> HendlerAsync(GetByIdRegionQuery request, CancellationToken cancellationToken = default)
        {
            var firstOrderTime = await _deliveryContext.Orders
                .Where(order => order.RegionId == request.Id)
                .OrderBy(order => order.TimeOrder)
                .Select(order => (DateTime?)order.TimeOrder)
                .FirstOrDefaultAsync(cancellationToken);

            if (firstOrderTime == null)
            {
                return new ResponsFirstThityMinutesOrders();
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
