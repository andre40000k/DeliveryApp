using DeliveriApp.Data.Context;
using DeliveriApp.Domein;
using DeliveriApp.Domein.Interfaces.Repository;

namespace DeliveriApp.Repositories.SetData
{
    public class CUD_Operation : ISetRepository
    {
        private readonly DeliveryContext _deliveryContext;

        public CUD_Operation(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public async Task AddEntityAsync(BaseEntity baseEntity, CancellationToken cancellationToken = default)
        {
            await _deliveryContext.AddAsync(baseEntity, cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeEntitiesAsync<T>(List<T> baseEntities, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            await _deliveryContext.AddRangeAsync(baseEntities, cancellationToken);
            await _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }

}
