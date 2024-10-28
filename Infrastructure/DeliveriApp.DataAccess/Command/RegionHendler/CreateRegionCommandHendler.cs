using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

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
            var region = await _deliveryContext.Regions
                .Where(p => p.RegionName == request.RegionName)
                .FirstOrDefaultAsync(cancellationToken);

            if (region != null)
            {
                throw new Exception();
            }
                

            await _deliveryContext.AddAsync(request.UpsertRegion(), cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
