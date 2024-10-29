using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.RegionHendler
{
    public class RemoveRegionCommandHendler : IRequestHendler<DelIfExistsIdCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly ILogger<RemoveRegionCommandHendler> _logger;

        public RemoveRegionCommandHendler(DeliveryContext deliveryContext,
            ILogger<RemoveRegionCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _logger = logger;
        }
        public async Task HendlerAsync(DelIfExistsIdCommand request, CancellationToken cancellationToken = default)
        {
            var region = request.GetByIdCommand<Region>();

            try
            {
                _deliveryContext.Attach(region);
                _logger.LogInformation("Remove the region from bd");
                _deliveryContext.Entry(region).State = EntityState.Deleted;
                await _deliveryContext.SaveChangesAsync();
                _logger.LogInformation("Save changes in bd for regions");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("404");
                _logger.LogError(ex, "Exeception durring of process removing of the region");
            }
           
        }
    }
}
