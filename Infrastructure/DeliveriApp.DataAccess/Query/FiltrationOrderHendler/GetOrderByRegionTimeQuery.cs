using DeliveriApp.Application.Contract.Respons;
using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Queries;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Query.FiltrationOrderHendler
{
    public class GetOrderByRegionTimeQuery : IRsponsHendler<ResponsFirstThityMinutesOrders>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders> _query;
        private readonly ILogger<GetOrderByRegionTimeQuery> _logger;

        public GetOrderByRegionTimeQuery(DeliveryContext deliveryContext,
            IRequestHendler<GetByIdRegionQuery, ResponsFirstThityMinutesOrders> query,
            ILogger<GetOrderByRegionTimeQuery> logger)
        {
            _deliveryContext = deliveryContext;
            _query = query;
            _logger = logger;
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

            _logger.LogInformation("Has been got the region id {Id} with big count of orders", regionId);

            var filtredOrders = await _query.HendlerAsync(new GetByIdRegionQuery
            {
                Id = regionId?.RegionId ?? throw new Exception()
            }, cancellationToken);

            _logger.LogInformation("Has been got the list of orders by {RegionId}", regionId);

            return filtredOrders;
        }
    }
}
