using DeliveriApp.Application.Services;
using DeliveriApp.Application.UpsertModels.Commands;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DeliveriApp.DataAccess.Command.OrderHendler
{
    public class CreateManyOrdersCommandHendler : IRequestHendler<UpsertManyOrdersCommand>
    {
        private readonly DeliveryContext _deliveryContext;
        private readonly IRequestHendler<UpsertOrderCommand> _createOrderCommandHendler;

        public CreateManyOrdersCommandHendler(DeliveryContext deliveryContext,
            IRequestHendler<UpsertOrderCommand> createOrderCommandHendler)
        {
            _deliveryContext = deliveryContext;
            _createOrderCommandHendler = createOrderCommandHendler;
        }

        public async Task HendlerAsync(UpsertManyOrdersCommand request, CancellationToken cancellationToken = default)
        {
            var regions = await _deliveryContext.Regions
                .Where(p => p.CityId == request.Id)
                .ToListAsync(cancellationToken); 

            var lenghtListOfRegions = regions.Count();

            Random random = new Random();

            int averageSpeed = 3;

            for (int i = 0; i < request.countOrders; i++)
            {
                var region = regions[random.Next(0, lenghtListOfRegions)];
                DateTime currentTime = DateTime.Now;
                int distance = random.Next(region.MinDistanceFromCafe, region.MaxDistanceFromCafe);

                await _createOrderCommandHendler.HendlerAsync(new UpsertOrderCommand
                {
                    RegionId = region.Id,
                    OrderWeight = random.Next(1, 200),
                    TimeOrder = currentTime.AddMinutes(random.Next(1,70)),
                    Distance = distance,
                    DeliveriTime = currentTime.AddSeconds(distance / averageSpeed),
                }, cancellationToken);
            }
        }
    }
}
