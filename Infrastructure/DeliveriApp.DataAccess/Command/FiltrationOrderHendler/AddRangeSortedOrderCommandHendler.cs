using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.Command.FiltrationOrderHendler
{
    public class AddRangeSortedOrderCommandHendler : IRequestHendler<UpsertFiltrationOrderCommand>
    {
        private readonly DeliveryContext _deliveryContext;

        public AddRangeSortedOrderCommandHendler(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }

        public async Task HendlerAsync(UpsertFiltrationOrderCommand request, CancellationToken cancellationToken = default)
        {
            await _deliveryContext.FiltrationOrders.ExecuteDeleteAsync();

            var sortedList = request.UpsertSortedOrder().OrderBy(o => o.DeliveriTime).ToList();
            await _deliveryContext.AddRangeAsync(sortedList, cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
