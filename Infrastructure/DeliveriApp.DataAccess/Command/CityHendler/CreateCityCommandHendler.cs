using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using DeliveriApp.Domein.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace DeliveriApp.DataAccess.Command.CityHendler
{
    public class CreateCityCommandHendler : IRequestHendler<UpsertCityCommand>
    {
        private readonly ISetRepository _setRepository;
        public CreateCityCommandHendler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }

        public async Task HendlerAsync(UpsertCityCommand request, CancellationToken cancellationToken = default)
        {
            await _setRepository.AddEntityAsync(request.UpsertCity(), cancellationToken);
        }
    }
}
