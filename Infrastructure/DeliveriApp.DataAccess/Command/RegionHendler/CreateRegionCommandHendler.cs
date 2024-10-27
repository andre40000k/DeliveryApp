using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;

namespace DeliveriApp.DataAccess.Command.RegionHendler
{
    public class CreateRegionCommandHendler : IRequestHendler<UpsertRegionCommand>
    {
        private readonly DeliveryContext _deliveryContext;

        public CreateRegionCommandHendler(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public async Task HendlerAsync(UpsertRegionCommand request, CancellationToken cancellationToken = default)
        {
            await _deliveryContext.AddAsync(request.UpsertRegion(), cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
