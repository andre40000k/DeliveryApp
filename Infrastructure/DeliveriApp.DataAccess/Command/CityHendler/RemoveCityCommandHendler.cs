using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.Command.CityHendler
{
    public class RemoveCityCommandHendler : IRequestHendler<DelIfExistsIdCommand>
    {
        private readonly DeliveryContext _deliveryContext;

        public RemoveCityCommandHendler(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }

        public async Task HendlerAsync(DelIfExistsIdCommand request, CancellationToken cancellationToken = default)
        {
            City city = request.DelIfExistsCommand<City>();

            try
            {
                _deliveryContext.Attach(city);
                _deliveryContext.Entry(city).State = EntityState.Deleted;
                await _deliveryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("404");
            }
        }
    }
}
