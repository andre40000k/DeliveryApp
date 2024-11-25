using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using DeliveriApp.Domein.Entities;
using DeliveriApp.Domein.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.FiltrationOrderHendler
{
    public class AddRangeSortedOrderCommandHendler : IRequestHendler<UpsertFiltrationOrderCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly ILogger<AddRangeSortedOrderCommandHendler> _logger;
        private readonly ISetRepository _setRepository;

        public AddRangeSortedOrderCommandHendler(DeliveryContext deliveryContext, 
            ISetRepository setRepository,
            ILogger<AddRangeSortedOrderCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _setRepository = setRepository;
            _logger = logger;
        }

        public async Task HendlerAsync(UpsertFiltrationOrderCommand request, CancellationToken cancellationToken = default)
        {
            
            await _deliveryContext.FiltrationOrders.ExecuteDeleteAsync();
            _logger.LogInformation("Remove all date from bd filtred orders");
            
            var sortedList = request.UpsertSortedOrder().OrderBy(o => o.DeliveriTime).ToList();
            await _setRepository.AddRangeEntitiesAsync(sortedList, cancellationToken);
        }
    }
}
