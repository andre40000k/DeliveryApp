namespace DeliveriApp.Domein.Interfaces.Repository
{
    public interface ISetRepository
    {
        Task AddEntityAsync(BaseEntity baseEntity, CancellationToken cancellationToken = default);

        Task AddRangeEntitiesAsync<T>(List<T> baseEntities, CancellationToken cancellationToken = default) where T : BaseEntity;

        /*Task<Shop> GetByIdAsync(Guid shopId, CancellationToken cancellationToken = default);*/
    }
}
