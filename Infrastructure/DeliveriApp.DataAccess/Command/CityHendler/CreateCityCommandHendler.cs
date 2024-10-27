using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;

namespace DeliveriApp.DataAccess.Command.CityHendler
{
    public class CreateCityCommandHendler : IRequestHendler<UpsertCityCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        public CreateCityCommandHendler(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }

        public async Task HendlerAsync(UpsertCityCommand request, CancellationToken cancellationToken = default)
        {
            await _deliveryContext.AddAsync(request.UpsertCity(), cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
