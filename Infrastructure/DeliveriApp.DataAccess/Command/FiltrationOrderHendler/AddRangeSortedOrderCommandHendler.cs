using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.FiltrationOrderHendler
{
    public class AddRangeSortedOrderCommandHendler : IRequestHendler<UpsertFiltrationOrderCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly ILogger<AddRangeSortedOrderCommandHendler> _logger;

        public AddRangeSortedOrderCommandHendler(DeliveryContext deliveryContext, 
            ILogger<AddRangeSortedOrderCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _logger = logger;
        }

        public async Task HendlerAsync(UpsertFiltrationOrderCommand request, CancellationToken cancellationToken = default)
        {
            
            await _deliveryContext.FiltrationOrders.ExecuteDeleteAsync();
            _logger.LogInformation("Remove all date from bd filtred orders");

            
            var sortedList = request.UpsertSortedOrder().OrderBy(o => o.DeliveriTime).ToList();
            await _deliveryContext.AddRangeAsync(sortedList, cancellationToken);
            _logger.LogInformation("Аll filtred orders has been added to bd filtredOrders");
            await _deliveryContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Save changes in bd for filtred orders");
        }
    }
}
