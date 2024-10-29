using DeliveriApp.Application.Contract.Respons;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Queries;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.Query.FiltrationOrderHendler
{
    public class GetOrderByRegionTimeQuery : IRsponsHendler<ResponsFirstThityMinutesOrders>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders> _query;

        public GetOrderByRegionTimeQuery(DeliveryContext deliveryContext,
            IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders> query)
        {
            _deliveryContext = deliveryContext;
            _query = query;
        }

        public async Task<ResponsFirstThityMinutesOrders> HendlerAsync(CancellationToken cancellationToken = default)
        {
            var regionId = await _deliveryContext.Orders
                .GroupBy(o => o.RegionId)
                .Select(group => new
                {
                    RegionId = group.Key,
                    OrderCount = group.Count()
                })
                .OrderByDescending(region => region.OrderCount)
                .FirstOrDefaultAsync();

            var filtredOrders = await _query.HendlerAsync(new GetByIdRegionQuery 
            { 
                Id = regionId?.RegionId ?? throw new Exception()
            }, cancellationToken);

            return filtredOrders;
        }
    }
}
