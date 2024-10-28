using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using DeliveriApp.Domein.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.DataAccess.Command.RegionHendler
{
    public class RemoveRegionCommandHendler : IRequestHendler<DelIfExistsIdCommand>
    {
        private readonly DeliveryContext _deliveryContext;

        public RemoveRegionCommandHendler(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public async Task HendlerAsync(DelIfExistsIdCommand request, CancellationToken cancellationToken = default)
        {
            var region = request.GetByIdCommand<Region>();

            try
            {
                _deliveryContext.Attach(region);
                _deliveryContext.Entry(region).State = EntityState.Deleted;
                await _deliveryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("404");
            }
           
        }
    }
}
