using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.CityHendler
{
    public class CreateCityCommandHendler : IRequestHendler<UpsertCityCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly ILogger<CreateCityCommandHendler> _logger;
        public CreateCityCommandHendler(DeliveryContext deliveryContext,
            ILogger<CreateCityCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _logger = logger;
        }

        public async Task HendlerAsync(UpsertCityCommand request, CancellationToken cancellationToken = default)
        {
            await _deliveryContext.AddAsync(request.UpsertCity(), cancellationToken);
            _logger.LogInformation("The city has added to bd the cyti");
            await _deliveryContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Save changes in bd for cities");
        }
    }
}
