using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.CityHendler
{
    public class RemoveCityCommandHendler : IRequestHendler<DelIfExistsIdCommand>
    {
        private readonly ILogger<RemoveCityCommandHendler> _logger;
        private readonly DeliveryContext _deliveryContext;

        public RemoveCityCommandHendler(DeliveryContext deliveryContext, 
            ILogger<RemoveCityCommandHendler> logger)
        {
            _deliveryContext = deliveryContext;
            _logger = logger;
        }

        public async Task HendlerAsync(DelIfExistsIdCommand request, CancellationToken cancellationToken = default)
        {
            City city = request.GetByIdCommand<City>();

            try
            {
               
                _deliveryContext.Attach(city);
                _deliveryContext.Entry(city).State = EntityState.Deleted;
                _logger.LogInformation("Remove the city from bd");
                await _deliveryContext.SaveChangesAsync();
                _logger.LogInformation("Save changes in bd for cities");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("404");
                _logger.LogError(ex, "Exeception durring of process removing of the city");
            }
        }
    }
}
