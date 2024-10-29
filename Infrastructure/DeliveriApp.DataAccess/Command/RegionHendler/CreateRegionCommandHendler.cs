using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.RegionHendler
{
    public class CreateRegionCommandHendler : IRequestHendler<UpsertRegionCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly ILogger<CreateRegionCommandHendler> _logger;

        public CreateRegionCommandHendler(DeliveryContext deliveryContext,
            ILogger<CreateRegionCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _logger = logger;
        }
        public async Task HendlerAsync(UpsertRegionCommand request, CancellationToken cancellationToken = default)
        {
            var region = await _deliveryContext.Regions
                .Where(p => p.RegionName == request.RegionName)
                .FirstOrDefaultAsync(cancellationToken);
            _logger.LogInformation("Has been serched in bd the same name of the region {Name}", request.RegionName);

            if (region != null)
            {
                _logger.LogError("The same name {Name} has been founded", request.RegionName);
                throw new Exception();
                
            }
                

            await _deliveryContext.AddAsync(request.UpsertRegion(), cancellationToken);
            _logger.LogInformation("The region has added to bd");
            await _deliveryContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Save changes in bd for regions");
        }
    }
}
